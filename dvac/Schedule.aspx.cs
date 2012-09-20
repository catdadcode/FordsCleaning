using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class fordscleaning_dVAC_Schedule : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["date"] == null)
        {
            Calendar1.Visible = true;
            Calendar1.Enabled = true;
            dayview.Visible = false;
        }
        else
        {
            string sDate = Request.QueryString["date"].ToString();
            DateTime dtDate = Convert.ToDateTime(sDate);
            DataTable dt = DataLayer.GetJobsBy_Date(dtDate);
            daytitle.InnerText = sDate;
            dayview.Visible = true;
            Calendar1.Enabled = false;
            Calendar1.Visible = false;
            jobs.InnerHtml = "<hr />";
            for (int x = 7; x <= 19; x++)
            {
                if (x < 12)
                {
                    bool bFound1 = false;
                    bool bFound2 = false;
                    foreach (DataRow dr in dt.Rows)
                    {
                        DateTime dtTime = Convert.ToDateTime(dr.ItemArray[2]);
                        if (dtTime.ToString() == sDate + " " + x.ToString() + ":00:00 AM")
                        {
                            Guid gCust = new Guid(dr.ItemArray[1].ToString());
                            DataTable dtCustomer = DataLayer.GetCustomerBy_CustomerID(gCust);
                            jobs.InnerHtml += "<b>" + x.ToString() + ":00am - </b><a href=\"Job.aspx?f=view&jid=" + dr.ItemArray[0].ToString() + "\">" + dr.ItemArray[3].ToString() + "</a> for " + dtCustomer.Rows[0].ItemArray[1].ToString() + "&nbsp &nbsp &nbsp<a title=\"Edit/Delete Job\" href=\"Job.aspx?f=edit&jid=" + dr.ItemArray[0].ToString() + "\"><img border=\"0\" width=\"25\" src=\"images/write.png\" /></a> &nbsp <a title=\"Complete Job\" href=\"Job.aspx?f=complete&jid=" + dr.ItemArray[0].ToString() + "\"><img border=\"0\" width=\"25\" src=\"images/check.png\" /></a><hr />";
                            bFound1 = true;
                        }
                        if (dtTime.ToString() == sDate + " " + x.ToString() + ":30:00 AM")
                        {
                            Guid gCust = new Guid(dr.ItemArray[1].ToString());
                            DataTable dtCustomer = DataLayer.GetCustomerBy_CustomerID(gCust);
                            jobs.InnerHtml += "<b>" + x.ToString() + ":30am - </b><a href=\"Job.aspx?f=view&jid=" + dr.ItemArray[0].ToString() + "\">" + dr.ItemArray[3].ToString() + "</a> for " + dtCustomer.Rows[0].ItemArray[1].ToString() + "&nbsp &nbsp &nbsp<a title=\"Edit/Delete Job\" href=\"Job.aspx?f=edit&jid=" + dr.ItemArray[0].ToString() + "\"><img border=\"0\" width=\"25\" src=\"images/write.png\" /></a> &nbsp <a title=\"Complete Job\" href=\"Job.aspx?f=complete&jid=" + dr.ItemArray[0].ToString() + "\"><img border=\"0\" width=\"25\" src=\"images/check.png\" /></a><hr />";
                            bFound2 = true;
                        }
                    }
                    if (!bFound1)
                        jobs.InnerHtml += x.ToString() + ":00am - <a title=\"Schedule New Job\" href=\"Job.aspx?dt=" + sDate + " " + x.ToString() + ":00:00 AM\"><img border=\"0\" width=\"25\" src=\"images/plus.png\" /></a><hr />";
                    if (!bFound2)
                        jobs.InnerHtml += x.ToString() + ":30am - <a title=\"Schedule New Job\" href=\"Job.aspx?dt=" + sDate + " " + x.ToString() + ":30:00 AM\"><img border=\"0\" width=\"25\" src=\"images/plus.png\" /></a><hr />";
                }
                else if (x == 12)
                {
                    bool bFound1 = false;
                    bool bFound2 = false;
                    foreach (DataRow dr in dt.Rows)
                    {
                        DateTime dtTime = Convert.ToDateTime(dr.ItemArray[2]);
                        if (dtTime.ToString() == sDate + " " + x.ToString() + ":00:00 PM")
                        {
                            Guid gCust = new Guid(dr.ItemArray[1].ToString());
                            DataTable dtCustomer = DataLayer.GetCustomerBy_CustomerID(gCust);
                            jobs.InnerHtml += "<b>" + x.ToString() + ":00pm - </b><a href=\"Job.aspx?f=view&jid=" + dr.ItemArray[0].ToString() + "\">" + dr.ItemArray[3].ToString() + "</a> for " + dtCustomer.Rows[0].ItemArray[1].ToString() + "&nbsp &nbsp &nbsp<a title=\"Edit/Delete Job\" href=\"Job.aspx?f=edit&jid=" + dr.ItemArray[0].ToString() + "\"><img border=\"0\" width=\"25\" src=\"images/write.png\" /></a> &nbsp <a title=\"Complete Job\" href=\"Job.aspx?f=complete&jid=" + dr.ItemArray[0].ToString() + "\"><img border=\"0\" width=\"25\" src=\"images/check.png\" /></a><hr />";
                            bFound1 = true;
                        }
                        if (dtTime.ToString() == sDate + " " + x.ToString() + ":30:00 PM")
                        {
                            Guid gCust = new Guid(dr.ItemArray[1].ToString());
                            DataTable dtCustomer = DataLayer.GetCustomerBy_CustomerID(gCust);
                            jobs.InnerHtml += "<b>" + x.ToString() + ":30pm - </b><a href=\"Job.aspx?f=view&jid=" + dr.ItemArray[0].ToString() + "\">" + dr.ItemArray[3].ToString() + "</a> for " + dtCustomer.Rows[0].ItemArray[1].ToString() + "&nbsp &nbsp &nbsp<a title=\"Edit/Delete Job\" href=\"Job.aspx?f=edit&jid=" + dr.ItemArray[0].ToString() + "\"><img border=\"0\" width=\"25\" src=\"images/write.png\" /></a> &nbsp <a title=\"Complete Job\" href=\"Job.aspx?f=complete&jid=" + dr.ItemArray[0].ToString() + "\"><img border=\"0\" width=\"25\" src=\"images/check.png\" /></a><hr />";
                            bFound2 = true;
                        }
                    }
                    if (!bFound1)
                        jobs.InnerHtml += x.ToString() + ":00pm - <a title=\"Schedule New Job\" href=\"Job.aspx?dt=" + sDate + " " + x.ToString() + ":00:00 PM\"><img border=\"0\" width=\"25\" src=\"images/plus.png\" /></a><hr />";
                    if (!bFound2)
                        jobs.InnerHtml += x.ToString() + ":30pm - <a title=\"Schedule New Job\" href=\"Job.aspx?dt=" + sDate + " " + x.ToString() + ":30:00 PM\"><img border=\"0\" width=\"25\" src=\"images/plus.png\" /></a><hr />";
                }
                else if (x > 12)
                {
                    int i = x - 12;
                    bool bFound1 = false;
                    bool bFound2 = false;
                    foreach (DataRow dr in dt.Rows)
                    {
                        DateTime dtTime = Convert.ToDateTime(dr.ItemArray[2]);
                        if (dtTime.ToString() == sDate + " " + i.ToString() + ":00:00 PM")
                        {
                            Guid gCust = new Guid(dr.ItemArray[1].ToString());
                            DataTable dtCustomer = DataLayer.GetCustomerBy_CustomerID(gCust);
                            jobs.InnerHtml += "<b>" + i.ToString() + ":00pm - </b><a href=\"Job.aspx?f=view&jid=" + dr.ItemArray[0].ToString() + "\">" + dr.ItemArray[3].ToString() + "</a> for " + dtCustomer.Rows[0].ItemArray[1].ToString() + "&nbsp &nbsp &nbsp<a title=\"Edit/Delete Job\" href=\"Job.aspx?f=edit&jid=" + dr.ItemArray[0].ToString() + "\"><img border=\"0\" width=\"25\" src=\"images/write.png\" /></a> &nbsp <a title=\"Complete Job\" href=\"Job.aspx?f=complete&jid=" + dr.ItemArray[0].ToString() + "\"><img border=\"0\" width=\"25\" src=\"images/check.png\" /></a><hr />";
                            bFound1 = true;
                        }
                        if (dtTime.ToString() == sDate + " " + i.ToString() + ":30:00 PM")
                        {
                            Guid gCust = new Guid(dr.ItemArray[1].ToString());
                            DataTable dtCustomer = DataLayer.GetCustomerBy_CustomerID(gCust);
                            jobs.InnerHtml += "<b>" + i.ToString() + ":30pm - </b><a href=\"Job.aspx?f=view&jid=" + dr.ItemArray[0].ToString() + "\">" + dr.ItemArray[3].ToString() + "</a> for " + dtCustomer.Rows[0].ItemArray[1].ToString() + "&nbsp &nbsp &nbsp<a title=\"Edit/Delete Job\" href=\"Job.aspx?f=edit&jid=" + dr.ItemArray[0].ToString() + "\"><img border=\"0\" width=\"25\" src=\"images/write.png\" /></a> &nbsp <a title=\"Complete Job\" href=\"Job.aspx?f=complete&jid=" + dr.ItemArray[0].ToString() + "\"><img border=\"0\" width=\"25\" src=\"images/check.png\" /></a><hr />";
                            bFound2 = true;
                        }
                    }
                    if (!bFound1)
                        jobs.InnerHtml += i.ToString() + ":00pm - <a title=\"Schedule New Job\" href=\"Job.aspx?dt=" + sDate + " " + i.ToString() + ":00:00 PM\"><img border=\"0\" width=\"25\" src=\"images/plus.png\" /></a><hr />";
                    if (!bFound2)
                        jobs.InnerHtml += i.ToString() + ":30pm - <a title=\"Schedule New Job\" href=\"Job.aspx?dt=" + sDate + " " + i.ToString() + ":30:00 PM\"><img border=\"0\" width=\"25\" src=\"images/plus.png\" /></a><hr />";
                }
            }
        }
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        Response.Redirect("Schedule.aspx?date=" + Calendar1.SelectedDate.Month.ToString() + "/" + Calendar1.SelectedDate.Day.ToString() + "/" + Calendar1.SelectedDate.Year.ToString());
    }
}
