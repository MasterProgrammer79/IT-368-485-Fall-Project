<%@ Page Title="" Language="C#" MasterPageFile="~/LinkedU.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="LinkedU.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="site login">
            <div class="login-form">
                <h1>Linked<span style="color:#4472c4">U</span> Login Help</h1>
                <hr />
                <asp:Panel ID="LoginError" runat="server" style="display:none">
                    <div class="alert alert-danger" role="alert">
                        <strong>Error!</strong> Invalid Username!
                    </div>
                </asp:Panel>
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex ="0">
                    <asp:View ID="view1" runat="server">
                <p>
                    New Password:
                    <asp:TextBox ID="Password" TextMode="Password" CssClass="form-control" runat="server" />
                    <asp:RequiredFieldValidator ID="PasswordValidator"
                        ControlToValidate="Password"
                        Display="Dynamic"
                        ErrorMessage="<strong>Please enter a Password!</strong>"
                        ForeColor="Red"
                        runat="server" />
                </p>
                  <p>
                    Confirm Password:
                    <asp:TextBox ID="ConfirmPassword" TextMode="Password" CssClass="form-control" runat="server" />
                    <asp:CompareValidator ID="ComparePasswords"
                        ControlToValidate="Password"
                        ControlToCompare="ConfirmPassword"
                        ErrorMessage="<strong>Passwords Do Not Match!</strong>"
                        ForeColor="Red"
                        style="padding-left:6px"
                        runat="server" />
                </p>
                <asp:Button ID="ChangePasswordBtn" Text="Submit" CssClass="btn btn-primary" style="margin-bottom:10px" runat="server" OnClick="ChangePassword_Click" />
                        </asp:View>
                    <asp:View ID="view2" runat="server">
                <asp:Label ID="OutputLabel1" runat="server" ></asp:Label>
                        </asp:View>
                    </asp:MultiView>
            </div>
        </div>
    </div>
    
</asp:Content>
