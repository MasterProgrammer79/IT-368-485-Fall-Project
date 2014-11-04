<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="JEMJLinkedU.ProfilePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Wizard ID="Wizard1" runat="server" ActiveStepIndex="2">
            <WizardSteps>
                <asp:WizardStep ID="WizardStep1" runat="server" Title="Background">
                   <table>
                        <tr>
                            <td>
                                <asp:Label ID="summarylbl" runat="server" Text="Summary"></asp:Label>
                            </td>
                            <td>
                    <asp:TextBox ID="summarytxt" runat="server" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                       </table>

                </asp:WizardStep>

                <asp:WizardStep ID="WizardStep2" runat="server" Title="Education">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="School Name"></asp:Label>
                            </td>
                            <td>
                    <asp:TextBox ID="schoolName" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Field of Study"></asp:Label>
                            </td>
                            <td>
                     <asp:TextBox ID="fieldOfStudy" runat="server"></asp:TextBox>
                            </td></tr>
                        <tr><td>
                                <asp:Label ID="Label3" runat="server" Text="Major"></asp:Label>
                            </td>
                            <td>
                     <asp:TextBox ID="major" runat="server"></asp:TextBox>
                           </td> </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="Minor"></asp:Label>
                            </td>
                            <td>
                    <asp:TextBox ID="minor" runat="server"></asp:TextBox>
                          </td>  </tr>
                        </table>
                </asp:WizardStep>

                <asp:WizardStep ID="WizardStep3" runat="server" Title="Experience">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="Company Name"></asp:Label>
                            </td>
                            <td>
                     <asp:TextBox ID="companyNameTxt" runat="server"></asp:TextBox>
                                </td>
                            </tr>

                        <tr>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text="Title"></asp:Label>
                            </td>
                            <td>
                     <asp:TextBox ID="titleTxt" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text="Location"></asp:Label>
                            </td>
                            <td>
                     <asp:TextBox ID="LocationTxt" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label8" runat="server" Text="Time Period"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                    <asp:ListItem>Choose....</asp:ListItem>
                                    <asp:ListItem>January</asp:ListItem>
                                    <asp:ListItem>February</asp:ListItem>
                                    <asp:ListItem>March</asp:ListItem>
                                    <asp:ListItem>April</asp:ListItem>
                                    <asp:ListItem>May</asp:ListItem>
                                    <asp:ListItem>June</asp:ListItem>
                                    <asp:ListItem>July</asp:ListItem>
                                    <asp:ListItem>August</asp:ListItem>
                                    <asp:ListItem>September</asp:ListItem>
                                    <asp:ListItem>October</asp:ListItem>
                                    <asp:ListItem>November</asp:ListItem>
                                    <asp:ListItem>December</asp:ListItem>
                                </asp:DropDownList>
                                <asp:TextBox ID="Fromyeartxt" runat="server"></asp:TextBox>
                                </td>
                            <td>
                                &nbsp;</td>
                            <td> - </td>
                            <td>
                                <asp:DropDownList ID="DropDownList2" runat="server">
                                    <asp:ListItem>Choose....</asp:ListItem>
                                    <asp:ListItem>January</asp:ListItem>
                                    <asp:ListItem>February</asp:ListItem>
                                    <asp:ListItem>March</asp:ListItem>
                                    <asp:ListItem>April</asp:ListItem>
                                    <asp:ListItem>May</asp:ListItem>
                                    <asp:ListItem>June</asp:ListItem>
                                    <asp:ListItem>July</asp:ListItem>
                                    <asp:ListItem>August</asp:ListItem>
                                    <asp:ListItem>September</asp:ListItem>
                                    <asp:ListItem>October</asp:ListItem>
                                    <asp:ListItem>November</asp:ListItem>
                                    <asp:ListItem>December</asp:ListItem>
                                </asp:DropDownList>
                                </td>
                            <td>
                                <asp:TextBox ID="toYearTxt" runat="server"></asp:TextBox>
                            </td>
                            </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label9" runat="server" Text="Responsibilities"></asp:Label>
                            </td>
                            <td>
                    <asp:TextBox ID="descriptionTxt" runat="server" TextMode="MultiLine"></asp:TextBox>
                          </td>  </tr>
                        </table>
                </asp:WizardStep>
                <asp:WizardStep ID="WizardStep4" runat="server" Title="Scores">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label10" runat="server" Text="SAT"></asp:Label>
                            </td>
                            <td>
                    <asp:TextBox ID="satScoretxt" runat="server"></asp:TextBox>
                          </td>  </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label11" runat="server" Text="ACT"></asp:Label>
                            </td>
                            <td>
                    <asp:TextBox ID="actScoretxt" runat="server"></asp:TextBox>
                          </td>  </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label12" runat="server" Text="PSAT"></asp:Label>
                            </td>
                            <td>
                    <asp:TextBox ID="psatScoretxt" runat="server"></asp:TextBox>
                          </td>  </tr>


                    </table>

                </asp:WizardStep>
                <asp:WizardStep ID="WizardStep5" runat="server" Title="Languages">
                    <tr>
                            <td>
                                <asp:Label ID="Label13" runat="server" Text="Languages"></asp:Label>
                            </td>
                            <td>
                    <asp:TextBox ID="laguagestxt" runat="server"></asp:TextBox>
                          </td>  </tr>
                </asp:WizardStep>
                <asp:WizardStep ID="WizardStep6" runat="server" Title="Skills">
                          <table> <tr>
                            <td>
                                <asp:Label ID="Label14" runat="server" Text="Skills"></asp:Label>
                            </td>
                            <td>
                    <asp:TextBox ID="Skillstxt" runat="server" TextMode="MultiLine"></asp:TextBox>
                          </td>  </tr>
                    </table>
                </asp:WizardStep>
                <asp:WizardStep ID="WizardStep8" runat="server" Title="Essay of Choice">
                    You can either copy nad paste your essay or can upload it. 
                    <table>
                          <tr>
                              <td>
                                  <asp:Label ID="Label15" runat="server" Text="Essay of Choice"></asp:Label>
                            </td>
                            <td>
                    <asp:TextBox ID="essayofChoiceTxt" runat="server" TextMode="MultiLine"></asp:TextBox>
                          </td>  </tr>
                            <tr>
                                <td>
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                </td>
                            </tr>  

                    </table>
                </asp:WizardStep>
                <asp:WizardStep ID="WizardStep7" runat="server" Title="Additional Info"></asp:WizardStep>

            </WizardSteps>
        </asp:Wizard>



    </div>
    </form>
</body>
</html>
