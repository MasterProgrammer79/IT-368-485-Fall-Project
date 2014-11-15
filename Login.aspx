<%@ Page Title="" Language="C#" MasterPageFile="~/LinkedU.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LinkedU.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Login to your LinkedU Account</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="site login">
            <div class="login-form">
                <h1>Linked<span style="color:#4472c4">U</span> Login</h1>
                <hr />
                <asp:Panel ID="LoginError" runat="server" style="display:none">
                    <div class="alert alert-danger" role="alert">
                        <strong>Error!</strong> Invalid Username / Password Combination!
                    </div>
                </asp:Panel>
                <p>
                    Username:
                    <asp:TextBox ID="Username" CssClass="form-control" runat="server" />
                    <asp:RequiredFieldValidator ID="UserValidator"
                        ControlToValidate="Username"
                        Display="Dynamic"
                        ErrorMessage="<strong>Please enter a Username!</strong>"
                        ForeColor="Red"
                        runat="server" />
                </p>
                <p>
                    Password:
                    <asp:TextBox ID="Password" TextMode="Password" CssClass="form-control" runat="server" />
                    <asp:RequiredFieldValidator ID="PasswordValidator"
                        ControlToValidate="Password"
                        Display="Dynamic"
                        ErrorMessage="<strong>Please enter a Password!</strong>"
                        ForeColor="Red"
                        runat="server" />
                </p>
                <asp:Button ID="UserLogin" Text="Login" CssClass="btn btn-primary" style="margin-bottom:10px" runat="server" OnClick="UserLogin_Click" />
            </div>
        </div>
    </div>
</asp:Content>
