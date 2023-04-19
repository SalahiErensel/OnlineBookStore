<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OnlineBookStore.Views.Auth.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" href="../../Assets/Libs/css/bootstrap.min.css" />
</head>
<body>
    <div class="container-fluid">
        <div class="row mt-5 mb-5">
        </div>
        <div class="row">
            <div class="col">
            </div>
            <div class="col">
                <form id="form1" runat="server">
                    <div class="text-center">
                        <asp:Image ID="imageBook" runat="server" ImageUrl="~/Assets/Images/Book.JPG" />
                    </div>
                    <div class="mb-3 mt-3">
                        <asp:Label ID="lblUsername" runat="server" Text="Username" CssClass="form-label" Font-Size="X-Large"></asp:Label>
                    </div>
                    <asp:TextBox ID="txtUsername" runat="server" placeholder="Username" CssClass="form-control" Font-Size="X-Large"></asp:TextBox>
                    <div>
                        <div class="mb-3 mt-3">
                            <asp:Label ID="lblPassword" runat="server" Text="Password" CssClass="form-label" Font-Size="X-Large"></asp:Label>
                        </div>
                        <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" CssClass="form-control" Font-Size="X-Large" TextMode="Password"></asp:TextBox>
                    </div>
                    <asp:Label ID="lblAuthenticationError" runat="server" CssClass="text-danger" Font-Size="X-Large"></asp:Label>
                    <div class="mb-3 mt-3 d-grid">
                        <asp:Button ID="buttonLogin" runat="server" Text="Login" CssClass="btn btn-primary" Font-Size="X-Large" OnClick="buttonLogin_Click" />
                    </div>
                </form>
            </div>
            <div class="col">
            </div>
        </div>
    </div>
</body>
</html>
