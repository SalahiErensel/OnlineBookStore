using System;

namespace OnlineBookStore.Views.Admin
{
    public partial class Books : System.Web.UI.Page
    {
        //variables
        Models.Functions connection;
        string query;
        string book_title;
        string book_author;
        string book_category;
        int book_quantity;
        int book_price;
        int key = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            connection = new Models.Functions();
            if (!IsPostBack)
            {
                showBooks();
                getCategories();
                getAuthors();
            }
        }

        private void showBooks()
        {
            query = "SELECT * from Books";
            gridViewBooksList.DataSource = connection.GetData(query);
            gridViewBooksList.DataBind();
        }

        private void getCategories()
        {
            query = "SELECT * from Categories";
            dropDownListCategories.DataTextField = connection.GetData(query).Columns["CategoryName"].ToString();
            dropDownListCategories.DataValueField = connection.GetData(query).Columns["Id"].ToString();
            dropDownListCategories.DataSource = connection.GetData(query);
            dropDownListCategories.DataBind();
        }

        private void getAuthors()
        {
            query = "SELECT * from Authors";
            dropDownListAuthors.DataTextField = connection.GetData(query).Columns["AuthorName"].ToString();
            dropDownListAuthors.DataValueField = connection.GetData(query).Columns["Id"].ToString();
            dropDownListAuthors.DataSource = connection.GetData(query);
            dropDownListAuthors.DataBind();
        }

        protected void btnSaveBooksPage_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBookTitle.Text == "" || dropDownListAuthors.SelectedIndex == -1 || txtBookQuantity.Text == "" || txtBookPrice.Text =="" || dropDownListCategories.SelectedIndex == -1)
                {
                    lblErrorMessageBooksPage.Text = "Please Fill All Fields!";
                }
                else
                {
                    book_title = txtBookTitle.Text;
                    book_author = dropDownListAuthors.SelectedValue.ToString();
                    book_category = dropDownListCategories.SelectedValue.ToString();
                    book_quantity = Convert.ToInt32(txtBookQuantity.Text);
                    book_price = Convert.ToInt32(txtBookPrice.Text);

                    query = "insert into Books values('{0}','{1}','{2}','{3}','{4}')";
                    query = string.Format(query, book_title, book_author, book_category, book_quantity, book_price);
                    connection.SetData(query);
                    showBooks();
                    lblErrorMessageBooksPage.Text = "Book " + book_title + " is inserted!";
                    txtBookTitle.Text = "";
                    dropDownListAuthors.SelectedIndex = -1;
                    dropDownListCategories.SelectedIndex = -1;
                    txtBookQuantity.Text = "";
                    txtBookPrice.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblErrorMessageBooksPage.Text = ex.Message;
            }
        }

        protected void gridViewBooksList_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBookTitle.Text = gridViewBooksList.SelectedRow.Cells[2].Text;
            dropDownListAuthors.SelectedValue = gridViewBooksList.SelectedRow.Cells[3].Text;
            dropDownListCategories.SelectedValue = gridViewBooksList.SelectedRow.Cells[4].Text;
            txtBookQuantity.Text = gridViewBooksList.SelectedRow.Cells[5].Text;
            txtBookPrice.Text = gridViewBooksList.SelectedRow.Cells[6].Text;


            if (txtBookTitle.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(gridViewBooksList.SelectedRow.Cells[1].Text);
            }
        }

        protected void btnUpdateBooksPage_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBookTitle.Text == "" || dropDownListAuthors.SelectedIndex == -1 || txtBookQuantity.Text == "" || txtBookPrice.Text == "" || dropDownListCategories.SelectedIndex == -1)
                {
                    lblErrorMessageBooksPage.Text = "Please Fill All Fields!";
                }
                else
                {
                    book_title = txtBookTitle.Text;
                    book_author = dropDownListAuthors.SelectedValue.ToString();
                    book_category = dropDownListCategories.SelectedValue.ToString();
                    book_quantity = Convert.ToInt32(txtBookQuantity.Text);
                    book_price = Convert.ToInt32(txtBookPrice.Text);

                    query = "update Books set BookName = '{0}', BookAuthor = '{1}', BookCategory = '{2}', BookQuantity = '{3}', BookPrice = '{4}' where Id = {5}";
                    query = string.Format(query, book_title, book_author, book_category, book_quantity, book_price, gridViewBooksList.SelectedRow.Cells[1].Text);
                    connection.SetData(query);
                    showBooks();
                    lblErrorMessageBooksPage.Text = "Book " + book_title + " is updated!";
                    txtBookTitle.Text = "";
                    dropDownListAuthors.SelectedIndex = -1;
                    dropDownListCategories.SelectedIndex = -1;
                    txtBookQuantity.Text = "";
                    txtBookPrice.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblErrorMessageBooksPage.Text = ex.Message;
            }
        }

        protected void btnDeleteBooksPage_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBookTitle.Text == "" || dropDownListAuthors.SelectedIndex == -1 || txtBookQuantity.Text == "" || txtBookPrice.Text == "" || dropDownListCategories.SelectedIndex == -1)
                {
                    lblErrorMessageBooksPage.Text = "Please Select Book !";
                }
                else
                {
                    book_title = txtBookTitle.Text;
                    book_author = dropDownListAuthors.SelectedValue.ToString();
                    book_category = dropDownListCategories.SelectedValue.ToString();
                    book_quantity = Convert.ToInt32(txtBookQuantity.Text);
                    book_price = Convert.ToInt32(txtBookPrice.Text);

                    query = "delete from Books where Id = {0}";
                    query = string.Format(query, gridViewBooksList.SelectedRow.Cells[1].Text);
                    connection.SetData(query);
                    showBooks();
                    lblErrorMessageBooksPage.Text = "Book " + book_title + " is deleted!";
                    txtBookTitle.Text = "";
                    dropDownListAuthors.SelectedIndex = -1;
                    dropDownListCategories.SelectedIndex = -1;
                    txtBookQuantity.Text = "";
                    txtBookPrice.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblErrorMessageBooksPage.Text = ex.Message;
            }
        }
    }
}