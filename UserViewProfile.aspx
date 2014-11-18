<%@ Page Title="" Language="C#" MasterPageFile="~/LinkedU.Master" AutoEventWireup="true" CodeBehind="UserViewProfile.aspx.cs" Inherits="LinkedU.UserViewProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .labelUV {
            font-family:Cambria;
            font-weight:bold;
            color:#3046f5;
        }

    </style>
    <div class="container">
               <div class="site full">
            <h1 style="text-align:center">Linked<span style="color:#4472c4">U</span></h1>
        </div>
        
            <div class="site site sign-up-panel-2" style="float:left">
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
                                        <asp:Label ID="emailIdlbl" runat="server" ></asp:Label></td>
                                
                            </tr>
                            <tr>
                                <td>
                                    Phone Number</td>
                                    <td>
                                        <asp:Label ID="PhoneLbl" runat="server" CssClass="labelUV"></asp:Label></td>
                                
                            </tr>
                            <tr>
                                <td>
                                    Student City</td>
                                    <td>
                                        <asp:Label ID="citylbl" runat="server" CssClass="label"></asp:Label></td>
                                
                            </tr>
                        </table>

                        <table>
                            <tr>
                                <td>
                                    Major:</td>
                                    <td>
                                        <asp:Label ID="majorlbl" runat="server" CssClass="label"></asp:Label></td>
                                
                            </tr>
                            <tr>
                                <td>
                                    Summary</td>
                                    <td>
                                        <asp:Label ID="summarylbl" runat="server" CssClass="label"></asp:Label></td>
                                
                            </tr>
                            <tr>
                                <td>
                                    Field of Study</td>
                                    <td>
                                        <asp:Label ID="fieldofstudylbl" runat="server" CssClass="label"></asp:Label></td>
                                
                            </tr>
                            <tr>
                                <td>
                                    Minor</td>
                                    <td>
                                        <asp:Label ID="minorlbl" runat="server" CssClass="label"></asp:Label></td>
                                
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
        <div class="site site sign-up-panel-2" style="float:right">
                <div class="sign-up-form">
                    <asp:Panel ID="VideoPanel" runat="server">

                        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
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
    </asp:SqlDataSource>

                    </asp:Panel>
                    </div>
            </div>

        <div style="clear:both"></div>
        
</asp:Content>
