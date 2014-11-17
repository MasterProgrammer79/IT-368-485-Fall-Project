<%@ Page Title="" Language="C#" MasterPageFile="~/LinkedU.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="LinkedU.UserProfile" %>
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
                    <asp:FileUpload ID="PhotoUpload" runat="server" CssClass="btn btn-primary"  />
                     <asp:Label ID="choosePhotolbl" runat="server"></asp:Label><br />
                    <asp:Button ID="choosePhoto" runat="server" Text="Save" OnClick="choosePhoto_Click" CssClass="btn btn-primary" />
                    
                    </asp:Panel>

                </div>

            </div>
            <div class="site sign-up-panel-2">
                <div class="sign-up-form">
                    <h2 style="text-align:center">School Information</h2>
                    <hr />
            <asp:Panel ID="profilePanel1" runat="server">
            <table>  
                <tr><td>
            Summary: </td>
               <td> <asp:TextBox ID="summaryTxt" runat="server" TextMode="MultiLine" Height="61px" Width="163px" CssClass="form-control"></asp:TextBox>
           </td></tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="School Name"></asp:Label>
                            </td>
                            <td>
                    <asp:TextBox ID="schoolName" runat="server" CssClass="form-control"></asp:TextBox>
                                </td>
                            </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Field of Study"></asp:Label>
                            </td>
                            <td>
                     <asp:TextBox ID="fieldOfStudy" runat="server" CssClass="form-control"></asp:TextBox>
                            </td></tr>
                        <tr><td>
                                <asp:Label ID="Label3" runat="server" Text="Major"></asp:Label>
                            </td>
                            <td>
                     <asp:TextBox ID="major" runat="server" CssClass="form-control"></asp:TextBox>
                           </td> </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="Minor"></asp:Label>
                            </td>
                            <td>
                    <asp:TextBox ID="minor" runat="server" CssClass="form-control"></asp:TextBox>
                          </td>  </tr>
                    <tr>
                        <asp:Label ID="saveStatus" runat="server"></asp:Label>

                    </tr>
                        </table>
                <asp:Button ID="saveButtonStep1" runat="server" Text="Save" OnClick="saveButtonStep1_Click" CssClass="btn btn-primary" /> 
                <asp:Button ID="NextButton1" runat="server" Text="Next Step" OnClick="NextButton1_Click" CssClass="btn btn-primary" />
                  
            </asp:Panel>
            </div>
        </div>
             </div>
                <asp:Panel ID="OtherInfoPanel" runat="server" style="display:none">
            <div class="site sign-up-panel-2">
                <div class="sign-up-form">
                    <h2 style="text-align:center">Other Information</h2>
                    <hr />
                    <table>  
                <tr><td>
            Cumulative GPA </td>
                <td><asp:TextBox ID="gpaTxt" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
           </td></tr>
                        <tr>
                            <td>
                                ACT Score
                            </td>
                            <td>
                    <asp:TextBox ID="actScoreTxt" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                                </td>
                            </tr>
                        <tr>
                            <td>
                                SAT Score
                            </td>
                            <td>
                     <asp:TextBox ID="satScoreTxt" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                            </td></tr>
                        <tr><td>
                                PSAT Score:
                            </td>
                            <td>
                     <asp:TextBox ID="psatScoreTxt" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                           </td> </tr>
                        <tr>
                            <td>
                                Add Your Skills
                            </td>
                            <td>
                    <asp:TextBox ID="skillsTxt" runat="server"  CssClass="form-control"></asp:TextBox>
                          </td>  </tr>
                    <tr>
                        <asp:Label ID="savestatus2" runat="server"></asp:Label>

                    </tr>
                        </table>
                <asp:Button ID="saveOtherInfobtn" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="saveOtherInfobtn_Click" /> 
                <asp:Button ID="NextButton2" runat="server" Text="Next Step" CssClass="btn btn-primary" OnClick="NextButton2_Click"  />
                     </div>
        </div>
    </asp:Panel>

                        <asp:Panel ID="educationInformation" runat="server" style="display:none">
            <div class="site sign-up-panel-2">
                <div class="sign-up-form">
                    <h2 style="text-align:center">Education Information</h2>
                    <hr />
                    <table>  
                        <tr>
                            <td>
                                Universities of Choice
                            </td>
                            <td>
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
                                </td>
                            
                            </tr>
                        
                           <%-- <tr> <td runat="server">
                                <asp:Panel ID="pnlTextBoxes" runat="server">
                                </asp:Panel>
                                <%--<asp:PlaceHolder ID="phTextBoxes" runat="server">
                                </asp:PlaceHolder>  </td>
                           
                           
                        </tr>
                        <tr><td><asp:Button ID="AddTextBox" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="AddTextBox_Click"  /></td></tr>  --%>
                            <tr>
                            <td>
                                Majors of Choice
                            </td>
                            <td>
                     <asp:TextBox ID="TextBox3" runat="server"  CssClass="form-control"></asp:TextBox>
                            </td></tr>
                        <tr><td>
                                Essay of Choice
                            </td>
                            <td>
                                <asp:FileUpload ID="EsaayOfChoiceUpload" runat="server" />
                           </td>
                            <td><asp:Label ID="lblEsaayMessage" runat="server"></asp:Label></td>

                        </tr>
                        <tr>
                            <td>
                                Mix Tape of Activities
                            </td>
                            <td>
                             <asp:FileUpload ID="uploadVideo" runat="server" />
                          </td>  </tr>
                    <tr>
                        <asp:Label ID="Label5" runat="server"></asp:Label>

                    </tr>
                        </table>
                <asp:Button ID="Save3" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="Save3_Click" /> 
                <asp:Button ID="Finish" runat="server" Text="Next Step" CssClass="btn btn-primary" OnClick="NextButton2_Click"  />
                     </div>
        </div>
    </asp:Panel>
           
</asp:Content>
