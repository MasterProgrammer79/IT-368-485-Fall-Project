<%@ Page Title="" Language="C#" MasterPageFile="~/LinkedU.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LinkedU.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Home Page</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:Panel ID="PanelWelcome" runat="server">
        <div class="full site">
            <h1 style="text-align:center">Welcome to LinkedU!</h1>
            <p>Please browse around our website. Check out the various Student and Recruiter profiles. Sign up for an account, or login if you are an existing user.</p>
        </div>
            </asp:Panel>
       
       <div class="container" style="padding-left:250px" >
        <div class="site login" style="margin-left:670px; width:250px">
      
        <asp:Panel ID="RequestForInfo" runat="server"  style="display:none">
                    <div class="alert alert-danger" role="alert" style="height:100px">
                        <asp:Label ID="RequestLabel" runat="server" Text="Label"></asp:Label>
                          <asp:Button ID="AcceptButton" runat="server" Text="Accept" CssClass="btn btn-primary"  style="float:left" OnClick="accept_Click" />
                          <asp:Button ID="DeleteButton" runat="server" Text="Delete" CssClass="btn btn-primary"  style="float:right" OnClick="delete_Click" />
                    </div>
                </asp:Panel>
             
            <asp:Panel ID="Descritionofrequest" runat="server"  style="display:none">
                    <div class="alert alert-danger" role="alert">
                        <asp:Label ID="Description" runat="server" Text="Label"></asp:Label><br />
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </div>
                </asp:Panel>
           
            </div></div>
    </div>
</asp:Content>
