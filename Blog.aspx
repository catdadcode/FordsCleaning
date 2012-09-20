<%@ Page Language="C#" MasterPageFile="~/templates/Main.master" AutoEventWireup="true"
    CodeFile="Blog.aspx.cs" ValidateRequest="false" Inherits="Blog" Title="Untitled" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <br />
    <div class="blog">
        <table border="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <div class="blogtitle">
                        <span id="blogtitle" runat="server"></span>
                    </div>
                    <span id="blogdate" runat="server"></span>
                </td>
                <td align="right">
                    <span id="blogedit" runat="server"></span>
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
    <div id="comments" runat="server">
    </div>
    <br />
    <br />
    <hr style="border: solid 1px #880000;" />
    <br />
    Name:
    <asp:TextBox ID="tbxUsername" runat="server"></asp:TextBox>
    <br />
    <br />
    Personal Website:
    <asp:TextBox ID="tbxWebsite" runat="server"></asp:TextBox>
    (optional)
    <br />
    <br />
    <asp:TextBox ID="tbxAddComment" runat="server" Height="250px" TextMode="MultiLine"
        Width="450px"></asp:TextBox>
    <br />
    <br />
    <asp:Image ID="imgCode" runat="server" ImageUrl="JpegImage.aspx" /><br />
    <br />
    Enter the code above in the box below.<br />
    <br />
    <asp:TextBox ID="tbxCode" runat="server"></asp:TextBox>
    <asp:CustomValidator ID="cvCode" runat="server" ErrorMessage="CustomValidator">* Invalid Code</asp:CustomValidator><br />
    <br />
    <asp:Button ID="btnAddComment" runat="server" Text="Add Comment" OnClick="btnAddComment_Click" />
    <br />
    <br />
</asp:Content>
