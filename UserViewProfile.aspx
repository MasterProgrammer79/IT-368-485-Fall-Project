<%@ Page Title="" Language="C#" MasterPageFile="~/LinkedU.Master" AutoEventWireup="true" CodeBehind="UserViewProfile.aspx.cs" Inherits="LinkedU.UserViewProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
               <div class="site full">
            <h1 style="text-align:center">Edit Your Profile Linked<span style="color:#4472c4">U</span> Account</h1>
        </div>
            <div class="site site sign-up-panel-2">
                <div class="sign-up-form">
                    <asp:Panel ID="photouploadPanel" runat="server">
                    <asp:Image ID="ImagePreview" runat="server" ImageUrl="~/images/noprofileimg.png" Height="164px" Width="187px" />
                        <asp:Label ID="userName" runat="server" Font-Bold="true" Font-Size="Large" ></asp:Label>
                     <asp:Label ID="schoolname" runat="server"></asp:Label><br />
                        <table>
                            <tr>
                                <td>
                                    Email Address:</td>
                                    <td>
                                        <asp:Label ID="emailIdlbl" runat="server"></asp:Label></td>
                                
                            </tr>
                            <tr>
                                <td>
                                    Phone Number</td>
                                    <td>
                                        <asp:Label ID="PhoneLbl" runat="server"></asp:Label></td>
                                
                            </tr>
                            <tr>
                                <td>
                                    studentCity</td>
                                    <td>
                                        <asp:Label ID="citylbl" runat="server"></asp:Label></td>
                                
                            </tr>
                        </table>

                        <table>
                            <tr>
                                <td>
                                    Major:</td>
                                    <td>
                                        <asp:Label ID="majorlbl" runat="server"></asp:Label></td>
                                
                            </tr>
                            <tr>
                                <td>
                                    Summary</td>
                                    <td>
                                        <asp:Label ID="summarylbl" runat="server"></asp:Label></td>
                                
                            </tr>
                            <tr>
                                <td>
                                    Field of Study</td>
                                    <td>
                                        <asp:Label ID="fieldofstudylbl" runat="server"></asp:Label></td>
                                
                            </tr>
                            <tr>
                                <td>
                                    Minor</td>
                                    <td>
                                        <asp:Label ID="minorlbl" runat="server"></asp:Label></td>
                                
                            </tr>
                        </table>

                         <table>
                             <tr>
                                <td>
                                    GPA</td>
                                    <td>
                                        <asp:Label ID="gpalbl" runat="server"></asp:Label></td>
                                
                            </tr>
                            <tr>
                                <td>
                                    ACT Score</td>
                                    <td>
                                        <asp:Label ID="actlbl" runat="server"></asp:Label></td>
                                
                            </tr>
                            <tr>
                                <td>
                                    SAT Score</td>
                                    <td>
                                        <asp:Label ID="satlbl" runat="server"></asp:Label></td>
                                
                            </tr>
                            <tr>
                                <td>
                                   PSAT Score</td>
                                    <td>
                                        <asp:Label ID="psatlbl" runat="server"></asp:Label></td>
                                
                            </tr>
                            <tr>
                                <td>
                                    Skills</td>
                                    <td>
                                        <asp:Label ID="skilllbl" runat="server"></asp:Label></td>
                                
                            </tr>
                        </table>
                    </asp:Panel>

                </div>

            </div>
        </div>
</asp:Content>
