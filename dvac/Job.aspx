<%@ Page Language="C#" MasterPageFile="~/template.master" AutoEventWireup="true"
    CodeFile="Job.aspx.cs" Inherits="Job" Title="Add/Edit/View Scheduled Job" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <h2 id="formtitle" style="text-align: center; color: #ffffff;" runat="server">
    </h2>
    <div style="color: #ffffff; padding: 10px;" id="JobForm" runat="server">
        <asp:CheckBox ID="cbxDeleteJob" Text="Delete Job" runat="server" AutoPostBack="True"
            ForeColor="White" OnCheckedChanged="cbxDeleteJob_CheckedChanged" /><br />
        &nbsp;&nbsp;
        <asp:RadioButtonList ID="rblNewExisting" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblNewExisting_SelectedIndexChanged"
            RepeatDirection="Horizontal">
            <asp:ListItem Selected="True">New Customer</asp:ListItem>
            <asp:ListItem>Existing Customer</asp:ListItem>
        </asp:RadioButtonList><br />
        <div style="border: solid 1px #bb0000; padding: 10px; width: 400px;" id="NewCustomerForm"
            runat="server">
            Customer Name:
            <asp:TextBox ID="tbxName" runat="server" Width="250px"></asp:TextBox>
            <span style="color: #ff0000;">*</span><br />
            <br />
            Phone:
            <asp:TextBox ID="tbxPhone" runat="server" Width="200px"></asp:TextBox><span style="color: #ff0000;">*</span><br />
            <br />
            Email:
            <asp:TextBox ID="tbxEmail" runat="server" Width="250px"></asp:TextBox>
        </div>
        <div style="border: solid 1px #bb0000; padding: 10px; width: 725px;" id="ExistingCustomerSearch"
            runat="server">
            <span style="font-size: 14px; color: #ffffff;">Type all or part of the name you wish
                to search for.</span><br />
            <asp:TextBox ID="tbxSearch" runat="server" Width="250px"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" /><br />
            <br />
            <table>
                <tr>
                    <td valign="top">
                        <asp:ListBox ID="lbxCustomers" runat="server" Height="200px" Width="350px" AutoPostBack="True" OnSelectedIndexChanged="lbxCustomers_SelectedIndexChanged"></asp:ListBox><br />
                        <span style="font-size: 14px; color: #ffffff;">Select from the list of existing customers.</span>
                    </td>
                    <td valign="top">
                    <div id="CustomerInfoBox" style="width:330px; height:180px; padding:10px; color:#ffffff; background-color:#883333;" runat="server">
                    </div>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <asp:DropDownList ID="ddlJobType" runat="server" Width="250px">
            <asp:ListItem>Select Job Type</asp:ListItem>
            <asp:ListItem>Residential Cleaning</asp:ListItem>
            <asp:ListItem>Office Cleaning</asp:ListItem>
            <asp:ListItem>New Construction Cleaning</asp:ListItem>
            <asp:ListItem>Window Cleaning</asp:ListItem>
            <asp:ListItem>Carpet Cleaning</asp:ListItem>
            <asp:ListItem>Tile Cleaning</asp:ListItem>
            <asp:ListItem>Carpet &amp; Tile Cleaning</asp:ListItem>
            <asp:ListItem>Power Washing</asp:ListItem>
            <asp:ListItem>Deep Clean</asp:ListItem>
            <asp:ListItem>Prep Clean</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        Job Address:<br />
        <asp:TextBox ID="tbxAddress" runat="server" Width="500px"></asp:TextBox>
        <br />
        <br />
        Job Description:
        <br />
        <asp:TextBox ID="tbxJobDescription" runat="server" TextMode="multiline" Height="150px"
            Width="500px"></asp:TextBox>
        <br />
        <br />
        Additional Job Notes:
        <br />
        <asp:TextBox ID="tbxJobNotes" runat="server" TextMode="multiLine" Width="500px" Height="100px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
    </div>
    <div style="padding: 10px; color:#ffffff; background-color:#883333;" id="JobView" runat="server">
    </div>
</asp:Content>
