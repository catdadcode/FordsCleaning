using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Mail;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

public partial class fordscleaning_test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //DataTable dtSubscribers = DataLayer.RetrieveNewsletterList();

        //SmtpMail.SmtpServer = "relay-hosting.secureserver.net";

        //MailMessage mm;
        //ArrayList alFailed = new ArrayList();
        //foreach (DataRow dr in dtSubscribers.Rows)
        //{
        //    mm = new MailMessage();
        //    mm.BodyFormat = MailFormat.Html;
        //    mm.To = dr.ItemArray[0].ToString();
        //    mm.From = "Newsletter@Fordscleaning.com";
        //    mm.Subject = "Toilet Bowl Ring Removal";
        //    mm.Body = "<center><img alt=\"Ford's Cleaning & Maintenance\" src=\"http://www.fordscleaning.com/images/FordsLogo.gif\" /></center><br /><br />";
        //    mm.Body += TextBox1.Text.Replace("/n","<br />").Replace("/r","") + "<br /><br /><br />";
        //    mm.Body += "<div style=\"font-size:15px;\"><a href=\"http://www.fordscleaning.com/Newsletter.aspx?remove=" + dr.ItemArray[0].ToString() + "\">Click here to unsubscribe.</a></div>";
        //    try
        //    {
        //        SmtpMail.Send(mm);
        //    }
        //    catch
        //    {
        //        alFailed.Add(dr.ItemArray[0].ToString());
        //    }
        //}
        //Response.Write("<h2>Finished sending newsletter.</h2>");
        //if (alFailed.Count == 0)
        //{
        //    Response.Write("Every email was sent successfully!");
        //}
        //else
        //{
        //    Response.Write("Some of the emails failed when sending. Here is a list:<br /><ul>");
        //    foreach (string s in alFailed)
        //    {
        //        Response.Write("<li>" + s + "</li>");
        //    }
        //    Response.Write("</ul>");
        //}
        //Response.Write("<br /><br /><a href=\"http://www.fordscleaning.com\">(Click here to continue.)</a>");
        //Response.Flush();
        //Response.Close();
    }
}
