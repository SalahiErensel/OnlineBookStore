<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Seller/SellerMaster.Master" AutoEventWireup="true" CodeBehind="Selling.aspx.cs" Inherits="OnlineBookStore.Views.Seller.Selling" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function printBill() {
            var PGrid = document.getElementById('<%=gridViewClientBillSellerPage.ClientID%>');
            PGrid.bordr = 0;
            var PWin = window.open('', 'PrintGrid', 'left=100, top=100, width = 1024, height=768, tollbar = 0, scrollbars = 1, status = 0, resizable = 1');
            PWin.document.write(PGrid.outerHTML);
            PWin.document.close();
            Pwin.focus();
            Pwin.print();
            Pwin.close();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">
    <div class="container-fluid">
        <div class="row">
        </div>
        <div class="row">
            <div class="col-md-5">
                <h3 class="text-center">Book Details</h3>
                <div class="row">
                    <div class="col">
                        <div class="mb-3 mt-3">
                            <asp:Label ID="lblBookName" runat="server" Text="Book Name" CssClass="form-label" Font-Size="X-Large"></asp:Label>
                        </div>
                        <asp:TextBox ID="txtBookName" runat="server" placeholder="Book Name" CssClass="form-control" Font-Size="X-Large"></asp:TextBox>
                    </div>
                    <div class="col">
                        <div class="mb-3 mt-3">
                            <asp:Label ID="lblBookPrice" runat="server" Text="Book Price" CssClass="form-label" Font-Size="X-Large"></asp:Label>
                        </div>
                        <asp:TextBox ID="txtBookPrice" runat="server" placeholder="Book Price" CssClass="form-control" Font-Size="X-Large"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <div class="mb-3 mt-3">
                            <asp:Label ID="lblBookQuantity" runat="server" Text="Book Quantity" CssClass="form-label" Font-Size="X-Large"></asp:Label>
                        </div>
                        <asp:TextBox ID="txtBookQuantity" runat="server" placeholder="Book Quantity" CssClass="form-control" Font-Size="X-Large"></asp:TextBox>
                    </div>
                </div>
                <div class="row mt-4">
                    <div class="col d-grid">
                        <asp:Button ID="btnAddToBill" runat="server" Text="Add To Bill" CssClass="btn-primary btn-block btn" OnClick="btnAddToBill_Click" />
                        <asp:Label ID="lblErrorMessage3" runat="server" CssClass="form-label text-danger" Font-Size="X-Large"></asp:Label>
                    </div>
                </div>
                <div class="row mt-5">
                    <h4 class="text-center">Book List</h4>
                    <div class="col">
                        <asp:GridView ID="gridViewBookListSellerPage" runat="server" CssClass="table table-bordered" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gridViewBookListSellerPage_SelectedIndexChanged"></asp:GridView>
                    </div>
                </div>
            </div>
            <div class="col-md-7">
                <h4 class="text-center">Client Bill</h4>
                <div class="col">
                    <asp:GridView ID="gridViewClientBillSellerPage" runat="server" CssClass="table table-bordered" AutoGenerateSelectButton="True"></asp:GridView>
                    <div class="d-grid">
                        <asp:Label ID="lblErrorMessageSellingPage" runat="server" CssClass="form-label text-danger" Font-Size="X-Large"></asp:Label>
                        <asp:Button ID="btnPrintBillSellerPage" runat="server" Text="Print" OnClientClick="printBill()" CssClass="btn-primary btn-block btn" OnClick="btnPrintBillSellerPage_Click" />
                        <asp:Label ID="lblErrorMessage2" runat="server" CssClass="form-label text-danger" Font-Size="X-Large"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
