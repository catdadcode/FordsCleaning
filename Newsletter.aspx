<%@ Page Language="C#" MasterPageFile="~/templates/main.master" AutoEventWireup="true"
    CodeFile="Newsletter.aspx.cs" Inherits="Newsletter" Title="Sign up for our newsletter!" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="loggedout" runat="server">
        <h2 style="color: #AA0000;" align="center">
            Sign up for our weekly newsletter below.</h2>
        <br />
        &nbsp &nbsp Enter your email address:
        <asp:TextBox ID="tbxEmail" runat="server" Width="200px"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbxEmail"
            ErrorMessage="RegularExpressionValidator" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">* Invalid Email Address</asp:RegularExpressionValidator><br />
        Confirm your email address:
        <asp:TextBox ID="tbxConfirmEmail" runat="server" Width="200px"></asp:TextBox>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="tbxEmail"
            ControlToValidate="tbxConfirmEmail" ErrorMessage="CompareValidator">* Email does not match</asp:CompareValidator>
        <br />
        <br />
        <img src="JpegImage.aspx" />
        <br />
        <br />
        Enter the code above in the box below.
        <br />
        <br />
        <asp:TextBox ID="tbxCode" runat="server"></asp:TextBox><asp:CustomValidator ID="CustomValidator1"
            runat="server" ErrorMessage="CustomValidator" Text="* Invalid Code. Please try again."></asp:CustomValidator>
    </div>
    <div id="loggedin" runat="server">
        <h2 style="color: #aa0000;" align="center">
            Enter a list of email address to subscribe.</h2>
        Separate addresses by semi-colons (;)<br />
        <asp:TextBox ID="tbxAddEmails" TextMode="MultiLine" Width="600px" Height="200px"
            runat="server"></asp:TextBox>
        <br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="tbxAddEmails"
            ErrorMessage="* One or more email addresses are invalid." ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*([,;]\s*\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)*"></asp:RegularExpressionValidator><br />
    </div>
    <br />
    <br />
    <asp:Button ID="btnSubmit" runat="server" Text="Sign Up!" OnClick="btnSubmit_Click" />
</asp:Content>
