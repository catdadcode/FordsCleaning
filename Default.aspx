<%@ Page Language="C#" MasterPageFile="~/templates/main.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="fordscleaning_Default" Title="Welcome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td style="vertical-align: top;">
                <div class="blog">
                    <table border="0" cellspacing="0" width="100%">
                        <tr>
                            <td>
                                <div class="blogtitle">
                                    <span id="blogtitle" runat="server"></span>
                                </div>
                                <div id="blogdate" runat="server">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div class="blogcontent">
                                    <div id="blogcontent" runat="server">
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
            <td style="width: 150px; margin-left: 10px; vertical-align: top; text-align: center;">
                <div id="AdSpace" runat="server">
                </div>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <div style="text-align: left;">
        <img alt="ATM" title="ATM" src="http://www.credit-card-logos.com/images/multiple_credit-card-logos-2/credit_card_paypal_logos_4.gif"
            width="254" height="30" border="0" />
    </div>
</asp:Content>
