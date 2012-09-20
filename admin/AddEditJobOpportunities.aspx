<%@ Page Language="C#" MasterPageFile="~/templates/main.master" AutoEventWireup="true"
    CodeFile="AddEditJobOpportunities.aspx.cs" ValidateRequest="false" Inherits="fordscleaning_admin_AddEditJobOpportunities"
    Title="Add/Edit Job" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="addOrEdit" class="header" runat="server">
    </div>
    <asp:CheckBox ID="cbxDeleteJob" runat="server" Text="Delete Job" AutoPostBack="True"
        OnCheckedChanged="cbxDeleteJob_CheckedChanged" Visible="False" /><br />
    <br />
    Job Name:
    <asp:TextBox ID="tbxName" runat="server" Width="308px"></asp:TextBox>
    <br />
    <br />
    Image:
    <asp:FileUpload ID="fuImage" runat="server" />
    <br />
    <div id="JobImage" runat="server">
    </div>
    <asp:CheckBox ID="cbxDeleteImage" runat="server" Text="Delete Image" AutoPostBack="True"
        OnCheckedChanged="cbxDeleteImage_CheckedChanged" Visible="False" />
    <br />
    <br />
    Job Description:
    <br />
    <table>
        <tr>
            <td>
                <asp:TextBox ID="tbxSummary" runat="server" Height="250px" TextMode="MultiLine" Width="450px"></asp:TextBox><br />
            </td>
            <td>
                <div class="HelpBox">
                    <center>
                    <h3>FONT TAGS</h3>
                    <br />
                    &#60b&#62 <b>text to be bolded</b> &#60/b&#62
                    <br />
                    <br />
                    &#60i&#62 <i>text to be italicized</i> &#60/i&#62
                    <br />
                    <br />
                    &#60u&#62 <u>text to be underlined</u> &#60/b&#62
                    </center>
                    <br />
                    <br />                    
                    &#60a href="http://www.google.com"&#62 <br /> &nbsp &nbsp &nbsp &nbsp &nbsp<a href="http://www.google.com">text to be linked</a> <br /> &#60/a&#62
                </div>
            </td>
        </tr>
    </table>
    <br />
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
</asp:Content>
