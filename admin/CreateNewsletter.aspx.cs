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
using System.IO;

public partial class admin_CreateNewsletter : System.Web.UI.Page
{
    DataTable dtSubscribers;

    protected void Page_Load(object sender, EventArgs e)
    {
        dtSubscribers = DataLayer.RetrieveNewsletterList();
        Subscribers.InnerHtml = "<b>" + dtSubscribers.Rows.Count.ToString() + " total subscriber(s)</b><br /><br />";

        if (!this.IsPostBack)
        {
            lbxSubscribers.Items.Clear();
            foreach (DataRow drSubscriber in dtSubscribers.Rows)
            {
                lbxSubscribers.Items.Add(drSubscriber.ItemArray[0].ToString());
            }
            
            string[] sFiles = Directory.GetFiles(MapPath("~/images/contentimages"));
            foreach (string s in sFiles)
            {
                string s2 = s.Remove(0, s.LastIndexOf('\\') + 1);
                ddlExistingImages.Items.Add(s2);
            }
        }

        if (dtSubscribers.Rows.Count == 0)
        {
            btnSendNewsletter.Enabled = false;
            rteBody.Enabled = false;
            tbxSubject.Enabled = false;
        }
    }
    protected void btnSendNewsletter_Click(object sender, EventArgs e)
    {
        SmtpMail.SmtpServer = "relay-hosting.secureserver.net";

        MailMessage mm;
        ArrayList alFailed = new ArrayList();
        foreach (DataRow dr in dtSubscribers.Rows)
        {
            mm = new MailMessage();
            mm.BodyFormat = MailFormat.Html;
            mm.To = dr.ItemArray[0].ToString();
            mm.From = "Newsletter@Fordscleaning.com";
            mm.Subject = tbxSubject.Text;
            mm.Body = "<center><img alt=\"Ford's Cleaning & Maintenance\" src=\"http://www.fordscleaning.com/images/FordsLogo.gif\" /></center><br /><br />";
            mm.Body += rteBody.Text.Replace("&lt;", "<").Replace("&gt;", ">").Replace("&amp;", "&") + "<br /><br /><br />";
            mm.Body += "<div style=\"font-size:15px;\"><a href=\"http://www.fordscleaning.com/Newsletter.aspx?remove=" + dr.ItemArray[0].ToString() + "\">Click here to unsubscribe.</a></div>";
            try
            {
                SmtpMail.Send(mm);
            }
            catch
            {
                alFailed.Add(dr.ItemArray[0].ToString());
            }
        }
        Response.Write("<h2>Finished sending newsletter.</h2>");
        if (alFailed.Count == 0)
        {
            Response.Write("Every email was sent successfully!");
        }
        else if (alFailed.Count == lbxSubscribers.Items.Count)
        {
            Response.Write("Every email failed. Please contact your administrator.");
        }
        else
        {
            Response.Write("Some of the emails failed when sending. Here is a list:<br /><ul>");
            foreach (string s in alFailed)
            {
                Response.Write("<li>" + s + "</li>");
            }
            Response.Write("</ul>");
        }
        Response.Write("<br /><br /><a href=\"http://www.fordscleaning.com\">(Click here to continue.)</a>");
        Response.Flush();
        Response.Close();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int[] iIndices = lbxSubscribers.GetSelectedIndices();

        for (int iCount = 0; iCount < iIndices.Length; iCount++)
        {
            string sDeleteEmail = lbxSubscribers.Items[iIndices[iCount]].ToString();
            DataLayer.RemoveNewsletterEmail(lbxSubscribers.Items[iIndices[iCount]].ToString());
        }

        Response.Write("<h2 style=\"text-align:center;color:990000;\">Selected emails have been removed.</h2><center><a href=\"CreateNewsletter.aspx\">(Click here to continue)</a></center>");
        Response.Flush();
        Response.Close();
    }
    protected void btnAddUsers_Click(object sender, EventArgs e)
    {

    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        fuContentImage.SaveAs(MapPath("~/images/contentimages/" + fuContentImage.FileName));
        ddlExistingImages.Items.Add(fuContentImage.FileName);
        rteBody.Text += "<img src=\"http://www.fordscleaning.com/MakeThumbnail.aspx?size=575&image=contentimages/" + fuContentImage.FileName + "\" />";
    }

    protected void btnAddImage_Click(object sender, EventArgs e)
    {
        if (ddlExistingImages.SelectedValue != "Not Selected")
        {
            rteBody.Text += "<img src=\"http://www.fordscleaning.com/MakeThumbnail.aspx?size=575&image=contentimages/" + ddlExistingImages.SelectedValue + "\" />";
        }
    }
}
