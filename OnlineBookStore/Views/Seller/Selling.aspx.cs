using OnlineBookStore.Views.Auth;
using System;
using System.Data;

namespace OnlineBookStore.Views.Seller
{
    public partial class Selling : System.Web.UI.Page
    {
        Models.Functions connection;
        string query;
        int key = 0;
        int stock = 0;
        int total = 0;
        int grid_total = 0;
        int amount = 0;
        int seller = Login.user;
        string seller_name = Login.username;
        int new_quantity;

        protected void Page_Load(object sender, EventArgs e)
        {
            connection = new Models.Functions();

            if (!IsPostBack)
            {
                showBooks();
                DataTable dataTable = new DataTable();
                dataTable.Columns.AddRange(new DataColumn[5]
                {
                     new DataColumn("ID"),
                     new DataColumn("Book"),
                     new DataColumn("Price"),
                     new DataColumn("Quantity"),
                     new DataColumn("Total")
                });
                ViewState["Bill"] = dataTable;
                this.BindGrid();
            }
        }

        protected void BindGrid()
        {
            gridViewClientBillSellerPage.DataSource = ViewState["Bill"];
            gridViewClientBillSellerPage.DataBind();
        }

        private void showBooks()
        {
            query = "Select Id as Code,BookName as Name, BookQuantity as Stock, BookPrice as Price from Books";
            gridViewBookListSellerPage.DataSource = connection.GetData(query);
            gridViewBookListSellerPage.DataBind();
        }

        protected void gridViewBookListSellerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBookName.Text = gridViewBookListSellerPage.SelectedRow.Cells[2].Text;
            stock = Convert.ToInt32(gridViewBookListSellerPage.SelectedRow.Cells[3].Text);
            txtBookQuantity.Text = stock.ToString();
            txtBookPrice.Text = gridViewBookListSellerPage.SelectedRow.Cells[4].Text;

            if (txtBookName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(gridViewBookListSellerPage.SelectedRow.Cells[1].Text);
            }
        }

        private void updateStock()
        {
            new_quantity = Convert.ToInt32(gridViewBookListSellerPage.SelectedRow.Cells[3].Text) - Convert.ToInt32(txtBookQuantity.Text);
            query = "update Books set BookQuantity = '{0}' where Id = {1}";
            query = string.Format(query, new_quantity, gridViewBookListSellerPage.SelectedRow.Cells[1].Text);
            connection.SetData(query);
            showBooks();
        }

        private void insertBill()
        {
            try
            {
                query = "Insert into Bill values ('{0}','{1}','{2}')";
                query = string.Format(query, DateTime.Today.Date.ToString("yyy-MM-dd"), seller, amount);
                connection.SetData(query);
                lblErrorMessage2.Text = "Bill Added!"; 
            }
            catch(Exception ex)
            {
                lblErrorMessage2.Text = ex.Message;
            }
        }

        protected void btnAddToBill_Click(object sender, EventArgs e)
        {
            if(txtBookName.Text == "" || txtBookPrice.Text == "" || txtBookQuantity.Text == "")
            {
                lblErrorMessage3.Text = "Please Select a Book!";
            }
            else
            {
                total = Convert.ToInt32(txtBookQuantity.Text) * Convert.ToInt32(txtBookPrice.Text);
                DataTable dataTable = (DataTable)ViewState["Bill"];
                dataTable.Rows.Add(gridViewClientBillSellerPage.Rows.Count + 1, txtBookName.Text.Trim(),
                    txtBookPrice.Text.Trim(), txtBookQuantity.Text.Trim(), total);
                ViewState["Bill"] = dataTable;
                this.BindGrid();
                updateStock();
                for (int i = 0; i < gridViewClientBillSellerPage.Rows.Count - 1; i++)
                {
                    grid_total = grid_total + Convert.ToInt32(gridViewBookListSellerPage.SelectedRow.Cells[3].Text);
                }
                amount = grid_total;
                lblErrorMessageSellingPage.Text = grid_total.ToString() + "TL";
                txtBookName.Text = "";
                txtBookPrice.Text = "";
                txtBookQuantity.Text = "";
                grid_total = 0;
            }          
        }

        protected void btnPrintBillSellerPage_Click(object sender, EventArgs e)
        {
            insertBill();
        }
    }
}