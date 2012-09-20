<%@ Page Language="C#" MasterPageFile="~/templates/Main.master" AutoEventWireup="true"
    CodeFile="AddEditBlog.aspx.cs" ValidateRequest="false" Inherits="admin_AddEditBlog"
    Title="Add/Edit Blog Post" %>

<%@ Register Assembly="RichTextEditor" Namespace="AjaxControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="contenttitle">
        <div id="AddEdit">
            Add/Edit Blog Post</div>
    </div>
    <br />
    <br />
    <div class="blogcontent">
        <asp:CheckBox ID="cbxDelete" runat="server" AutoPostBack="True" OnCheckedChanged="cbxDelete_CheckedChanged"
            Text="Delete" />
        <br />
        <br />
        Blog Title:
        <asp:TextBox ID="tbxTitle" Width="295px" runat="server" MaxLength="35"></asp:TextBox>
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
        Body:
        <br />
        <cc1:RichTextEditor ID="rteBody" BackColor="#6FAEE7" Width="715" Height="300" runat="server">
        </cc1:RichTextEditor>
        <br />
        <asp:Button ID="btnSubmit" runat="server" OnClientClick="CopyText()" Text="Submit" OnClick="btnSubmit_Click" />
    </div>
    <br />
    <br />
</asp:Content>
