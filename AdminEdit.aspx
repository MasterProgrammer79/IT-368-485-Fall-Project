<%@ Page Title="" Language="C#" MasterPageFile="~/LinkedU.Master" AutoEventWireup="true" CodeBehind="AdminEdit.aspx.cs" Inherits="LinkedU.AdminEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="site site sign-up-panel-2">
                <div class="sign-up-form">
                    <asp:Panel ID="photouploadPanel" runat="server">
                    <asp:Image ID="ImagePreview" runat="server"  Height="200px" Width="250px" />    
                        </asp:Panel>
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                </div>

            </div>
    <div class="site sign-up-panel-2">
                <div class="sign-up-form">
                    
            <asp:Panel ID="profilePanel1" runat="server">
            <table>  
               
                        <tr>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="School Name"></asp:Label>
                            </td>
                            <td>
                    <asp:TextBox ID="schoolName" runat="server" CssClass="form-control"></asp:TextBox>
                                </td>
                            </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text="Rank"></asp:Label>
                            </td>
                            <td>
                     <asp:TextBox ID="rank" runat="server" CssClass="form-control"></asp:TextBox>
                            </td></tr>
                        <tr><td>
                                <asp:Label ID="Label7" runat="server" Text="City"></asp:Label>
                            </td>
                            <td>
                     <asp:TextBox ID="city" runat="server" CssClass="form-control"></asp:TextBox>
                           </td> </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label8" runat="server" Text="State"></asp:Label>
                            </td>
                            <td>
                    <asp:TextBox ID="state" runat="server" CssClass="form-control"></asp:TextBox>
                          </td>  </tr>
                <tr>
                            <td>
                                <asp:Label ID="Label9" runat="server" Text="Description"></asp:Label>
                            </td>
                            <td>
                    <asp:TextBox ID="description" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                          </td>  </tr>
                    <tr>
                            <td>
                                <asp:Label ID="Label10" runat="server" Text="Website"></asp:Label>
                            </td>
                            <td>
                    <asp:TextBox ID="website" runat="server" CssClass="form-control"></asp:TextBox>
                          </td>  </tr>
                <tr>
                            <td>
                                <asp:Label ID="Label11" runat="server" Text="AppDeadline"></asp:Label>
                            </td>
                            <td>
                    <asp:TextBox ID="deadline" runat="server" CssClass="form-control"></asp:TextBox>
                          </td>  </tr>
                <tr>
                            <td>
                                <asp:Label ID="Label12" runat="server" Text="Address"></asp:Label>
                            </td>
                            <td>
                    <asp:TextBox ID="address" runat="server" CssClass="form-control"></asp:TextBox>
                          </td>  </tr>
                <tr>
                            <td>
                                <asp:Label ID="Label13" runat="server" Text="PhoneNumber"></asp:Label>
                            </td>
                            <td>
                    <asp:TextBox ID="phone" runat="server" CssClass="form-control"></asp:TextBox>
                          </td>  </tr>

                    <tr>
                        <asp:Label ID="saveStatus" runat="server"></asp:Label>

                    </tr>
                        </table>
                <asp:Button ID="updateButton" runat="server" Text="Update" OnClick="updateButton_Click" CssClass="btn btn-primary" /> 
                
            </asp:Panel>
            </div>
            </div>


</asp:Content>
