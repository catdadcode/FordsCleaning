<%@ Page Language="C#" MasterPageFile="~/template.master" AutoEventWireup="true"
    CodeFile="Schedule.aspx.cs" Inherits="fordscleaning_dVAC_Schedule" Title="Schedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <center>
        <asp:Calendar ID="Calendar1" runat="server" BackColor="#FFFFCC" BorderColor="#883333"
            DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399"
            Height="500px" Width="750px" BorderWidth="1px" ShowGridLines="True" OnSelectionChanged="Calendar1_SelectionChanged">
            <SelectedDayStyle BackColor="#883333" Font-Bold="True" />
            <SelectorStyle BackColor="#FFCC66" />
            <TodayDayStyle BackColor="#EF7148" ForeColor="White" />
            <OtherMonthDayStyle ForeColor="#CC9966" />
            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
            <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
            <TitleStyle BackColor="#883333" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
            <WeekendDayStyle BackColor="Khaki" />
        </asp:Calendar>
    </center>
    <div id="dayview" runat="server">
        <br />
        <h1><div style="text-align: center; color:#ffffff;" id="daytitle" runat="server"></div></h1>
        <center>
            <div style="text-align: left; color: #ffffff; background-color: #883333; width: 730px; padding: 10px;" id="jobs" runat="server">
            </div>
        </center>
    </div>
</asp:Content>
