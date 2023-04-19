<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Sellers.aspx.cs" Inherits="OnlineBookStore.Views.Admin.Seller" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col">
                <h3 class="text-center">Manage Sellers</h3>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <div class="mb-3 mt-3">
                        <asp:Label ID="lblSellerName" runat="server" Text="Seller Name" CssClass="form-label" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                        <asp:TextBox ID="txtSellerName" runat="server" placeholder="Seller Name" CssClass="form-control" Font-Size="X-Large"></asp:TextBox>
                    </div>
                    <br />
                    <div class="mb-3 mt-3">
                        <asp:Label ID="lblSellerEmail" runat="server" Text="Seller Email" CssClass="form-label" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                        <asp:TextBox ID="txtSellerEmail" runat="server" placeholder="Seller Email" CssClass="form-control" Font-Size="X-Large" type="email"></asp:TextBox>
                    </div>
                    <br />
                    <div class="mb-3 mt-3">
                        <asp:Label ID="lblSellerPhone" runat="server" Text="Seller Phone" CssClass="form-label" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                        <asp:TextBox ID="txtSellerPhone" runat="server" placeholder="Seller Phone" CssClass="form-control" Font-Size="X-Large" type="phone"></asp:TextBox>
                    </div>
                    <br />
                    <div class="mb-3 mt-3">
                        <asp:Label ID="lblSellerPassword" runat="server" Text="Seller Password" CssClass="form-label" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                        <asp:TextBox ID="txtSellerPassword" runat="server" placeholder="Seller Password" CssClass="form-control" Font-Size="X-Large" TextMode="Password"></asp:TextBox>
                    </div>
                    <br />
                    <div class="row">
                        <asp:Label runat="server" ID="lblErrorMessageSellersPage" CssClass="text-danger"></asp:Label>
                        <div class="col d-grid">
                            <asp:Button ID="btnUpdateSellersPage" runat="server" Text="Update" CssClass="btn-secondary btn-block btn" OnClick="btnUpdateSellersPage_Click" />
                        </div>
                        <div class="col d-grid">
                            <asp:Button ID="btnSaveSellersPage" runat="server" Text="Save" CssClass="btn-primary btn-block btn" OnClick="btnSaveSellersPage_Click" />
                        </div>
                        <div class="col d-grid">
                            <asp:Button ID="btnDeleteSellersPage" runat="server" Text="Delete" CssClass="btn-danger btn-block btn" OnClick="btnDeleteSellersPage_Click" />
                        </div>
                    </div>
                </div>
                <div class="col-md-8 mt-3">
                    <asp:GridView ID="gridViewSellersList" runat="server" CssClass="table table-bordered" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gridViewSellerList_SelectedIndexChanged"></asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
