<%@ Page Language="C#" MasterPageFile="~/templates/main.master" AutoEventWireup="true"
    CodeFile="AddEditPromotion.aspx.cs" Inherits="fordscleaning_admin_AddEditPromotion"
    Title="Add/Edit Promotion" ValidateRequest="false" %>

<%@ Register Assembly="RichTextEditor" Namespace="AjaxControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2 style="text-align: center;">
        Add/Edit Promotion</h2>
    <hr />
    <br />
    <br />
    <asp:CheckBox ID="cbxDelete" AutoPostBack="true" Text="Delete" runat="server" OnCheckedChanged="cbxDelete_CheckedChanged" />
    <span id="pn" runat="server">Promotion Name: </span><asp:TextBox ID="tbxName" Width="150px" runat="server"></asp:TextBox>
    <br />
    <br />
    Promotion Title:
    <asp:TextBox ID="tbxTitle" Width="300px" runat="server"></asp:TextBox>
    <br />
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
        Promotion Body:
        <br />
        <cc1:RichTextEditor ID="rteBody" BackColor="#6FAEE7" Width="715" Height="300" runat="server">
        </cc1:RichTextEditor>
    <br />
    <br />
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClientClick="CopyText()" OnClick="btnSubmit_Click" />
</asp:Content>
