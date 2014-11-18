<%@ Page Title="" Language="C#" MasterPageFile="~/LinkedU.Master" AutoEventWireup="true" CodeBehind="ScheduleAppointment.aspx.cs" Inherits="LinkedU.ScheduleAppointment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class="container">
        <div class="big-left">
            <asp:Panel ID="Panel2" runat="server">
                <asp:Label ID="Label1" runat="server" ></asp:Label>
            </asp:Panel>
            <asp:Panel ID="Panel1" runat="server">
     <p> student Name: <%--<asp:TextBox ID="StudentName" runat="server"></asp:TextBox> --%> <asp:Label ID="StudentNameLabel" runat="server" style="font-weight:700"></asp:Label>
         <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="StudentName"
                             ErrorMessage="Please enter your name"></asp:RequiredFieldValidator><br />--%>

      <%--    To student email: <asp:TextBox ID="Toemail" runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Toemail"
                             ErrorMessage="Please enter your name"></asp:RequiredFieldValidator><br />--%>

        <br />  From:<%-- <asp:TextBox ID="nameTxt" runat="server"></asp:TextBox> --%> <asp:Label ID="RecruiterNameLabel" runat="server" Style="font-weight:700"></asp:Label>
         <%--<asp:RequiredFieldValidator ID="fnameRequiredFieldValidator" runat="server" ControlToValidate="nameTxt"
                             ErrorMessage="Please enter your name"></asp:RequiredFieldValidator><br />--%>
     </p>
      <p>
 <%--   Your Email : <asp:TextBox ID="emailTxt" runat="server" TextMode="Email"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="nameTxt"
                             ErrorMessage="Please enter your email"></asp:RequiredFieldValidator><br />--%>
     </p>
            <p>
    <%--Subject : <asp:TextBox ID="subjectTxt" runat="server"></asp:TextBox>--%>
            </p>
            <p>
                <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px">
                    <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                    <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                    <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                    <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                    <WeekendDayStyle BackColor="#CCCCFF" />
                </asp:Calendar>

            </p>
            <p>
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem>Select Time</asp:ListItem>
                    <asp:ListItem Value="9 AM">9 AM</asp:ListItem>
                    <asp:ListItem>10 AM</asp:ListItem>
                    <asp:ListItem>11 AM</asp:ListItem>
                    <asp:ListItem>12 PM</asp:ListItem>
                    <asp:ListItem>1 PM</asp:ListItem>
                    <asp:ListItem>2 PM</asp:ListItem>
                    <asp:ListItem>3 PM</asp:ListItem>
                    <asp:ListItem>4 PM</asp:ListItem>
                </asp:DropDownList>
            </p>

            <p>
                <asp:Button ID="Button1" runat="server" Text="Schedule Appointment" OnClick="Button1_Click" />

            </p>
            </asp:Panel>
         </div>
              </div>




</asp:Content>
