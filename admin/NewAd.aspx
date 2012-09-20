<%@ Page Language="C#" MasterPageFile="~/templates/main.master" AutoEventWireup="true"
    CodeFile="NewAd.aspx.cs" Inherits="fordscleaning_admin_NewAd" Title="New Advertisement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="contenttitle">
        <center>Create New Advertisement</center>
    </div>
    <br />
    <hr />
    <div style="color:Red; font-size: 12px;">* You are limited to a total of ten advertisements. After that you must delete one to add another.</div>
    <br />
    Enter advertisement URL (the place you want the ad to link to):<br />
    <asp:TextBox ID="tbxURL" Width="500px" runat="server"></asp:TextBox>
    <br />
    <br />
    Upload advertisement image:<br />
    <asp:FileUpload ID="fuAdImage" runat="server" />
    <br />
    <br />
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
</asp:Content>
