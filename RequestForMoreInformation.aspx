<%@ Page Title="" Language="C#" MasterPageFile="~/LinkedU.Master" AutoEventWireup="true" CodeBehind="RequestForMoreInformation.aspx.cs" Inherits="LinkedU.RequestForMoreInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="container">
        <div class="site login">
            <div class="login-form">
                <h1>Linked<span style="color:#4472c4">U</span> Request Form</h1>
                <hr />
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex ="0">
                    <asp:View ID="view1" runat="server">
                  <p>
                    Your Name:
                    <asp:TextBox ID="FromUserTextbox" CssClass="form-control" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                        ControlToValidate="FromUserTextbox"
                        Display="Dynamic"
                        ErrorMessage="<strong>Please enter a Username!</strong>"
                        ForeColor="Red"
                        runat="server" />
                </p>
            

                 <p>
                    Description :
                    <asp:TextBox ID="DescriptionTextbox" CssClass="form-control" runat="server" TextMode="MultiLine" />
                    <asp:RequiredFieldValidator ID="UserValidator"
                        ControlToValidate="DescriptionTextbox"
                        Display="Dynamic"
                        ErrorMessage="<strong>Please enter a Username!</strong>"
                        ForeColor="Red"
                        runat="server" />
                </p>
                <p>
                    (Please provide detail description about your requirements )</p>
            
                <asp:Button ID="RequestSubmit" Text="Submit Request" CssClass="btn btn-primary" style="margin-bottom:10px" runat="server" OnClick="requestSubmit_Click" />
                    </asp:View>

                    <asp:View ID="view2" runat="server">
                        <asp:Label ID="RequestOutputLabel" runat="server" ></asp:Label>
                    </asp:View>
                    </asp:MultiView>
            </div>

               </div>
             </div>
</asp:Content>
