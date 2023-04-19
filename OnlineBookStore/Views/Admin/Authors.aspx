<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Authors.aspx.cs" Inherits="OnlineBookStore.Views.Admin.Authors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col">
                <h3 class="text-center">Manage Authors</h3>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <div class="mb-3 mt-3">
                        <asp:Label ID="lblAuthorName" runat="server" Text="Author Name" CssClass="form-label" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                        <asp:TextBox ID="txtAuthorName" runat="server" placeholder="Author Name" CssClass="form-control" Font-Size="X-Large"></asp:TextBox>
                    </div>
                    <br />
                    <div class="mb-3 mt-3">
                        <asp:Label ID="lblAuthorGender" runat="server" Text="Author Gender" CssClass="form-label" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                        <asp:DropDownList ID="dropDownListAuthorGender" runat="server" CssClass="form-control" Font-Size="X-Large">
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <br />
                    <div class="mb-3 mt-3">
                        <asp:Label ID="lblAuthorCountry" runat="server" Text="Country" CssClass="form-label" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                        <asp:DropDownList ID="dropDownListAuthorCountries" runat="server" CssClass="form-control" Font-Size="X-Large">
                            <asp:ListItem Value="Cyprus" Text="Cyprus"></asp:ListItem>
                            <asp:ListItem Value="Turkey" Text="Turkey"></asp:ListItem>
                            <asp:ListItem Value="England" Text="England"></asp:ListItem>
                            <asp:ListItem Value="France" Text="France"></asp:ListItem>
                            <asp:ListItem Value="Spain" Text="Spain"></asp:ListItem>
                            <asp:ListItem Value="Other" Text="Other"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <br />
                    <div class="row">
                        <asp:Label runat="server" ID="lblErrorMessageAuthorsPage" CssClass="text-danger"></asp:Label>
                        <div class="col d-grid">
                            <asp:Button ID="btnUpdateAuthorsPage" runat="server" Text="Update" CssClass="btn-secondary btn-block btn" OnClick="btnUpdateAuthorsPage_Click" />
                        </div>
                        <div class="col d-grid">
                            <asp:Button ID="btnSaveAuthorsPage" runat="server" Text="Save" CssClass="btn-primary btn-block btn" OnClick="btnSaveAuthorsPage_Click" />
                        </div>
                        <div class="col d-grid">
                            <asp:Button ID="btnDeleteAuthorsPage" runat="server" Text="Delete" CssClass="btn-danger btn-block btn" OnClick="btnDeleteAuthorsPage_Click" />
                        </div>
                    </div>
                </div>
                <div class="col-md-8">
                    <asp:GridView ID="gridViewAuthorsList" CssClass="table table-bordered" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gridViewAuthorsList_SelectedIndexChanged"></asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>