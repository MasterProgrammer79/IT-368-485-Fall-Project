<%@ Page Title="" Language="C#" MasterPageFile="~/LinkedU.Master" AutoEventWireup="true" CodeBehind="LostPassword.aspx.cs" Inherits="LinkedU.LostPassword" %>
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
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View1" runat="server">
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
            
                <asp:Button ID="UserLogin" Text="Submit" CssClass="btn btn-primary" style="margin-bottom:10px" runat="server" OnClick="UserLogin_Click" />
               </asp:View>
                <asp:View ID="View2" runat="server">
                    <asp:Label ID="OutputLabel" runat="server" ></asp:Label>
                </asp:View>
                </asp:MultiView>

            </div>
        </div>
    </div>
</asp:Content>
