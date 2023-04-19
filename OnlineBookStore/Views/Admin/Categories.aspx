<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="OnlineBookStore.Views.Admin.Categories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">
        <div class="container-fluid">
        <div class="row">
            <div class="col">
                <h3 class="text-center">Manage Categories</h3>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <div class="mb-3 mt-3">
                        <asp:Label ID="lblCategoryName" runat="server" Text="Category Name" CssClass="form-label" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                        <asp:TextBox ID="txtCategoryName" runat="server" placeholder="Category Name" CssClass="form-control" Font-Size="X-Large"></asp:TextBox>
                    </div>
                    <br />
                    <div class="mb-3 mt-3">
                        <asp:Label ID="lblCategoryDescription" runat="server" Text="Category Description" CssClass="form-label" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                       <asp:TextBox ID="txtCategoryDescription" runat="server" placeholder="Category Description" CssClass="form-control" Font-Size="X-Large"></asp:TextBox>
                    </div>
                    <br />
                    <div class="row">
                        <asp:Label runat="server" ID="lblErrorMessageCategoriesPage" CssClass="text-danger"></asp:Label>
                        <div class="col d-grid">
                            <asp:Button ID="btnUpdateBooksPage" runat="server" Text="Update" CssClass="btn-secondary btn-block btn" OnClick="btnUpdateBooksPage_Click" />
                        </div>
                        <div class="col d-grid">
                            <asp:Button ID="btnSaveBooksPage" runat="server" Text="Save" CssClass="btn-primary btn-block btn" OnClick="btnSaveBooksPage_Click" />
                        </div>
                        <div class="col d-grid">
                            <asp:Button ID="btnDeleteBooksPage" runat="server" Text="Delete" CssClass="btn-danger btn-block btn" OnClick="btnDeleteBooksPage_Click" />
                        </div>
                    </div>
                </div>
                <div class="col-md-8">
                    <asp:GridView ID="gridViewCategoryList" CssClass="table table-bordered" AutoGenerateSelectButton="True" runat="server" OnSelectedIndexChanged="gridViewCategoryList_SelectedIndexChanged"></asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
