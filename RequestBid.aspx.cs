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

public partial class fordscleaning_RequestBid : System.Web.UI.Page
{
    Random random = new Random();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["CaptchaImageText"] = CaptchaImage.GenerateRandomCode(random);
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (tbxCode.Text == Session["CaptchaImageText"].ToString())
        {
            if (this.IsValid)
            {
                SmtpMail.SmtpServer = "relay-hosting.secureserver.net";

                MailMessage mm = new MailMessage();
                mm.BodyFormat = MailFormat.Html;
                mm.To = "walt@fordscleaning.com";
                mm.Cc = "alex@fordscleaning.com";
                mm.From = "JobEstimator@Fordscleaning.com";
                mm.Subject = "New Job Bid Request";
                mm.Body = "You have a new job bid request.<br /><br />";
                mm.Body += "Customer Information";
                mm.Body += "<br />Name: " + tbxName.Text;
                mm.Body += "<br />Phone: " + tbxPhone.Text;
                mm.Body += "<br />Email: " + tbxEmail.Text;
                mm.Body += "<br /><br />Type of cleaning: " + ddlCleaningType.SelectedValue.ToString();
                mm.Body += "<br /><br />Brief Job Description:<br />";
                mm.Body += tbxDescription.Text;
                mm.Body += "<br /><br />How they heard about us:<br />";
                mm.Body += ddlHearAboutUs.SelectedValue.ToString();

                try
                {
                    SmtpMail.Send(mm);
                    Response.Write("<div style=\"color:#009900;text-align:center;\"><h2>REQUEST SUCCESSFUL! One of our representatives will contact you soon.</h2><a href=\"http://www.fordscleaning.com\">(Click here to continue)</a></div>");
                }
                catch
                {
                    Response.Write("<div style=\"color:#ff0000;text-align:center;\"><h2>Something went wrong. Please call (801)404-0848 to speak with one of our representatives. We apologize for the inconvenience.</h2><a href=\"http://www.fordscleaning.com\">(Click here to continue)</a></div>");
                }
                Response.Flush();
                Response.Close();
            }
        }
        else
        {
            Session["CaptchaImageText"] = CaptchaImage.GenerateRandomCode(random);
            CustomValidator3.IsValid = false;
        }
    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (args.Value.ToString() == "Not Selected")
            args.IsValid = false;
        else
            args.IsValid = true;
    }
    protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (args.Value.ToString() == "Not Selected")
            args.IsValid = false;
        else
            args.IsValid = true;
    }
}
