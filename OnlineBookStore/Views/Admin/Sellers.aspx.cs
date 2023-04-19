using System;

namespace OnlineBookStore.Views.Admin
{
    public partial class Seller : System.Web.UI.Page
    {
        //variables
        int key = 0;
        string query;
        string seller_name;
        string seller_email;
        string seller_phone;
        string seller_password;
        Models.Functions connection;

        protected void Page_Load(object sender, EventArgs e)
        {
            connection = new Models.Functions();
            ShowSellers();
        }

        private void ShowSellers()
        {
            query = "SELECT * from Sellers";
            gridViewSellersList.DataSource = connection.GetData(query);
            gridViewSellersList.DataBind();
        }

        protected void btnSaveSellersPage_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSellerName.Text == "" || txtSellerEmail.Text == "" || txtSellerPhone.Text == "" || txtSellerPassword.Text == "")
                {
                    lblErrorMessageSellersPage.Text = "Please Fill All Fields!";
                }
                else
                {
                    seller_name = txtSellerName.Text;
                    seller_email = txtSellerEmail.Text;
                    seller_phone = txtSellerPhone.Text;
                    seller_password = txtSellerPassword.Text;

                    query = "insert into Sellers values('{0}','{1}','{2}','{3}')";
                    query = string.Format(query, seller_name, seller_email, seller_phone, seller_password);
                    connection.SetData(query);
                    ShowSellers();
                    lblErrorMessageSellersPage.Text = "Seller " + seller_name + " is inserted!";
                    txtSellerName.Text = "";
                    txtSellerEmail.Text = "";
                    txtSellerPhone.Text = "";
                    txtSellerPassword.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblErrorMessageSellersPage.Text = ex.Message;
            }
        }

        protected void gridViewSellerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSellerName.Text = gridViewSellersList.SelectedRow.Cells[2].Text;
            txtSellerEmail.Text = gridViewSellersList.SelectedRow.Cells[3].Text;
            txtSellerPhone.Text = gridViewSellersList.SelectedRow.Cells[4].Text;
            txtSellerPassword.Text = gridViewSellersList.SelectedRow.Cells[5].Text;

            if (txtSellerName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(gridViewSellersList.SelectedRow.Cells[1].Text);
            }
        }

        protected void btnUpdateSellersPage_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSellerName.Text == "" || txtSellerEmail.Text == "" || txtSellerPhone.Text == "" || txtSellerPassword.Text == "")
                {
                    lblErrorMessageSellersPage.Text = "Please Fill All Fields!";
                }
                else
                {
                    seller_name = txtSellerName.Text;
                    seller_email = txtSellerEmail.Text;
                    seller_phone = txtSellerPhone.Text;
                    seller_password = txtSellerPassword.Text;

                    query = "update Sellers set SellerName = '{0}', SellerEmail = '{1}', SellerPhone = '{2}', SellerPassword = '{3}' where Id = {4}";
                    query = string.Format(query, seller_name, seller_email, seller_phone, seller_password, gridViewSellersList.SelectedRow.Cells[1].Text);
                    connection.SetData(query);
                    ShowSellers();
                    lblErrorMessageSellersPage.Text = "Seller " + seller_name + " is updated!";
                    txtSellerName.Text = "";
                    txtSellerEmail.Text = "";
                    txtSellerPhone.Text = "";
                    txtSellerPassword.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblErrorMessageSellersPage.Text = ex.Message;
            }
        }

        protected void btnDeleteSellersPage_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSellerName.Text == "" || txtSellerEmail.Text == "" || txtSellerPhone.Text == "" || txtSellerPassword.Text == "")
                {
                    lblErrorMessageSellersPage.Text = "Please Select Seller!";
                }
                else
                {
                    seller_name = txtSellerName.Text;
                    seller_email = txtSellerEmail.Text;
                    seller_phone = txtSellerPhone.Text;
                    seller_password = txtSellerPassword.Text;

                    query = "delete from Sellers where Id = {0}";
                    query = string.Format(query, gridViewSellersList.SelectedRow.Cells[1].Text);
                    connection.SetData(query);
                    ShowSellers();
                    lblErrorMessageSellersPage.Text = "Seller " + seller_name + " is deleted!";
                    txtSellerName.Text = "";
                    txtSellerEmail.Text = "";
                    txtSellerPhone.Text = "";
                    txtSellerPassword.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblErrorMessageSellersPage.Text = ex.Message;
            }
        }
    }
}