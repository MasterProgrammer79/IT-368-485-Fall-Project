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
                <tr style="padding-bottom:20px"><td>
            Summary: </td>
               <td> <asp:TextBox ID="summaryTxt" runat="server" TextMode="MultiLine" Height="61px" Width="163px" CssClass="form-control"></asp:TextBox>
           </td>
                   <%-- <td><asp:RequiredFieldValidator ID="UserValidator"
                        ControlToValidate="summaryTxt"
                        Display="Dynamic"
                        ErrorMessage="<strong>Required!</strong>"
                        ForeColor="Red"
                        style="padding-left:6px"
                        runat="server" /></td>--%>
                </tr>
                        <tr style="padding-bottom:20px">
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="School Name"></asp:Label>
                            </td>
                            <td style="padding-bottom:20px">
                    <asp:TextBox ID="schoolName" runat="server" CssClass="form-control"></asp:TextBox>
                                </td>
                           <%-- <td><asp:RequiredFieldValidator ID="schoolNameRfv"
                        ControlToValidate="schoolName"
                        Display="Dynamic"
                        ErrorMessage="<strong>Required!</strong>"
                        ForeColor="Red"
                        style="padding-left:6px"
                        runat="server" /></td>--%>
                            </tr>
                        <tr style="padding-bottom:20px">
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Field of Study"></asp:Label>
                            </td>
                            <td style="padding-bottom:20px">
                     <asp:TextBox ID="fieldOfStudy" runat="server" CssClass="form-control"></asp:TextBox>
                            </td></tr>
                        <tr ><td>
                                <asp:Label ID="Label3" runat="server" Text="Major"></asp:Label>
                            </td>
                            <td style="padding-bottom:20px">
                     <asp:TextBox ID="major" runat="server" CssClass="form-control"></asp:TextBox>
                           </td> </tr>
                        <tr style="padding-bottom:20px">
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="Minor"></asp:Label>
                            </td>
                            <td style="padding-bottom:20px">
                    <asp:TextBox ID="minor" runat="server" CssClass="form-control"></asp:TextBox>
                          </td>  </tr>
                    <tr style="padding-bottom:20px">
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
                <tr style="padding-bottom:20px" ><td>
            Cumulative GPA </td>
                <td style="padding-bottom:20px"><asp:TextBox ID="gpaTxt" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
           </td></tr>
                       <tr style="padding-bottom:20px">
                            <td>
                                ACT Score
                            </td>
                            <td style="padding-bottom:20px">
                    <asp:TextBox ID="actScoreTxt" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                                </td>
                            </tr>
                        <tr style="padding-bottom:20px">
                            <td>
                                SAT Score
                            </td>
                            <td style="padding-bottom:20px">
                     <asp:TextBox ID="satScoreTxt" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                            </td></tr>
                        <tr style="padding-bottom:20px"><td>
                                PSAT Score:
                            </td>
                            <td style="padding-bottom:20px">
                     <asp:TextBox ID="psatScoreTxt" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                           </td> </tr>
                        <tr style="padding-bottom:20px">
                            <td>
                                Add Your Skills
                            </td>
                            <td style="padding-bottom:20px">
                    <asp:TextBox ID="skillsTxt" runat="server"  CssClass="form-control"></asp:TextBox>
                          </td>  </tr>
                    <tr style="padding-bottom:20px">
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
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                          </td>
                            <td><asp:Button ID="btnAddLink"
             runat="server" Text="Add Link" OnClick="btnAddLink_Click" CssClass="btn btn-primary"/>  </td>
                        </tr>
                         <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ProjectDB %>" 
        SelectCommand="SELECT [url], [description], [userID] FROM [YouTubeVideos]">
    </asp:SqlDataSource>--%>
                       <tr><asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
    <ItemTemplate>
    <object width="480" height="385"><param name="movie" value='<%#DataBinder.Eval(Container.DataItem, "url") %>'></param>
    <param name="allowFullScreen" value="true"></param>
    <param name="allowscriptaccess" value="always"></param>
    <embed src='<%#DataBinder.Eval(Container.DataItem, "url") %>' type="application/x-shockwave-flash" allowscriptaccess="always" allowfullscreen="true" width="480" height="385">
    </embed>
    </object>
    <br />    
    </ItemTemplate>
    </asp:Repeater>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ProjectDB %>"
                                 
        SelectCommand="SELECT [url], [description] FROM [YouTubeVideos] WHERE ([userID] = @userID)">
                                <SelectParameters>
                                    <asp:SessionParameter Name="userID" SessionField="userID" Type="Int32" />
                                </SelectParameters>
    </asp:SqlDataSource></tr>
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
