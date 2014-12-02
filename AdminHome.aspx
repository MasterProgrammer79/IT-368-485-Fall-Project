<%@ Page Title="" Language="C#" MasterPageFile="~/LinkedU.Master" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="LinkedU.images.AdminHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Welcome Admin</h1>

     <div class="full site" >
    <div class="small-left">
            
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="true">
        <asp:ListItem Value="add">Add University</asp:ListItem>
        <asp:ListItem Value="view">View University</asp:ListItem>
    </asp:RadioButtonList>
        </div>
         </div>


     <asp:MultiView ID="MultiView1" runat="server">
       

        <asp:View ID="AddUniv" runat="server">
           
        <div class="site site sign-up-panel-2">
                <div class="sign-up-form">
                    <asp:Panel ID="photouploadPanel" runat="server">
                    <asp:Image ID="ImagePreview" runat="server" ImageUrl="~/images/noprofileimg.png" Height="164px" Width="200px" />
                    <%--<asp:Label ID="userName" runat="server" Font-Bold="true" Font-Size="Large" ></asp:Label>--%>
                    <asp:FileUpload ID="PhotoUpload" runat="server" CssClass="btn btn-primary"  />
                     <asp:Label ID="choosePhotolbl" runat="server"></asp:Label><br />
                    <asp:Button ID="choosePhoto" runat="server" Text="Preview" OnClick="choosePhoto_Click" CssClass="btn btn-primary" />
                    
                    </asp:Panel>

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
                <asp:Button ID="insertButton" runat="server" Text="Insert" OnClick="insertButton_Click" CssClass="btn btn-primary" /> 
                
            </asp:Panel>
            </div>
            </div>
          
        </asp:View>
          
        <asp:View ID="ViewUniv" runat="server">
            
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="1211px">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="showcaseSelector" runat="server" AutoPostBack="true" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="schoolID" HeaderText="SchoolID" Visible="False" />
                    <asp:BoundField ControlStyle-Height="200px" ControlStyle-Width="250px" DataField="schoolName" HeaderText="Name" />
                    <asp:ImageField ControlStyle-Height="200px" ControlStyle-Width="250px" DataImageUrlField="schoolImagePath" HeaderText="University Image">
                        <ControlStyle Height="200px" Width="250px" />
                    </asp:ImageField>
                    <asp:BoundField ControlStyle-Height=" 100px" ControlStyle-Width="100px" DataField="schoolRank" HeaderText="Rank">
                    <ControlStyle Height="100px" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField ControlStyle-Height=" 100px" ControlStyle-Width="100px" DataField="schoolCity" HeaderText="City">
                    <ControlStyle Height="100px" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField ControlStyle-Height=" 100px" ControlStyle-Width="100px" DataField="schoolState" HeaderText="State">
                    <ControlStyle Height="100px" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField ControlStyle-Height=" 150px" ControlStyle-Width="150px" DataField="schoolDescription" HeaderText="Description">
                    <ControlStyle Height="100px" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField ControlStyle-Height=" 100px" ControlStyle-Width="100px" DataField="schoolWebsite" HeaderText="Website">
                    <ControlStyle Height="100px" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField ControlStyle-Height=" 100px" ControlStyle-Width="100px" DataField="applicationDeadline" HeaderText="Application Deadline">
                    <ControlStyle Height="100px" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField ControlStyle-Height=" 100px" ControlStyle-Width="100px" DataField="schoolAddress" HeaderText="Address">
                    <ControlStyle Height="100px" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField ControlStyle-Height=" 100px" ControlStyle-Width="100px" DataField="schoolPhone" HeaderText="Contact Us">
                    <ControlStyle Height="100px" Width="100px" />
                    </asp:BoundField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" runat="server" ControlStyle-CssClass="grid-font" NavigateUrl='<%# string.Format("~/AdminEdit.aspx?SchoolID={0}", HttpUtility.UrlEncode(Eval("SchoolID").ToString())) %>' Text="Edit"></asp:HyperLink>
                            <asp:HyperLink ID="HyperLink2" runat="server" ControlStyle-CssClass="grid-font" NavigateUrl='<%# string.Format("~/AdminDelete.aspx?SchoolID={0}", HttpUtility.UrlEncode(Eval("SchoolID").ToString())) %>' Text="Delete"></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                <RowStyle BackColor="White" ForeColor="#003399" />
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                <SortedDescendingHeaderStyle BackColor="#002876" />
            </asp:GridView>
            <div class="site site sign-up-panel-2">
                <div class="sign-up-form">
                    <br />
                    <asp:Button ID="SelectShowcase" runat="server" OnClick="SelectShowcase_Click" Text="Select Special University" />
                </div>
            </div>
        </asp:View>
    </asp:MultiView>



</asp:Content>
