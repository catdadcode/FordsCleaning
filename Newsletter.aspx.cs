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
using System.Web.Mail;

public partial class Newsletter : System.Web.UI.Page
{
    Random random = new Random();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            loggedout.Visible = false;
            loggedin.Visible = true;
        }
        else
        {
            loggedout.Visible = true;
            loggedin.Visible = false;
        }

        if (!IsPostBack)
        {
            Session["CaptchaImageText"] = CaptchaImage.GenerateRandomCode(random);
        }

        if (Request.QueryString["remove"] != null)
        {
            string sRemove = Request.QueryString["remove"].ToString();
            try
            {
                DataLayer.RemoveNewsletterEmail(sRemove);

                SmtpMail.SmtpServer = "relay-hosting.secureserver.net";
                MailMessage mm = new MailMessage();
                mm.BodyFormat = MailFormat.Html;
                mm.To = "Walt@FordsCleaning.com";
                mm.From = "NoReply@FordsCleaning.com";
                mm.Subject = "Someone unsubscribed from your newsletter.";
                mm.Body = sRemove + " unsubscribed from your newsletter.";
                try
                {
                    SmtpMail.Send(mm);
                }
                catch
                { }

                Response.Write("<h3>" + sRemove + " has been removed from our list. Have a great day!</h3>");
            }
            catch
            {
                Response.Write("<h3>" + sRemove + " is not on our list or is an invalid email address.</h3>");
                DataLayer.CloseConn();
            }
            Response.Flush();
            Response.Close();
        }

        if (Request.QueryString["add"] != null)
        {
            string sAdd = Request.QueryString["add"].ToString();
            try
            {
                DataLayer.AddNewsletterEmail(sAdd);
                Response.Write("<h3>Thank you for subscribing to our newsletter!</h3><a href=\"http://www.fordscleaning.com\">(Click here to continue.)</a>");
                SmtpMail.SmtpServer = "relay-hosting.secureserver.net";

                MailMessage mm = new MailMessage();
                mm.BodyFormat = MailFormat.Html;
                mm.To = sAdd;
                mm.From = "Newsletter@Fordscleaning.com";
                mm.Subject = "Ford's Cleaning Weekly Newsletter";
                mm.Body = "This email is to inform you of your subscription to our free weekly newsletter.<br /><br />";
                mm.Body += "If you did not sign up for this or wish to discontinue for any other reason simply click the link below. Otherwise we hope you enjoy our newsletter!<br /><br />";
                mm.Body += "<a href=\"http://www.fordscleaning.com/Newsletter.aspx?remove=" + sAdd + "\">http://www.fordscleaning.com/Newsletter.aspx?remove=" + sAdd + "</a>";

                try
                {
                    SmtpMail.Send(mm);
                }
                catch
                { }

                SmtpMail.SmtpServer = "relay-hosting.secureserver.net";
                mm = new MailMessage();
                mm.BodyFormat = MailFormat.Html;
                mm.To = "Walt@FordsCleaning.com";
                mm.From = "NoReply@FordsCleaning.com";
                mm.Subject = "New Newsletter Subscription";
                mm.Body = sAdd + " subscribed to your newsletter.";
                try
                {
                    SmtpMail.Send(mm);
                }
                catch
                { }
            }
            catch
            {
                Response.Write("<h3>It seems that email address is already on our list. Thanks for being a reader!</h3><a href=\"http://www.fordscleaning.com\">(Click here to continue.)</a>");
                DataLayer.CloseConn();
            }
            Response.Flush();
            Response.Close();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (!User.Identity.IsAuthenticated)
        {
            if (tbxCode.Text == Session["CaptchaImageText"].ToString())
            {
                Response.Redirect("Newsletter.aspx?add=" + tbxEmail.Text);
            }
            else
            {
                Session["CaptchaImageText"] = CaptchaImage.GenerateRandomCode(random);
                CustomValidator1.IsValid = false;
            }
        }
        else
        {
            string[] sEmails = tbxAddEmails.Text.Split(';');
            SmtpMail.SmtpServer = "relay-hosting.secureserver.net";
            MailMessage mm;
            foreach (string s in sEmails)
            {
                try
                {
                    DataLayer.AddNewsletterEmail(s.Replace(" ", ""));
                }
                catch
                {
                    DataLayer.CloseConn();
                }
            }
            Response.Write("<h3>Emails added successfully.</h3><a href=\"Default.aspx\">(Click here to continue.)</a>");
            Response.Flush();
            Response.Close();
        }
    }
}
