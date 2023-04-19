<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="OnlineBookStore.Views.Admin.Books" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col">
                <h3 class="text-center">Manage Books</h3>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <div class="mb-3 mt-3">
                        <asp:Label ID="lblBookTitle" runat="server" Text="Book Title" CssClass="form-label" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                        <asp:TextBox ID="txtBookTitle" runat="server" placeholder="Book Title" CssClass="form-control" Font-Size="X-Large"></asp:TextBox>
                    </div>
                    <br />
                    <div class="mb-3 mt-3">
                        <asp:Label ID="lblBookAuthor" runat="server" Text="Book Author" CssClass="form-label" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                        <asp:DropDownList ID="dropDownListAuthors" runat="server" CssClass="form-control" Font-Size="Large"></asp:DropDownList>
                    </div>
                    <br />
                    <div class="mb-3 mt-3">
                        <asp:Label ID="lblCategories" runat="server" Text="Categories" CssClass="form-label" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                        <asp:DropDownList ID="dropDownListCategories" runat="server" CssClass="form-control" Font-Size="Large"></asp:DropDownList>
                    </div>
                    <br />
                    <div class="mb-3 mt-3">
                        <asp:Label ID="lblQuantity" runat="server" Text="Quantity" CssClass="form-label" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                        <asp:TextBox ID="txtBookQuantity" runat="server" placeholder="Quantity" CssClass="form-control" Font-Size="X-Large"></asp:TextBox>
                    </div>
                    <br />
                    <div class="mb-3 mt-3">
                        <asp:Label ID="lblBookPrice" runat="server" Text="Book Price" CssClass="form-label" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                        <asp:TextBox ID="txtBookPrice" runat="server" placeholder="Book Price" CssClass="form-control" Font-Size="X-Large"></asp:TextBox>
                    </div>
                    <div class="row">
                        <asp:Label runat="server" ID="lblErrorMessageBooksPage" CssClass="text-danger"></asp:Label>
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
                    <asp:GridView ID="gridViewBooksList" CssClass="table table-bordered" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gridViewBooksList_SelectedIndexChanged"></asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>