<%@ Page Language="C#" MasterPageFile="~/templates/main.master" AutoEventWireup="true"
    CodeFile="RequestBid.aspx.cs" Inherits="fordscleaning_RequestBid" Title="Request a Bid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2 align="center">
        Get A Free Cleaning Quote</h2>
    <div>
        <table>
            <tr>
                <td align="left" valign="top">
                    Name:
                </td>
                <td align="left">
                    <asp:TextBox ID="tbxName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbxName"
                        ErrorMessage="RequiredFieldValidator">* Required</asp:RequiredFieldValidator><br />
                    <br />
                </td>
            </tr>
            <tr>
                <td align="left" valign="top">
                    Phone:</td>
                <td align="left">
                    <asp:TextBox ID="tbxPhone" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbxPhone"
                        ErrorMessage="RequiredFieldValidator">* Required</asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="RegularExpressionValidator"
                        ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}" ControlToValidate="tbxPhone">* Invalid Phone Number</asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td colspan="2" align="left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="left" valign="top">
                    Email:
                </td>
                <td align="left">
                    <asp:TextBox ID="tbxEmail" runat="server" Width="252px"></asp:TextBox><br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbxEmail"
                        ErrorMessage="RegularExpressionValidator" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">* Invalid Email Address</asp:RegularExpressionValidator><br />
                </td>
            </tr>
            <tr>
                <td align="left" valign="top" colspan="2">
                    Where did you hear about us?
                    <br />
                    <asp:DropDownList ID="ddlHearAboutUs" runat="server">
                        <asp:ListItem>Not Selected</asp:ListItem>
                        <asp:ListItem>From a friend</asp:ListItem>
                        <asp:ListItem>Magazine Ad</asp:ListItem>
                        <asp:ListItem>Internet Ad</asp:ListItem>
                        <asp:ListItem>Flyer</asp:ListItem>
                        <asp:ListItem>Phone Book</asp:ListItem>
                        <asp:ListItem>Business Card</asp:ListItem>
                        <asp:ListItem>Other</asp:ListItem>
                    </asp:DropDownList><br />
                    &nbsp;<asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="ddlHearAboutUs"
                        ErrorMessage="CustomValidator" OnServerValidate="CustomValidator1_ServerValidate"
                        Display="Dynamic" ValidateEmptyText="True">* Please make a selction</asp:CustomValidator><br />
                </td>
            </tr>
            <tr>
                <td align="left" valign="top" colspan="2">
                    What type of cleaning are you looking for?
                    <br />
                    <asp:DropDownList ID="ddlCleaningType" runat="server">
                        <asp:ListItem>Not Selected</asp:ListItem>
                        <asp:ListItem>House Cleaning</asp:ListItem>
                        <asp:ListItem>Office Cleaning</asp:ListItem>
                        <asp:ListItem>Window Cleaning</asp:ListItem>
                        <asp:ListItem>Carpet Cleaning</asp:ListItem>
                        <asp:ListItem>Power Washing</asp:ListItem>
                        <asp:ListItem>Construction Cleanup</asp:ListItem>
                        <asp:ListItem>Other</asp:ListItem>
                    </asp:DropDownList><br />
                    &nbsp;<asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="ddlHearAboutUs"
                        ErrorMessage="CustomValidator" OnServerValidate="CustomValidator1_ServerValidate"
                        Display="Dynamic" ValidateEmptyText="True">* Please make a selction</asp:CustomValidator><br />
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2">
                    Brief Description of Job:
                    <br />
                    (i.e. Approx. Sq. Ft., beds/baths, etc)<br />
                    <asp:TextBox ID="tbxDescription" runat="server" Height="218px" Width="365px" TextMode="MultiLine"></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbxDescription"
                        ErrorMessage="RequiredFieldValidator">* Required</asp:RequiredFieldValidator><br />
                    <br />
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2">
                    <div style="border: solid 1px #ff0000; font-size: 15px; padding: 10px;">
                        <img src="JpegImage.aspx" />
                        <br />
                        <br />
                        Enter what you see above in the box below.
                        <br />
                        <br />
                        <asp:TextBox ID="tbxCode" runat="server"></asp:TextBox><asp:CustomValidator ID="CustomValidator3"
                            runat="server" ErrorMessage="CustomValidator" Text="* Invalid Code."></asp:CustomValidator>
                    </div>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td align="left" valign="top" colspan="2">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit Request" OnClick="btnSubmit_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
