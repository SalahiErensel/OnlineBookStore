using System;
using System.Data;

namespace OnlineBookStore.Views.Auth
{
    public partial class Login : System.Web.UI.Page
    {
        Models.Functions connection;
        string query;
        DataTable dataTable;

        protected void Page_Load(object sender, EventArgs e)
        {
            connection = new Models.Functions();
        }

        public static string username = "";
        public static int user;

        protected void buttonLogin_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text == "" || txtPassword.Text == "")
            {
                lblAuthenticationError.Text = "Enter Username and Password";
            }
            else if(txtUsername.Text == "Admin@gmail.com" &&  txtPassword.Text == "1234")
            {
                Response.Redirect("~/Views/Admin/Books.aspx");
            }
            else
            {
                query = "Select * from Sellers where SellerEmail = '{0}' and SellerPassword = '{1}'";
                query = string.Format(query, txtUsername.Text,txtPassword.Text);
                dataTable = connection.GetData(query);
                if(dataTable.Rows.Count == 0 ) 
                {
                    Response.Redirect("~/Views/Admin/Books.aspx");
                }
                else
                {
                    username = txtUsername.Text;
                    user = Convert.ToInt32(dataTable.Rows[0][0].ToString());
                    Response.Redirect("~/Views/Seller/Selling.aspx");
                }
            }
        }
    }
}