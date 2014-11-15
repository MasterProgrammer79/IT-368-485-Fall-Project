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
            <div class="sign-up-form">
                <p>
                    Username:
                    <asp:TextBox ID="Username" CssClass="form-control" runat="server" AutoPostBack="true" OnTextChanged="Username_TextChanged" />
                    <asp:RequiredFieldValidator ID="UserValidator"
                        ControlToValidate="Username"
                        Display="Dynamic"
                        ErrorMessage="<strong>Username Required!</strong>"
                        ForeColor="Red"
                        style="padding-left:6px"
                        runat="server" />
                    <asp:Label ID="UsernameMessage" style="padding-left:6px" runat="server" />
                </p>
                <p>
                    Password:
                    <asp:TextBox ID="Password" TextMode="Password" CssClass="form-control" runat="server" />
                    <asp:RequiredFieldValidator ID="PasswordValidator"
                        ControlToValidate="Password"
                        Display="Dynamic"
                        ErrorMessage="<strong>Password Required!</strong>"
                        ForeColor="Red"
                        style="padding-left:6px"
                        runat="server" />
                </p>
                <p>
                    Confirm Password:
                    <asp:TextBox ID="ConfirmPassword" TextMode="Password" CssClass="form-control" runat="server" />
                    <asp:CompareValidator ID="ComparePasswords"
                        ControlToValidate="Password"
                        ControlToCompare="ConfirmPassword"
                        ErrorMessage="<strong>Passwords Do Not Match!</strong>"
                        ForeColor="Red"
                        style="padding-left:6px"
                        runat="server" />
                </p>
                <p>
                    <asp:RadioButtonList ID="UserType" RepeatColumns="2" RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server">
                        <asp:ListItem Text="Student" Value="student" class="radio-inline" />
                        <asp:ListItem Text="Recruiter" Value="recruiter" class="radio-inline" />
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="UserTypeValidator"
                        ControlToValidate="UserType"
                        Display="Dynamic"
                        ErrorMessage="<strong>User Type Required!</strong>"
                        ForeColor="Red"
                        style="padding-left:6px"
                        runat="server" />
                </p>
                <p>
                    Account Type:
                    <asp:DropDownList ID="AccountType" CssClass="form-control" runat="server">
                        <asp:ListItem Text="Select type..." Value="none" />
                        <asp:ListItem Text="Basic" Value="basic" />
                        <asp:ListItem Text="Premium" Value="premium" />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="AccountTypeValidator"
                        ControlToValidate="AccountType"
                        InitialValue="none"
                        Display="Dynamic"
                        ErrorMessage="<strong>Account Type Required!</strong>"
                        ForeColor="Red"
                        style="padding-left:6px"
                        runat="server" />
                </p>
                <br />
                <asp:Button ID="CreateAccountInfo" Text="Next Step" CssClass="btn btn-primary" runat="server" OnClick="CreateAccountInfo_Click" />
            </div>
        </div>
        <asp:Panel ID="ActivateStudentPanel" runat="server" style="display:none">
            <div class="site sign-up-panel-2">
                <div class="sign-up-form">
                    <h2 style="text-align:center">Student Information</h2>
                    <hr />
                    <p>
                        First Name:
                        <asp:TextBox ID="StudentFirstName" CssClass="form-control" runat="server" />
                        <asp:RequiredFieldValidator ID="StudentFirstNameValidator"
                            ControlToValidate="StudentFirstName"
                            Display="Dynamic"
                            ErrorMessage="<strong>First Name Required!</strong>"
                            ForeColor="Red"
                            Visible="false"
                            style="padding-left:6px"
                            runat="server" />
                    </p>
                    <p>
                        Last Name:
                        <asp:TextBox ID="StudentLastName" CssClass="form-control" runat="server" />
                        <asp:RequiredFieldValidator ID="StudentLastNameValidator"
                            ControlToValidate="StudentLastName"
                            Display="Dynamic"
                            ErrorMessage="<strong>Last Name Required!</strong>"
                            ForeColor="Red"
                            Visible="false"
                            style="padding-left:6px"
                            runat="server" />
                    </p>
                    <p>
                        Email:
                        <asp:TextBox ID="StudentEmail" CssClass="form-control" runat="server" />
                        <asp:RequiredFieldValidator ID="StudentEmailValidator"
                            ControlToValidate="StudentEmail"
                            Display="Dynamic"
                            ErrorMessage="Email Required!"
                            ForeColor="Red"
                            Visible="false"
                            style="padding-left:6px"
                            runat="server" />
                    </p>
                    <p>
                        Phone Number:
                        <asp:TextBox ID="StudentPhone" CssClass="form-control" runat="server" />
                        <asp:RequiredFieldValidator ID="StudentPhoneValidator"
                            ControlToValidate="StudentPhone"
                            Display="Dynamic"
                            ErrorMessage="<strong>Phone Number Required!</strong>"
                            ForeColor="Red"
                            Visible="false"
                            style="padding-left:6px"
                            runat="server" />
                    </p>
                    <p>
                        Street Address:
                        <asp:TextBox ID="StudentAddress" CssClass="form-control" runat="server" />
                        <asp:RequiredFieldValidator ID="StudentAddressValidator"
                            ControlToValidate="StudentAddress"
                            Display="Dynamic"
                            ErrorMessage="<strong>Address Required!</strong>"
                            ForeColor="Red"
                            Visible="false"
                            style="padding-left:6px"
                            runat="server" />
                    </p>
                    <p>
                        City:
                        <asp:TextBox ID="StudentCity" CssClass="form-control" runat="server" />
                        <asp:RequiredFieldValidator ID="StudentCityValidator"
                            ControlToValidate="StudentCity"
                            Display="Dynamic"
                            ErrorMessage="<strong>City Required!</strong>"
                            ForeColor="Red"
                            Visible="false"
                            style="padding-left:6px"
                            runat="server" />
                    </p>
                    <p>
                        State:
                        <asp:DropDownList ID="StudentState" CssClass="form-control" runat="server">
                            <asp:ListItem Text="Select state..." Value="none" />
                            <asp:ListItem Text="Alabama" Value="AL" />
                            <asp:ListItem Text="Alaska" Value="AK" />
                            <asp:ListItem Text="Arizona" Value="AZ" />
                            <asp:ListItem Text="Arkansas" Value="AR" />
                            <asp:ListItem Text="California" Value="CA" />
                            <asp:ListItem Text="Colorado" Value="CO" />
                            <asp:ListItem Text="Connecticut" Value="CT" />
                            <asp:ListItem Text="Delaware" Value="DE" />
                            <asp:ListItem Text="Florida" Value="FL" />
                            <asp:ListItem Text="Georgia" Value="GA" />
                            <asp:ListItem Text="Hawaii" Value="HI" />
                            <asp:ListItem Text="Idaho" Value="ID" />
                            <asp:ListItem Text="Illinois" Value="IL" />
                            <asp:ListItem Text="Indiana" Value="IN" />
                            <asp:ListItem Text="Iowa" Value="IA" />
                            <asp:ListItem Text="Kansas" Value="KS" />
                            <asp:ListItem Text="Kentucky" Value="KY" />
                            <asp:ListItem Text="Louisiana" Value="LA" />
                            <asp:ListItem Text="Maine" Value="ME" />
                            <asp:ListItem Text="Maryland" Value="MD" />
                            <asp:ListItem Text="Massachusetts" Value="MA" />
                            <asp:ListItem Text="Michigan" Value="MI" />
                            <asp:ListItem Text="Minnesota" Value="MN" />
                            <asp:ListItem Text="Mississippi" Value="MS" />
                            <asp:ListItem Text="Missouri" Value="MO" />
                            <asp:ListItem Text="Montana" Value="MT" />
                            <asp:ListItem Text="Nebraska" Value="NE" />
                            <asp:ListItem Text="Nevada" Value="NV" />
                            <asp:ListItem Text="New Hampshire" Value="NH" />
                            <asp:ListItem Text="New Jersey" Value="NJ" />
                            <asp:ListItem Text="New Mexico" Value="NM" />
                            <asp:ListItem Text="New York" Value="NY" />
                            <asp:ListItem Text="North Carolina" Value="NC" />
                            <asp:ListItem Text="North Dakota" Value="ND" />
                            <asp:ListItem Text="Ohio" Value="OH" />
                            <asp:ListItem Text="Oklahoma" Value="OK" />
                            <asp:ListItem Text="Oregon" Value="OR" />
                            <asp:ListItem Text="Pennsylvania" Value="PA" />
                            <asp:ListItem Text="Rhode Island" Value="RI" />
                            <asp:ListItem Text="South Carolina" Value="SC" />
                            <asp:ListItem Text="South Dakota" Value="SD" />
                            <asp:ListItem Text="Tennessee" Value="TN" />
                            <asp:ListItem Text="Texas" Value="TX" />
                            <asp:ListItem Text="Utah" Value="UT" />
                            <asp:ListItem Text="Vermont" Value="VT" />
                            <asp:ListItem Text="Virginia" Value="VA" />
                            <asp:ListItem Text="Washington" Value="WA" />
                            <asp:ListItem Text="West Virginia" Value="WV" />
                            <asp:ListItem Text="Wisconsin" Value="WI" />
                            <asp:ListItem Text="Wyoming" Value="WY" />
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="StudentStateValidator"
                            ControlToValidate="StudentState"
                            InitialValue="none"
                            Display="Dynamic"
                            ErrorMessage="<strong>State Required!</strong>"
                            ForeColor="Red"
                            Visible="false"
                            style="padding-left:6px"
                            runat="server" />
                    </p>
                    <p>
                        Zip Code:
                        <asp:TextBox ID="StudentZip" CssClass="form-control" runat="server" />
                        <asp:RequiredFieldValidator ID="StudentZipValidator"
                            ControlToValidate="StudentZip"
                            Display="Dynamic"
                            ErrorMessage="<strong>Zip Code Required!</strong>"
                            ForeColor="Red"
                            Visible="false"
                            style="padding-left:6px"
                            runat="server" />
                    </p>
                    <asp:Button ID="EditPreviousInfo1" Text="Go Back" CssClass="btn btn-primary" runat="server" OnClick="EditPreviousInfo_Click" CausesValidation="false" />
                    <!-- <asp:Button ID="NextStudentStep" Text="Next Step" CssClass="btn btn-primary" runat="server" OnClick="NextStudentStep_Click" /> -->
                    <asp:Button ID="CreateNewStudent" Text="Create Account" CssClass="btn btn-primary" style="float:right" runat="server" OnClick="CreateNewStudent_Click" />
                </div>
            </div>
        </asp:Panel>
        <!-- <asp:Panel ID="ActivateStudentPanel2" runat="server" style="display:none">
            <div class="site full">
                <div class="sign-up-form">
                    <h2 style="text-align:center">Student Professional Information</h2>
                    <hr />
                    <p>
                        School:
                        <asp:TextBox ID="StudentSchool" CssClass="form-control" Columns="50" runat="server" />
                        <asp:RequiredFieldValidator ID="StudentSchoolValidator"
                            ControlToValidate="StudentSchool"
                            Display="Dynamic"
                            ErrorMessage="<strong>School Required!</strong>"
                            ForeColor="Red"
                            Visible="false"
                            style="padding-left:6px"
                            runat="server" />
                    </p>
                    <p>
                        Major:
                        <asp:TextBox ID="StudentMajor" CssClass="form-control" Columns="40" runat="server" />
                        <asp:RequiredFieldValidator ID="StudentMajorValidator"
                            ControlToValidate="StudentMajor"
                            Display="Dynamic"
                            ErrorMessage="<strong>Major Required!</strong>"
                            ForeColor="Red"
                            Visible="false"
                            style="padding-left:6px"
                            runat="server" />
                    </p>
                    <p>
                        GPA:
                        <asp:TextBox ID="StudentGPA" CssClass="form-control" runat="server" />
                        <asp:RequiredFieldValidator ID="StudentGPAValidator"
                            ControlToValidate="StudentGPA"
                            Display="Dynamic"
                            ErrorMessage="<strong>GPA Required!</strong>"
                            ForeColor="Red"
                            Visible="false"
                            style="padding-left:6px"
                            runat="server" />
                    </p>
                    <p>
                        ACT:
                        <asp:TextBox ID="StudentACT" CssClass="form-control" runat="server" />
                        <asp:RequiredFieldValidator ID="StudentACTValidator"
                            ControlToValidate="StudentACT"
                            Display="Dynamic"
                            ErrorMessage="<strong>ACT Required!</strong>"
                            ForeColor="Red"
                            Visible="false"
                            style="padding-left:6px"
                            runat="server" />
                    </p>
                    <p>
                        SAT:
                        <asp:TextBox ID="StudentSAT" CssClass="form-control" runat="server" />
                    </p>
                    <p>
                        PSAT:
                        <asp:TextBox ID="StudentPSAT" CssClass="form-control" runat="server" />
                    </p>
                    <p>
                        Skill(s):

                    </p>
                    <p>
                        Essay:

                    </p>
                    <asp:Button ID="EditStudentStep" Text="Go Back" CssClass="btn btn-primary" runat="server" OnClick="EditStudentStep_Click" CausesValidation="false" />
                    <asp:Button ID="CreateNewStudent" Text="Create Account" runat="server" OnClick="CreateNewStudent_Click" />
                </div>
            </div>
        </asp:Panel> -->
        <asp:Panel ID="ActivateRecruiterPanel" runat="server" style="display:none">
            <div class="site sign-up-panel-2">
                <div class="sign-up-form">
                    <h2 style="text-align:center">Recruiter Information</h2>
                    <hr />
                    <p>
                        First Name:
                        <asp:TextBox ID="RecruiterFirstName" CssClass="form-control" runat="server" />
                        <asp:RequiredFieldValidator ID="RecruiterFirstNameValidator"
                            ControlToValidate="RecruiterFirstName"
                            Display="Dynamic"
                            ErrorMessage="<strong>First Name Required!</strong>"
                            ForeColor="Red"
                            Visible="false"
                            style="padding-left:6px"
                            runat="server" />
                    </p>
                    <p>
                        Last Name:
                        <asp:TextBox ID="RecruiterLastName" CssClass="form-control" runat="server" />
                        <asp:RequiredFieldValidator ID="RecruiterLastNameValidator"
                            ControlToValidate="RecruiterLastName"
                            Display="Dynamic"
                            ErrorMessage="<strong>Last Name Required!</strong>"
                            ForeColor="Red"
                            Visible="false"
                            style="padding-left:6px"
                            runat="server" />
                    </p>
                    <p>
                        Email:
                        <asp:TextBox ID="RecruiterEmail" CssClass="form-control" runat="server" />
                        <asp:RequiredFieldValidator ID="RecruiterEmailValidator"
                            ControlToValidate="RecruiterEmail"
                            Display="Dynamic"
                            ErrorMessage="<strong>Email Required!</strong>"
                            ForeColor="Red"
                            Visible="false"
                            style="padding-left:6px"
                            runat="server" />
                    </p>
                    <br />
                    <asp:Button ID="EditPreviousInfo2" Text="Go Back" CssClass="btn btn-primary" runat="server" OnClick="EditPreviousInfo_Click" CausesValidation="false" />
                    <asp:Button ID="CreateNewRecruiter" Text="Create Account" CssClass="btn btn-primary" style="float:right" runat="server" OnClick="CreateNewRecruiter_Click" />
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>