<%@ Page Title="" Language="C#" MasterPageFile="~/LinkedU.Master" AutoEventWireup="true" CodeBehind="AdvanceSearchForm.aspx.cs" Inherits="LinkedU.AdvanceSearchForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class="full site" >
    <div class="small-left">
            
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="true">
        <asp:ListItem Value="student">Student</asp:ListItem>
        <asp:ListItem Value="university">University</asp:ListItem>
    </asp:RadioButtonList>

    <asp:MultiView ID="MultiView1" runat="server">
       

        <asp:View ID="StudentSearch" runat="server">
           
            <p class="searchBy">First Name</p><br />
         <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"></asp:TextBox><br />
        <p class="searchBy">Last Name </p><br />
        <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server"></asp:TextBox><br />
        <p class="searchBy">City</p><br />
        <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server"></asp:TextBox><br />
        <p class="searchBy" >State</p><br />
        <asp:TextBox ID="TextBox4" CssClass="form-control" runat="server"></asp:TextBox><br />
         <p class="searchBy">Major</p><br />
        <asp:TextBox ID="TextBox5" CssClass="form-control" runat="server"></asp:TextBox><br />
         <p class="searchBy">GPA</p><br />
        <asp:TextBox ID="TextBox6" CssClass="form-control" runat="server"></asp:TextBox><br />
            <asp:Button ID="Button1" runat="server" Text="Search" CssClass=" btn btn-primary"  OnClick="Button1_Click" />
            
          
        </asp:View>
          
        <asp:View ID="UniversitySearch" runat="server">
            
            <asp:Label ID="Label1" runat="server">University Name</asp:Label><br />
            <asp:TextBox ID="TextBox7" CssClass="form-control" runat="server"></asp:TextBox><br />
            <asp:Label ID="Label2"  runat="server">City</asp:Label><br />
            <asp:TextBox ID="TextBox8" CssClass="form-control" runat="server"></asp:TextBox><br />
            <asp:Label ID="Label3" runat="server">State</asp:Label><br />
            <asp:TextBox ID="TextBox9" CssClass="form-control" runat="server"></asp:TextBox><br />
            <asp:Label ID="Label4" runat="server">Rank</asp:Label><br />
            <asp:TextBox ID="TextBox10" CssClass="form-control" runat="server"></asp:TextBox><br />
            <asp:Button ID="Button2" runat="server" CssClass=" btn btn-primary" Text="search" OnClick="Button2_Click" />
         
        </asp:View>
    </asp:MultiView>
                
        </div>
    <div class="big-right">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="792px">
            <Columns>
                <asp:BoundField DataField="userID" ControlStyle-CssClass="grid-font" HeaderText="User ID" Visible="false" />
                <asp:ImageField DataImageUrlField="ImageFilePath" ControlStyle-Height="150px" ControlStyle-Width="150px" HeaderText="Profile Image">
                </asp:ImageField>
                <asp:BoundField DataField="firstName" ControlStyle-CssClass="grid-font" HeaderText="First Name" />
                <asp:BoundField DataField="lastName" ControlStyle-CssClass="grid-font" HeaderText="Last Name" />
                <asp:BoundField DataField="studentEmailID" ControlStyle-CssClass="grid-font" HeaderText="Email Id" />
                <asp:BoundField DataField="studentPhone" ControlStyle-CssClass="grid-font" HeaderText="Contact Number" />
                
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" ControlStyle-CssClass="grid-font" NavigateUrl='<%# string.Format("~/SearchViewProfile.aspx?UserID={0}", HttpUtility.UrlEncode(Eval("UserID").ToString())) %>' Text="View Profile"></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="650px">
            <Columns>
                <asp:BoundField DataField="schoolID" HeaderText="School ID" Visible="False" />
                <asp:BoundField DataField="schoolName" ControlStyle-CssClass="grid-font" HeaderText="School Name" >
<ControlStyle CssClass="grid-font"></ControlStyle>
                </asp:BoundField>
                <asp:BoundField DataField="schoolWebsite" ControlStyle-CssClass="grid-font" HeaderText="Website" >
                <ControlStyle CssClass="grid-font" />
                </asp:BoundField>
                <asp:BoundField DataField="schoolCity" ControlStyle-CssClass="grid-font" HeaderText="City" >
<ControlStyle CssClass="grid-font"></ControlStyle>
                </asp:BoundField>
                <asp:BoundField DataField="schoolState" ControlStyle-CssClass="grid-font" HeaderText="State" >
<ControlStyle CssClass="grid-font"></ControlStyle>
                </asp:BoundField>
                 <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink2" runat="server" ControlStyle-CssClass="grid-font" NavigateUrl='<%# string.Format("~/DummyProfilePage.aspx?schoolID={0}", HttpUtility.UrlEncode(Eval("UserID").ToString())) %>' Text="View"></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
        <asp:Label ID="Label5" runat="server"></asp:Label>
        </div>
        
</asp:Content>
