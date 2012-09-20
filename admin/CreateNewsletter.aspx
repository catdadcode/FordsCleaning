<%@ Page Language="C#" MasterPageFile="~/templates/main.master" AutoEventWireup="true"
    CodeFile="CreateNewsletter.aspx.cs" Inherits="admin_CreateNewsletter" Title="Create Newsletter"
    ValidateRequest="false" %>

<%@ Register Assembly="RichTextEditor" Namespace="AjaxControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td>
                <h2>
                    Create Newsletter</h2>
                <br />
                Subject:
                <asp:TextBox ID="tbxSubject" Width="300px" runat="server"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbxSubject"
                    ErrorMessage="RequiredFieldValidator">* Subject Required</asp:RequiredFieldValidator><br />
                New Image:
                <asp:FileUpload ID="fuContentImage" runat="server" />
                <asp:Button ID="btnUpload" runat="server" Text="Upload & Add" OnClick="btnUpload_Click"
                    CausesValidation="False" OnClientClick="CopyText()" />
                <br />
                Existing Image:
                <asp:DropDownList Width="200" ID="ddlExistingImages" runat="server">
                    <asp:ListItem>Not Selected</asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="btnAddImage" runat="server" Text="Add Image" OnClick="btnAddImage_Click"
                    CausesValidation="False" OnClientClick="CopyText()" />
                <br />
                <br />
                <cc1:RichTextEditor ID="rteBody" BackColor="#6FAEE7" Width="475" Height="300" runat="server">
                </cc1:RichTextEditor>
                <br />
                <asp:Button ID="btnSendNewsletter" OnClientClick="CopyText()" runat="server" Text="Send Newsletter"
                    OnClick="btnSendNewsletter_Click" />
            </td>
            <td valign="middle" style="border-left: solid 3px #aa0000; padding-left: 35px;">
                <center>
                    <div id="Subscribers" runat="server">
                    </div>
                    <center>
                        <asp:Button ID="btnAddUsers" runat="server" Text="Add Subscribers" UseSubmitBehavior="false"
                            PostBackUrl="http://www.fordscleaning.com/Newsletter.aspx" CausesValidation="false"
                            OnClick="btnAddUsers_Click" Width="150px" />
                        <br />
                        <br />
                    </center>
                    <asp:ListBox ID="lbxSubscribers" Width="200px" Height="450px" runat="server" SelectionMode="Multiple">
                    </asp:ListBox>
                    <br />
                    <br />
                    <asp:Button ID="btnDelete" runat="server" CausesValidation="False" OnClick="btnDelete_Click"
                        Text="Delete Selected" Width="150px" /></center>
            </td>
        </tr>
    </table>
</asp:Content>
