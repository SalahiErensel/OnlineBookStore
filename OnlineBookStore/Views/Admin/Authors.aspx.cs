using System;

namespace OnlineBookStore.Views.Admin
{
    public partial class Authors : System.Web.UI.Page
    {
        //variables
        int key = 0;
        string query;
        string author_name;
        string gender;
        string country;
        Models.Functions connection;

        protected void Page_Load(object sender, EventArgs e)
        {
            connection = new Models.Functions();
            ShowAuthors();
        }

        private void ShowAuthors()
        {
            query = "SELECT * from Authors";
            gridViewAuthorsList.DataSource = connection.GetData(query);
            gridViewAuthorsList.DataBind();
        }

        protected void btnSaveAuthorsPage_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtAuthorName.Text == "" || dropDownListAuthorGender.SelectedIndex == -1 || dropDownListAuthorCountries.SelectedIndex == -1)
                {
                    lblErrorMessageAuthorsPage.Text = "Please Fill All Fields!";
                }
                else
                {
                    author_name = txtAuthorName.Text;
                    gender = dropDownListAuthorGender.SelectedItem.Value.ToString();
                    country = dropDownListAuthorCountries.SelectedItem.Value.ToString();

                    query = "insert into Authors values('{0}','{1}','{2}')";
                    query = string.Format(query, author_name, gender, country);
                    connection.SetData(query);
                    ShowAuthors();
                    lblErrorMessageAuthorsPage.Text = "Author " + author_name + " is inserted!";
                    txtAuthorName.Text = "";
                    dropDownListAuthorCountries.SelectedIndex = -1;
                    dropDownListAuthorGender.SelectedIndex = -1;
                }
            }
            catch(Exception ex)
            {
                lblErrorMessageAuthorsPage.Text = ex.Message;
            }
        }

        protected void gridViewAuthorsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAuthorName.Text = gridViewAuthorsList.SelectedRow.Cells[2].Text;
            gender = gridViewAuthorsList.SelectedRow.Cells[3].Text;
            country = gridViewAuthorsList.SelectedRow.Cells[4].Text;
            dropDownListAuthorGender.SelectedIndex = dropDownListAuthorGender.Items.IndexOf(dropDownListAuthorGender.Items.FindByText(gender));
            dropDownListAuthorCountries.SelectedIndex = dropDownListAuthorCountries.Items.IndexOf(dropDownListAuthorCountries.Items.FindByText(country));

            if (txtAuthorName.Text == "")
            {
                key = 0;    
            }
            else
            {
                key = Convert.ToInt32(gridViewAuthorsList.SelectedRow.Cells[1].Text);
            }
        }

        protected void btnUpdateAuthorsPage_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAuthorName.Text == "" || dropDownListAuthorGender.SelectedIndex == -1 || dropDownListAuthorCountries.SelectedIndex == -1)
                {
                    lblErrorMessageAuthorsPage.Text = "Please Fill All Fields!";
                }
                else
                {
                    author_name = txtAuthorName.Text;
                    gender = dropDownListAuthorGender.SelectedItem.Value.ToString();
                    country = dropDownListAuthorCountries.SelectedItem.Value.ToString();

                    query = "update Authors set AuthorName = '{0}', AuthorGender = '{1}', AuthorCountry = '{2}' where Id = {3}";
                    query = string.Format(query, author_name, gender, country, gridViewAuthorsList.SelectedRow.Cells[1].Text);
                    connection.SetData(query);
                    ShowAuthors();
                    lblErrorMessageAuthorsPage.Text = "Author " + author_name + " is updated!";
                    txtAuthorName.Text = "";
                    dropDownListAuthorCountries.SelectedIndex = -1;
                    dropDownListAuthorGender.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                lblErrorMessageAuthorsPage.Text = ex.Message;
            }
        }

        protected void btnDeleteAuthorsPage_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAuthorName.Text == "" || dropDownListAuthorGender.SelectedIndex == -1 || dropDownListAuthorCountries.SelectedIndex == -1)
                {
                    lblErrorMessageAuthorsPage.Text = "Please Select Author!";
                }
                else
                {
                    author_name = txtAuthorName.Text;
                    gender = dropDownListAuthorGender.SelectedItem.Value.ToString();
                    country = dropDownListAuthorCountries.SelectedItem.Value.ToString();

                    query = "delete from Authors where Id = {0}";
                    query = string.Format(query,gridViewAuthorsList.SelectedRow.Cells[1].Text);
                    connection.SetData(query);
                    ShowAuthors();
                    lblErrorMessageAuthorsPage.Text = "Author " + author_name + " is deleted!";
                    txtAuthorName.Text = "";
                    dropDownListAuthorCountries.SelectedIndex = -1;
                    dropDownListAuthorGender.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                lblErrorMessageAuthorsPage.Text = ex.Message;
            }
        }
    }
}