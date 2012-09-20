<%@ Page Language="C#" MasterPageFile="~/templates/main.master" AutoEventWireup="true"
    CodeFile="Apply.aspx.cs" Inherits="fordscleaning_Apply" Title="Apply for a job" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header">
        Apply For A Job
    </div>
    <br />
    <!--<div style="font-size:x-large; color:#ff0000;">
    This page is under construction. Please call (801) 785-8188 to apply. Hitting submit on this page will NOT do anything yet. Thank you.
    </div>-->
    <br />
    <div id="application">
        <table>
            <tr>
                <td class="labels">
                    Your Name:&nbsp
                    <br />
                    <br />
                </td>
                <td class="inputs">
                    <asp:TextBox ID="tbxName" runat="server" Width="300px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator"
                        ControlToValidate="tbxName">Required.</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    Social Security NO:&nbsp
                    <br />
                    <br />
                </td>
                <td class="inputs">
                    <asp:TextBox ID="tbxSocialSecurity" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbxSocialSecurity"
                        ErrorMessage="RegularExpressionValidator" ValidationExpression="\d{3}-\d{2}-\d{4}">Invalid SSN.</asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbxSocialSecurity"
                        ErrorMessage="RequiredFieldValidator">Required.</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="labels">
                    <u>Present Address</u>&nbsp
                    <br />
                </td>
                <td class="inputs">
                </td>
            </tr>
            <tr>
                <td class="labels">
                    Street:&nbsp
                    <br />
                </td>
                <td class="inputs">
                    <asp:TextBox ID="tbxPresentStreet" runat="server" Width="300px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbxPresentStreet"
                        ErrorMessage="RequiredFieldValidator">Required.</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="labels">
                    City:&nbsp
                    <br />
                </td>
                <td class="inputs">
                    <asp:TextBox ID="tbxPresentCity" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbxPresentCity"
                        ErrorMessage="RequiredFieldValidator">Required.</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="labels">
                    State:&nbsp
                    <br />
                </td>
                <td class="inputs">
                    <asp:DropDownList ID="ddlPresentState" runat="server">
                        <asp:ListItem>Alabama</asp:ListItem>
                        <asp:ListItem>Alaska</asp:ListItem>
                        <asp:ListItem>Arizona</asp:ListItem>
                        <asp:ListItem>Arkansas</asp:ListItem>
                        <asp:ListItem>California</asp:ListItem>
                        <asp:ListItem>Colorado</asp:ListItem>
                        <asp:ListItem>Connecticut</asp:ListItem>
                        <asp:ListItem>Delaware</asp:ListItem>
                        <asp:ListItem>Florida</asp:ListItem>
                        <asp:ListItem>Georgia</asp:ListItem>
                        <asp:ListItem>Hawaii</asp:ListItem>
                        <asp:ListItem>Idaho</asp:ListItem>
                        <asp:ListItem>Illinois</asp:ListItem>
                        <asp:ListItem>Indiana</asp:ListItem>
                        <asp:ListItem>Iowa</asp:ListItem>
                        <asp:ListItem>Kansas</asp:ListItem>
                        <asp:ListItem>Kentucky</asp:ListItem>
                        <asp:ListItem>Louisiana</asp:ListItem>
                        <asp:ListItem>Maine</asp:ListItem>
                        <asp:ListItem>Maryland</asp:ListItem>
                        <asp:ListItem>Massachusetts</asp:ListItem>
                        <asp:ListItem>Michigan</asp:ListItem>
                        <asp:ListItem>Minnesota</asp:ListItem>
                        <asp:ListItem>Mississippi</asp:ListItem>
                        <asp:ListItem>Missouri</asp:ListItem>
                        <asp:ListItem>Montana</asp:ListItem>
                        <asp:ListItem>Nebraska</asp:ListItem>
                        <asp:ListItem>Nevada</asp:ListItem>
                        <asp:ListItem>New Hampshire</asp:ListItem>
                        <asp:ListItem>New Jersey</asp:ListItem>
                        <asp:ListItem>New Mexico</asp:ListItem>
                        <asp:ListItem>New York</asp:ListItem>
                        <asp:ListItem>North Carolina</asp:ListItem>
                        <asp:ListItem>North Dakota</asp:ListItem>
                        <asp:ListItem>Ohio</asp:ListItem>
                        <asp:ListItem>Oklahoma</asp:ListItem>
                        <asp:ListItem>Oregon</asp:ListItem>
                        <asp:ListItem>Pennsylvania</asp:ListItem>
                        <asp:ListItem>Rhode Island</asp:ListItem>
                        <asp:ListItem>South Carolina</asp:ListItem>
                        <asp:ListItem>South Dakota</asp:ListItem>
                        <asp:ListItem>Tennessee</asp:ListItem>
                        <asp:ListItem>Texas</asp:ListItem>
                        <asp:ListItem Selected="True">Utah</asp:ListItem>
                        <asp:ListItem>Vermont</asp:ListItem>
                        <asp:ListItem>Virginia</asp:ListItem>
                        <asp:ListItem>Washington</asp:ListItem>
                        <asp:ListItem>West Virginia</asp:ListItem>
                        <asp:ListItem>Wisconsin</asp:ListItem>
                        <asp:ListItem>Wyoming</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    Zip:&nbsp
                    <br />
                    <br />
                </td>
                <td class="inputs">
                    <asp:TextBox ID="tbxPresentZip" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="tbxPresentZip"
                        ErrorMessage="RegularExpressionValidator" ValidationExpression="\d{5}(-\d{4})?">Invalid Zip Code.</asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="tbxPresentZip"
                        ErrorMessage="RequiredFieldValidator">Required.</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="labels">
                    <u>Permanent Address</u>&nbsp
                    <br />
                </td>
                <td class="inputs">
                </td>
            </tr>
            <tr>
                <td class="labels">
                    Street:&nbsp
                    <br />
                </td>
                <td class="inputs">
                    <asp:TextBox ID="tbxPermanentStreet" runat="server" Width="300px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tbxPermanentStreet"
                        ErrorMessage="RequiredFieldValidator">Required.</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="labels">
                    City:&nbsp
                    <br />
                </td>
                <td class="inputs">
                    <asp:TextBox ID="tbxPermanentCity" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tbxPermanentCity"
                        ErrorMessage="RequiredFieldValidator">Required.</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="labels">
                    State:&nbsp
                    <br />
                </td>
                <td class="inputs">
                    <asp:DropDownList ID="ddlPermanentState" runat="server">
                        <asp:ListItem>Alabama</asp:ListItem>
                        <asp:ListItem>Alaska</asp:ListItem>
                        <asp:ListItem>Arizona</asp:ListItem>
                        <asp:ListItem>Arkansas</asp:ListItem>
                        <asp:ListItem>California</asp:ListItem>
                        <asp:ListItem>Colorado</asp:ListItem>
                        <asp:ListItem>Connecticut</asp:ListItem>
                        <asp:ListItem>Delaware</asp:ListItem>
                        <asp:ListItem>Florida</asp:ListItem>
                        <asp:ListItem>Georgia</asp:ListItem>
                        <asp:ListItem>Hawaii</asp:ListItem>
                        <asp:ListItem>Idaho</asp:ListItem>
                        <asp:ListItem>Illinois</asp:ListItem>
                        <asp:ListItem>Indiana</asp:ListItem>
                        <asp:ListItem>Iowa</asp:ListItem>
                        <asp:ListItem>Kansas</asp:ListItem>
                        <asp:ListItem>Kentucky</asp:ListItem>
                        <asp:ListItem>Louisiana</asp:ListItem>
                        <asp:ListItem>Maine</asp:ListItem>
                        <asp:ListItem>Maryland</asp:ListItem>
                        <asp:ListItem>Massachusetts</asp:ListItem>
                        <asp:ListItem>Michigan</asp:ListItem>
                        <asp:ListItem>Minnesota</asp:ListItem>
                        <asp:ListItem>Mississippi</asp:ListItem>
                        <asp:ListItem>Missouri</asp:ListItem>
                        <asp:ListItem>Montana</asp:ListItem>
                        <asp:ListItem>Nebraska</asp:ListItem>
                        <asp:ListItem>Nevada</asp:ListItem>
                        <asp:ListItem>New Hampshire</asp:ListItem>
                        <asp:ListItem>New Jersey</asp:ListItem>
                        <asp:ListItem>New Mexico</asp:ListItem>
                        <asp:ListItem>New York</asp:ListItem>
                        <asp:ListItem>North Carolina</asp:ListItem>
                        <asp:ListItem>North Dakota</asp:ListItem>
                        <asp:ListItem>Ohio</asp:ListItem>
                        <asp:ListItem>Oklahoma</asp:ListItem>
                        <asp:ListItem>Oregon</asp:ListItem>
                        <asp:ListItem>Pennsylvania</asp:ListItem>
                        <asp:ListItem>Rhode Island</asp:ListItem>
                        <asp:ListItem>South Carolina</asp:ListItem>
                        <asp:ListItem>South Dakota</asp:ListItem>
                        <asp:ListItem>Tennessee</asp:ListItem>
                        <asp:ListItem>Texas</asp:ListItem>
                        <asp:ListItem Selected="True">Utah</asp:ListItem>
                        <asp:ListItem>Vermont</asp:ListItem>
                        <asp:ListItem>Virginia</asp:ListItem>
                        <asp:ListItem>Washington</asp:ListItem>
                        <asp:ListItem>West Virginia</asp:ListItem>
                        <asp:ListItem>Wisconsin</asp:ListItem>
                        <asp:ListItem>Wyoming</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    Zip:&nbsp
                    <br />
                    <br />
                </td>
                <td class="inputs">
                    <asp:TextBox ID="tbxPermanentZip" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="tbxPermanentZip"
                        ErrorMessage="RegularExpressionValidator" ValidationExpression="\d{5}(-\d{4})?">Invalid Zip Code.</asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="tbxPermanentZip"
                        ErrorMessage="RequiredFieldValidator">Required.</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="labels">
                    Phone #:&nbsp
                    <br />
                    <br />
                </td>
                <td class="inputs">
                    <asp:TextBox ID="tbxPhoneNumber" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="tbxPhoneNumber"
                        ErrorMessage="RegularExpressionValidator" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}">Invalid Phone Number.</asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="tbxPhoneNumber"
                        ErrorMessage="RequiredFieldValidator">Required.</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="labels">
                    Referred By:&nbsp
                    <br />
                    <br />
                </td>
                <td class="inputs">
                    <asp:TextBox ID="tbxReferredBy" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    Position Desired:&nbsp
                    <br />
                    <br />
                </td>
                <td class="inputs">
                    <asp:TextBox ID="tbxPositionDesired" runat="server" Width="300px" BackColor="#E0E0E0"
                        Font-Bold="True" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    Date you can start:&nbsp
                    <br />
                    <br />
                </td>
                <td class="inputs">
                    <asp:TextBox ID="tbxDateCanStart" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="tbxDateCanStart"
                        ErrorMessage="RequiredFieldValidator">Required.</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="labels">
                    Desired Wage:&nbsp
                    <br />
                    <br />
                </td>
                <td class="inputs">
                    <asp:TextBox ID="tbxDesiredWage" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="labels" style="height: 22px">
                    Are you currently emplyed?&nbsp
                    <br />
                    <br />
                </td>
                <td class="inputs" style="height: 22px">
                    <asp:RadioButton ID="rbtnCurrentlyEmployed" runat="server" Text="Yes" GroupName="Currently Employed"
                        Checked="True" />&nbsp&nbsp&nbsp<asp:RadioButton ID="rbtnCurrentlyUnemployed" runat="server"
                            Text="No" GroupName="Currently Employed" />
                </td>
            </tr>
            <tr>
                <td class="labels">
                    If so may we inquire of your present employer?&nbsp
                    <br />
                    <br />
                </td>
                <td class="inputs">
                    <asp:RadioButton ID="rbtnCurrentEmployerYes" runat="server" Text="Yes" GroupName="Inquire"
                        Checked="True" />&nbsp&nbsp&nbsp<asp:RadioButton ID="rbtnCurrentEmployerNo" runat="server"
                            Text="No" GroupName="Inquire" />
                </td>
            </tr>
            <tr>
                <td class="labels">
                    Ever applied to Ford's Cleaning before?&nbsp
                    <br />
                    <br />
                </td>
                <td class="inputs">
                    <asp:RadioButton ID="rbtnAppliedBefore" runat="server" Text="Yes" GroupName="Applied Before"
                        Checked="True" />&nbsp&nbsp&nbsp<asp:RadioButton ID="rbtnHaventAppliedBefore" runat="server"
                            Text="No" GroupName="Applied Before" />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="border-top: solid 1px #ff0000;">
                    <br />
                </td>
            </tr>
            <tr>
                <td class="labels">
                    <u>Former Employer #1:</u>&nbsp
                    <br />
                </td>
                <td class="inputs">
                </td>
            </tr>
            <tr>
                <td class="labels">
                    Date Job Began:&nbsp
                    <br />
                </td>
                <td class="inputs">
                    <asp:TextBox ID="tbxDateJobBegan1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    Date Job Ended:&nbsp
                    <br />
                </td>
                <td class="inputs">
                    <asp:TextBox ID="tbxDateJobEnded1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    Name of Employer:&nbsp
                    <br />
                </td>
                <td class="inputs">
                    <asp:TextBox ID="tbxEmployerName1" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    Wage:&nbsp
                    <br />
                </td>
                <td class="inputs">
                    <asp:TextBox ID="tbxEmployerWage1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    Position Held:&nbsp
                    <br />
                </td>
                <td class="inputs">
                    <asp:TextBox ID="tbxPositionHeld1" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    Reason For Leaving:&nbsp
                    <br />
                    <br />
                </td>
                <td class="inputs">
                    <asp:TextBox ID="tbxReasonForLeaving1" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    <u>Former Employer #2:</u>&nbsp
                    <br />
                </td>
                <td class="inputs">
                </td>
            </tr>
            <tr>
                <td class="labels">
                    Date Job Began:&nbsp
                    <br />
                </td>
                <td class="inputs">
                    <asp:TextBox ID="tbxDateJobBegan2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    Date Job Ended:&nbsp
                    <br />
                </td>
                <td class="inputs">
                    <asp:TextBox ID="tbxDateJobEnded2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    Name of Employer:&nbsp
                    <br />
                </td>
                <td class="inputs">
                    <asp:TextBox ID="tbxEmployerName2" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    Wage:&nbsp
                    <br />
                </td>
                <td class="inputs">
                    <asp:TextBox ID="tbxEmployerWage2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    Position Held:&nbsp
                    <br />
                </td>
                <td class="inputs">
                    <asp:TextBox ID="tbxPositionHeld2" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    Reason For Leaving:&nbsp
                    <br />
                    <br />
                </td>
                <td class="inputs">
                    <asp:TextBox ID="tbxReasonForLeaving2" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    <u>Former Employer #3:</u>&nbsp
                    <br />
                </td>
                <td class="inputs">
                </td>
            </tr>
            <tr>
                <td class="labels">
                    Date Job Began:&nbsp
                    <br />
                </td>
                <td class="inputs">
                    <asp:TextBox ID="tbxDateJobBegan3" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    Date Job Ended:&nbsp
                    <br />
                </td>
                <td class="inputs">
                    <asp:TextBox ID="tbxDateJobEnded3" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    Name of Employer:&nbsp
                    <br />
                </td>
                <td class="inputs">
                    <asp:TextBox ID="tbxEmployerName3" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    Wage:&nbsp
                    <br />
                </td>
                <td class="inputs">
                    <asp:TextBox ID="tbxEmployerWage3" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    Position Held:&nbsp
                    <br />
                </td>
                <td class="inputs">
                    <asp:TextBox ID="tbxPositionHeld3" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="labels">
                    Reason For Leaving:&nbsp
                    <br />
                    <br />
                    <br />
                </td>
                <td class="inputs">
                    <asp:TextBox ID="tbxReasonForLeaving3" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center; border-top: solid 1px #ff0000;">
                    <span style="color: Red; font-size: smaller;">*You must have three references not related
                        to you, whom you've known at least one year.</span>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="labels">
                    <u>Reference #1</u>&nbsp
                    <br />
                </td>
                <td class="inputs">
                </td>
            </tr>
            <tr>
                <td class="labels">
                    Name:&nbsp
                    <br />
                </td>
                <td class="inputs">
                    <asp:TextBox ID="tbxReferenceName1" runat="server" Width="300px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="tbxReferenceName1"
                        ErrorMessage="RequiredFieldValidator">Required.</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="labels">
                    Address:&nbsp
                    <br />
                </td>
                <td class="inputs">
                    <asp:TextBox ID="tbxReferenceAddress1" runat="server" Width="300px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="tbxReferenceAddress1"
                        ErrorMessage="RequiredFieldValidator">Required.</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="labels">
                    Phone #:&nbsp
                    <br />
                    <br />
                </td>
                <td class="inputs">
                    <asp:TextBox ID="tbxReferencePhone1" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="tbxReferencePhone1"
                        ErrorMessage="RegularExpressionValidator" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}">Invalid Phone Number.</asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="tbxReferencePhone1"
                        ErrorMessage="RequiredFieldValidator">Required.</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="labels">
                    <u>Reference #2</u>&nbsp
                    <br />
                </td>
                <td class="inputs">
                </td>
            </tr>
            <tr>
                <td class="labels">
                    Name:&nbsp
                    <br />
                </td>
                <td class="inputs">
                    <asp:TextBox ID="tbxReferenceName2" runat="server" Width="300px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="tbxReferenceName2"
                        ErrorMessage="RequiredFieldValidator">Required.</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="labels">
                    Address:&nbsp
                    <br />
                </td>
                <td class="inputs">
                    <asp:TextBox ID="tbxReferenceAddress2" runat="server" Width="300px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="tbxReferenceAddress2"
                        ErrorMessage="RequiredFieldValidator">Required.</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="labels">
                    Phone #:&nbsp
                    <br />
                    <br />
                </td>
                <td class="inputs">
                    <asp:TextBox ID="tbxReferencePhone2" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="tbxReferencePhone2"
                        ErrorMessage="RegularExpressionValidator" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}">Invalid Phone Number.</asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="tbxReferencePhone2"
                        ErrorMessage="RequiredFieldValidator">Required.</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="labels">
                    <u>Reference #3</u>&nbsp
                    <br />
                </td>
                <td class="inputs">
                </td>
            </tr>
            <tr>
                <td class="labels">
                    Name:&nbsp
                    <br />
                </td>
                <td class="inputs">
                    <asp:TextBox ID="tbxReferenceName3" runat="server" Width="300px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="tbxReferenceName3"
                        ErrorMessage="RequiredFieldValidator">Required.</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="labels">
                    Address:&nbsp
                    <br />
                </td>
                <td class="inputs">
                    <asp:TextBox ID="tbxReferenceAddress3" runat="server" Width="300px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="tbxReferenceAddress3"
                        ErrorMessage="RequiredFieldValidator">Required.</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="labels">
                    Phone #:&nbsp
                    <br />
                    <br />
                </td>
                <td class="inputs">
                    <asp:TextBox ID="tbxReferencePhone3" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="tbxReferencePhone3"
                        ErrorMessage="RegularExpressionValidator" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}">Invalid Phone Number.</asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="tbxReferencePhone3"
                        ErrorMessage="RequiredFieldValidator">Required.</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td colspan="2" style="border-top: solid 1px #ff0000;">
                    <center>
                    <br />
                        <asp:Image ID="imgVerify" runat="server" /><br />
                        Please enter what you see above in the box below.<br />
                        <asp:TextBox ID="tbxVerify" runat="server"></asp:TextBox><div style="color: Red;">
                            <span id="requiredAuthentication" runat="server"></span>&nbsp;</div>
                    </center>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="color: #ff0000; border-top: solid 1px #ff0000;">
                    <h2>
                        Authorization Agreement
                    </h2>
                    <div style="text-align: center; color: #ff0000;">
                        <textarea id="taAgreement" cols="75" rows="10" readonly="readOnly">
    You certify that the facts contained in this application are true and complete to the best of your knowledge and understand that, if employed, falsified statements on this application shall be grounds for dismissal.
    You authorize investigation of all statements contained herein and the references and employers listed above to give Ford's Cleaning any and all information concerning my previous employment and any pertinent information they may have, personal or otherwise, and release the company from all liability for any damage that may result from utilization of such information.
    You also understand and agree that no representative of the company has any authority to enter into any agreement for employment for any specified period of time, or to make any agreement contrary to the foregoing, unless it is in writing and signed by an authorized company representative.
    This waiver does not permit the release or use of disability-related or medical information in a manner prohibited by the Americans with Disabilities Act (ADA) and other relevant federal and state laws.
                        </textarea>
                        <div style="text-align: right;">
                            <span id="requiredagree" runat="server"></span>&nbsp &nbsp &nbsp &nbsp;<asp:CheckBox
                                ID="cbxIAgree" runat="server" Text="I Agree." />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                        </div>
                        <br />
                        <br />
                    </div>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit Application" OnClick="btnSubmit_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
