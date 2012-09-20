<%@ Page Language="C#" MasterPageFile="~/templates/main.master" AutoEventWireup="true"
    CodeFile="login.aspx.cs" Inherits="fordscleaning_login" Title="Administrator Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <center>
            <asp:LoginView ID="LoginView1" runat="server">
                <LoggedInTemplate>
                    <div class="panelTitle">
                        Logged In
                    </div>
                    <div class="panel">
                        <asp:LoginStatus ID="LoginStatus1" runat="server" />
                        of
                        <asp:LoginName ID="LoginName1" runat="server" />
                    </div>
                </LoggedInTemplate>
                <AnonymousTemplate>
                    <div class="panelTitle">
                        Administration
                    </div>
                    <div class="panel">
                        <center>
                            <asp:Login ID="Login1" runat="server"
                                OnAuthenticate="Login1_Authenticate" VisibleWhenLoggedIn="False">
                            </asp:Login>
                        </center>
                    </div>
                </AnonymousTemplate>
            </asp:LoginView>
        </center>
</asp:Content>
