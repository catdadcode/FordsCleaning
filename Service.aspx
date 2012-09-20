<%@ Page Language="C#" MasterPageFile="~/templates/main.master" AutoEventWireup="true"
    CodeFile="Service.aspx.cs" Inherits="fordscleaning_Service" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header">
        <center>
            <div id="ServiceTitle" runat="server">
            </div>
        </center>
    </div>
    <br />
    <br />
    <table>
        <tr>
            <td>
                <div id="ServiceBody" runat="server">
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
