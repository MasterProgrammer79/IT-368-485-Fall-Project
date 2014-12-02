<%@ Page Title="" Language="C#" MasterPageFile="~/LinkedU.Master" AutoEventWireup="true" CodeBehind="AdminDelete.aspx.cs" Inherits="LinkedU.AdminDelete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="site sign-up-panel-2">
                <div class="sign-up-form">
    <asp:Panel runat="server">

        Are u sure u want to delete "
        <asp:Literal ID="deleteUniversity" runat="server" />" ?
        <br />
        <asp:Button ID="Button1" runat="server" Text="Yes" OnClick="Button1_Click" /> &nbsp;  &nbsp; 
        <asp:Button ID="Button2" runat="server" Text="No" OnClick="Button2_Click" /><br /><br />
        <asp:Literal ID="results" runat="server"></asp:Literal>
    </asp:Panel>
                    </div>
        </div>
</asp:Content>
