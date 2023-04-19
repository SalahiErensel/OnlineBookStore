using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBookStore.Views.Admin
{
    public partial class Categories : System.Web.UI.Page
    {
        //variables
        Models.Functions connection;
        int key = 0;
        string query;
        string category_name;
        string category_description;

        protected void Page_Load(object sender, EventArgs e)
        {
            connection = new Models.Functions();
            ShowCategories();
        }

        private void ShowCategories()
        {
            query = "SELECT * from Categories";
            gridViewCategoryList.DataSource = connection.GetData(query);
            gridViewCategoryList.DataBind();
        }

        protected void btnSaveBooksPage_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCategoryName.Text == "" || txtCategoryDescription.Text == "")
                {
                    lblErrorMessageCategoriesPage.Text = "Please Fill All Fields!";
                }
                else
                {
                    category_name = txtCategoryName.Text;
                    category_description = txtCategoryDescription.Text;

                    query = "insert into Categories values('{0}','{1}')";
                    query = string.Format(query, category_name, category_description);
                    connection.SetData(query);
                    ShowCategories();
                    lblErrorMessageCategoriesPage.Text = "Category " + category_name + " is inserted!";
                    txtCategoryName.Text = "";
                    txtCategoryDescription.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblErrorMessageCategoriesPage.Text = ex.Message;
            }
        }

        protected void gridViewCategoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCategoryName.Text = gridViewCategoryList.SelectedRow.Cells[2].Text;
            txtCategoryDescription.Text = gridViewCategoryList.SelectedRow.Cells[3].Text;

            if (txtCategoryName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(gridViewCategoryList.SelectedRow.Cells[1].Text);
            }
        }

        protected void btnUpdateBooksPage_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCategoryName.Text == "" || txtCategoryDescription.Text == "")
                {
                    lblErrorMessageCategoriesPage.Text = "Please Fill All Fields!";
                }
                else
                {
                    category_name = txtCategoryName.Text;
                    category_description = txtCategoryDescription.Text;

                    query = "update Categories set CategoryName = '{0}', CategoryDescription= '{1}' where Id = {2}";
                    query = string.Format(query, category_name, category_description, gridViewCategoryList.SelectedRow.Cells[1].Text);
                    connection.SetData(query);
                    ShowCategories();
                    lblErrorMessageCategoriesPage.Text = "Category " + category_name + " is updated!";
                    txtCategoryName.Text = "";
                    txtCategoryDescription.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblErrorMessageCategoriesPage.Text = ex.Message;
            }
        }

        protected void btnDeleteBooksPage_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCategoryName.Text == "" || txtCategoryDescription.Text == "")
                {
                    lblErrorMessageCategoriesPage.Text = "Please Select Category!";
                }
                else
                {
                    category_name = txtCategoryName.Text;
                    category_description = txtCategoryDescription.Text;

                    query = "delete from Categories where Id = {0}";
                    query = string.Format(query, gridViewCategoryList.SelectedRow.Cells[1].Text);
                    connection.SetData(query);
                    ShowCategories();
                    lblErrorMessageCategoriesPage.Text = "Category " + category_name + " is deleted!";
                    txtCategoryName.Text = "";
                    txtCategoryDescription.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblErrorMessageCategoriesPage.Text = ex.Message;
            }
        }
    }
}