<%@ Page Title="" Language="C#" MasterPageFile="~/LinkedU.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="LinkedU.SignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Sign Up for Linked U!</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="site full">
            <h1 style="text-align:center">Create your Linked<span style="color:#4472c4">U</span> Account</h1>
        </div>
        <div class="site sign-up-panel-1">
            <p>
                Username:
                <asp:TextBox ID="Username" CssClass="form-control" runat="server" AutoPostBack="true" OnTextChanged="Username_TextChanged" />
                <asp:RequiredFieldValidator ID="UserValidator"
                    ControlToValidate="Username"
                    Display="Dynamic"
                    ErrorMessage="<strong>Please enter a Username!</strong>"
                    ForeColor="Red"
                    runat="server" />
                <asp:Label ID="UsernameMessage" runat="server" />
            </p>
            <p>
                Password:
                <asp:TextBox ID="Password" TextMode="Password" CssClass="form-control" runat="server" />
                <asp:RequiredFieldValidator ID="PasswordValidator"
                    ControlToValidate="Password"
                    Display="Dynamic"
                    ErrorMessage="<strong>Please enter a Password!</strong>"
                    ForeColor="Red"
                    runat="server" />
            </p>
            <p>
                Confirm Password:
                <asp:TextBox ID="ConfirmPassword" TextMode="Password" CssClass="form-control" runat="server" />
                <asp:CompareValidator ID="ComparePasswords"
                    ControlToValidate="Password"
                    ControlToCompare="ConfirmPassword"
                    ErrorMessage="<strong>Your Passwords Do Not Match!</strong>"
                    ForeColor="Red"
                    runat="server" />
            </p>
            <p>
                <asp:RadioButtonList ID="UserType" runat="server">
                    <asp:ListItem Text="Student" Value="student" />
                    <asp:ListItem Text="Recruiter" Value="recruiter" />
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="UserTypeValidator"
                    ControlToValidate="UserType"
                    Display="Dynamic"
                    ErrorMessage="Please select a User Type!"
                    ForeColor="Red"
                    runat="server" />
            </p>
            <p>
                Account Type:
                <asp:DropDownList ID="AccountType" runat="server">
                    <asp:ListItem Text="Select type..." Value="none" />
                    <asp:ListItem Text="Basic" Value="basic" />
                    <asp:ListItem Text="Premium" Value="premium" />
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="AccountTypeValidator"
                    ControlToValidate="AccountType"
                    InitialValue="none"
                    Display="Dynamic"
                    ErrorMessage="Please select an Account Type!"
                    ForeColor="Red"
                    runat="server" />
            </p>
            <asp:Button ID="CreateAccountInfo" Text="Next Step" runat="server" OnClick="CreateAccountInfo_Click" />
        </div>
        <asp:Panel ID="ActivateStudentPanel1" runat="server" style="display:none">
            <div class="site sign-up-panel-2">
                <h2>Student Personal Information</h2>
                <p>
                    First Name:
                    <asp:TextBox ID="StudentFirstName" CssClass="form-control" runat="server" />
                    <asp:RequiredFieldValidator ID="StudentFirstNameValidator"
                        ControlToValidate="StudentFirstName"
                        Display="Dynamic"
                        ErrorMessage="Please enter your First Name!"
                        ForeColor="Red"
                        runat="server" />
                </p>
                <p>
                    Last Name:
                    <asp:TextBox ID="StudentLastName" CssClass="form-control" runat="server" />
                    <asp:RequiredFieldValidator ID="StudentLastNameValidator"
                        ControlToValidate="StudentLastName"
                        Display="Dynamic"
                        ErrorMessage="Please enter your Last Name!"
                        ForeColor="Red"
                        runat="server" />
                </p>
                <p>
                    Email:
                    <asp:TextBox ID="StudentEmail" runat="server" />
                    <asp:RequiredFieldValidator ID="StudentEmailValidator"
                        ControlToValidate="StudentEmail"
                        Display="Dynamic"
                        ErrorMessage="Please enter your Email!"
                        ForeColor="Red"
                        runat="server" />
                </p>
                <p>
                    Phone Number:
                    <asp:TextBox ID="StudentPhone" runat="server" />
                    <asp:RequiredFieldValidator ID="StudentPhoneValidator"
                        ControlToValidate="StudentPhone"
                        Display="Dynamic"
                        ErrorMessage="Please enter your Phone Number!"
                        ForeColor="Red"
                        runat="server" />
                </p>
                <p>
                    Street Address:
                    <asp:TextBox ID="StudentAddress" runat="server" />
                    <asp:RequiredFieldValidator ID="StudentAddressValidator"
                        ControlToValidate="StudentAddress"
                        Display="Dynamic"
                        ErrorMessage="Please enter your Address!"
                        ForeColor="Red"
                        runat="server" />
                </p>
                <p>
                    City:
                    <asp:TextBox ID="StudentCity" runat="server" />
                    <asp:RequiredFieldValidator ID="StudentCityValidator"
                        ControlToValidate="StudentCity"
                        Display="Dynamic"
                        ErrorMessage="Please enter your City!"
                        ForeColor="Red"
                        runat="server" />
                </p>
                <p>
                    State:
                </p>
                <p>
                    Zip Code:
                    <asp:TextBox ID="StudentZip" runat="server" />
                    <asp:RequiredFieldValidator ID="StudentZipValidator"
                        ControlToValidate="StudentZip"
                        Display="Dynamic"
                        ErrorMessage="Please enter your Zip Code!"
                        ForeColor="Red"
                        runat="server" />
                </p>
                <asp:Button ID="EditPreviousInfo1" Text="Go Back" runat="server" OnClick="EditPreviousInfo_Click" />
                <asp:Button ID="NextStudentStep" Text="Next Step" runat="server" OnClick="NextStudentStep_Click" />
            </div>
        </asp:Panel>
        <asp:Panel ID="ActivateStudentPanel2" runat="server" style="display:none">
            <div class="site sign-up-panel-2">
                <h2>Student Professional Information</h2>

                <asp:Button ID="EditStudentStep" Text="Go Back" runat="server" OnClick="EditStudentStep_Click" />
                <asp:Button ID="CreateNewStudent" Text="Create Account" runat="server" OnClick="CreateNewStudent_Click" />
            </div>
        </asp:Panel>
        <asp:Panel ID="ActivateRecruiterPanel" runat="server" style="display:none">
            <div class="site sign-up-panel-2">
                <h2>Recruiter Information</h2>
                <p>
                    First Name:
                    <asp:TextBox ID="RecruiterFirstName" runat="server" />
                    <asp:RequiredFieldValidator ID="RecruiterFirstNameValidator"
                        ControlToValidate="RecruiterFirstName"
                        Display="Dynamic"
                        ErrorMessage="Please enter your First Name!"
                        ForeColor="Red"
                        runat="server" />
                </p>
                <p>
                    Last Name:
                    <asp:TextBox ID="RecruiterLastName" runat="server" />
                    <asp:RequiredFieldValidator ID="RecruiterLastNameValidator"
                        ControlToValidate="RecruiterLastName"
                        Display="Dynamic"
                        ErrorMessage="Please enter your Last Name!"
                        ForeColor="Red"
                        runat="server" />
                </p>
                <p>
                    Email:
                    <asp:TextBox ID="RecruiterEmail" runat="server" />
                    <asp:RequiredFieldValidator ID="RecruiterEmailValidator"
                        ControlToValidate="RecruiterEmail"
                        Display="Dynamic"
                        ErrorMessage="Please enter your Email!"
                        ForeColor="Red"
                        runat="server" />
                </p>
                <asp:Button ID="EditPreviousInfo3" Text="Go Back" runat="server" OnClick="EditPreviousInfo_Click" />
                <asp:Button ID="CreateNewRecruiter" Text="Create Account" runat="server" OnClick="CreateNewRecruiter_Click" />
            </div>
        </asp:Panel>
    </div>
</asp:Content>
