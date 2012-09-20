<%@ Page Language="C#" MasterPageFile="~/templates/main.master" AutoEventWireup="true"
    CodeFile="EditWelcomeMessage.aspx.cs" ValidateRequest="false" Inherits="fordscleaning_admin_EditWelcomeMessage"
    Title="Edit Welcome Message" %>

<%@ Register Assembly="RichTextEditor" Namespace="AjaxControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header">
        Edit Welcome Message
    </div>
    <br />
    Message:
    <br />
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
    Body:
    <br />
    <cc1:RichTextEditor ID="rteBody" BackColor="#6FAEE7" Width="715" Height="300" runat="server">
    </cc1:RichTextEditor>
    <br />
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClientClick="CopyText()"
        OnClick="btnSubmit_Click" />
</asp:Content>
