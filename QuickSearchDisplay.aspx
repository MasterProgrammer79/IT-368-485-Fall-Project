<%@ Page Title="" Language="C#" MasterPageFile="~/LinkedU.Master" AutoEventWireup="true" CodeBehind="QuickSearchDisplay.aspx.cs" Inherits="LinkedU.QuickSearchDisplay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="site sign-up-form" style="padding-left: 100px">
      
     <asp:GridView ID="GridView1" runat="server"  BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="False" Width="921px" Height="96px">
         <Columns>
             <asp:ImageField HeaderText="Image" DataImageUrlField="ImageFilePath" ControlStyle-CssClass="grid-font" ControlStyle-Height="150px" ControlStyle-Width="150px">
<ControlStyle Height="150px" Width="150px"></ControlStyle>
             </asp:ImageField>
             <asp:BoundField DataField="firstName" ControlStyle-CssClass="grid-font" ControlStyle-Width="300px"  HeaderText="First Name" >
<ControlStyle Width="500px" BorderWidth="150px" Font-Bold="True" Font-Size="XX-Large" Height="500px"></ControlStyle>
             </asp:BoundField>
             <asp:BoundField DataField="lastName" ControlStyle-CssClass="grid-font" ControlStyle-Width="300px" HeaderText="Last Name" >
<ControlStyle Width="300px"></ControlStyle>
             </asp:BoundField>
             <asp:HyperLinkField NavigateUrl="Login.aspx" ControlStyle-CssClass="grid-font"  ControlStyle-Width="150px" Text="View Profile" >
<ControlStyle Width="150px"></ControlStyle>
             </asp:HyperLinkField>
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

       <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="496px">
           <Columns>
               <asp:BoundField DataField="schoolName" ControlStyle-CssClass="grid-font" HeaderText="School Name" />
               <asp:BoundField DataField="schoolCity" ControlStyle-CssClass="grid-font" HeaderText="School City" />
               <asp:HyperLinkField NavigateUrl="Login.aspx" ControlStyle-CssClass="grid-font" Text="View " />
           </Columns>
       </asp:GridView>

       <asp:Label ID="Label1" runat="server"></asp:Label>
       </div>
</asp:Content>
