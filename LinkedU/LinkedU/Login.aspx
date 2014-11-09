<%@ Page Title="" Language="C#" MasterPageFile="~/LinkedU.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LinkedU.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Login</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="site login">
            <div class="login-form">
                <h1>Linked <span style="color:#4472c4">U</span> Login</h1>
                <hr>
                <asp:Panel ID="LoginError" runat="server" style="display:none">
                    <div class="alert alert-danger" role="alert">
                        <asp:Label ID="ErrorMessage" runat="server" />
                    </div>
                </asp:Panel>
                <asp:Panel ID="LoginSuccess" runat="server" style="display:none">
                    <div class="alert alert-success" role="alert">
                        <asp:Label ID="SuccessMessage" runat="server" />
                    </div>
                </asp:Panel>
                <p>
                    Username:
                    <asp:TextBox ID="Username" runat="server" />
                    <asp:RequiredFieldValidator ID="UserValidator"
                        ControlToValidate="Username"
                        Display="Dynamic"
                        ErrorMessage="Please enter a Username!"
                        ForeColor="Red"
                        runat="server" />
                </p>
                <p>
                    Password:
                    <asp:TextBox ID="Password" runat="server" TextMode="Password" />
                    <asp:RequiredFieldValidator ID="PasswordValidator"
                        ControlToValidate="Password"
                        Display="Dynamic"
                        ErrorMessage="Please enter a Password!"
                        ForeColor="Red"
                        runat="server" />
                </p>
                <asp:Button ID="UserLogin" runat="server" Text="Login" OnClick="UserLogin_Click" />
            </div>
        </div>
    </div>
</asp:Content>
