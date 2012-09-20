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
using System.IO;
using System.Web.Mail;

public partial class Blog : System.Web.UI.Page
{
    int iBlogID;
    Button btnDeleteComment;
    Random random = new Random();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            iBlogID = Convert.ToInt32(Request.QueryString["blog"]);
        }
        catch
        {
            Response.Write("<h2>NO BLOG FOUND</h2>");
            Response.Flush();
            Response.Close();
        }

        if (!IsPostBack)
        {
            Session["CaptchaImageText"] = CaptchaImage.GenerateRandomCode(random);
        }

        DataTable dtBlog = DataLayer.GetBlogsBy_blogID(iBlogID);

        if (dtBlog.Rows.Count == 0)
        {
            Response.Write("<h2>NO BLOG FOUND</h2>");
            Response.Flush();
            Response.Close();
        }
        else
        {
            if (Convert.ToBoolean(dtBlog.Rows[0].ItemArray[4]))
            {
                Response.Write("<h2>NO BLOG FOUND</h2>");
                Response.Flush();
                Response.Close();
            }
        }

        blogtitle.InnerHtml = dtBlog.Rows[0].ItemArray[1].ToString();
        Page.Title = dtBlog.Rows[0].ItemArray[1].ToString();
        blogdate.InnerHtml = dtBlog.Rows[0].ItemArray[3].ToString();
        blogcontent.InnerHtml = dtBlog.Rows[0].ItemArray[2].ToString().Replace("~","");

        int iNumComments = DataLayer.GetCommentCountBy_blogID(iBlogID);

        blogdate.InnerHtml += " &nbsp " + iNumComments.ToString() + " Comments";

        blogedit.Controls.Add(new LiteralControl("<script type=\"text/javascript\" src=\"http://w.sharethis.com/button/sharethis.js#tabs=web%2Cpost%2Cemail&amp;charset=utf-8&amp;style=default&amp;publisher=9704f30f-b172-4e8c-afed-b53e027d8e5b&amp;popup=false\"></script>"));
        if ((User.Identity.Name.ToUpper() == "WALT") && (User.Identity.IsAuthenticated))
        {
            Button btnEdit = new Button();
            btnEdit.ID = "btnEdit";
            btnEdit.Text = "Edit";
            btnEdit.PostBackUrl = "http://www.fordscleaning.com/admin/AddEditBlog.aspx?blog=" + iBlogID.ToString();
            blogedit.Controls.Add(btnEdit);
        }

        comments.InnerHtml = "";
        DataTable dtComments = DataLayer.GetCommentsBy_blogID(iBlogID);
        bool bColored = true;
        foreach (DataRow dr in dtComments.Rows)
        {
            if (!Convert.ToBoolean(dr.ItemArray[5]))
            {
                LiteralControl lc = new LiteralControl();
                if (bColored)
                {
                    lc.Text += "<div class=\"comment\" style=\"background-color:#ffffcc;\">";
                }
                else
                {
                    lc.Text += "<div class=\"comment\" style=\"background-color:#ffffff;\">";
                }
                bColored = !bColored;
                lc.Text += "<table width=\"100%\"><tr><td rowspan=\"2\" width=\"200px\" valign=\"top\" align=\"center\" style=\"color:#000000; border-right: solid 1px #880000; padding: 10px;\"><b>";
                if (dr.ItemArray[6].ToString() != "")
                {
                    lc.Text += "<a href=\"" + dr.ItemArray[6].ToString() + "\">" + dr.ItemArray[2].ToString() + "</a>";
                }
                else
                {
                    lc.Text += dr.ItemArray[2].ToString();
                }
                lc.Text += "</b></td><td style=\"padding:10px;\" valign=\"top\">" + dr.ItemArray[3].ToString() + "</td></tr><tr><td style=\"text-align:right; vertical-align:bottom; font-size: 15px;\">" + dr.ItemArray[4].ToString() + " &nbsp ";
                comments.Controls.Add(lc);
                if ((User.Identity.Name.ToUpper() == "WALT") && (User.Identity.IsAuthenticated))
                {
                    btnDeleteComment = new Button();
                    btnDeleteComment.Text = "Delete Comment";
                    btnDeleteComment.Click += new EventHandler(btnDeleteComment_Click);
                    btnDeleteComment.ID = dr.ItemArray[0].ToString();
                    comments.Controls.Add(btnDeleteComment);
                }
                lc = new LiteralControl("</td></tr></table></div>");
                comments.Controls.Add(lc);
            }
        }
    }

    protected void btnDeleteComment_Click(object sender, EventArgs e)
    {
        int iCommentID = Convert.ToInt32(((Button)sender).ID);

        DataLayer.DeleteComment(iCommentID);

        Response.Redirect("http://www.fordscleaning.com/Blog.aspx?blog=" + iBlogID);
    }

    protected void btnAddComment_Click(object sender, EventArgs e)
    {
        if (Session["CaptchaImageText"].ToString() == tbxCode.Text)
        {
            if (tbxAddComment.Text.Length > 0)
            {
                DataLayer.AddComment(iBlogID, tbxUsername.Text, tbxAddComment.Text.Replace("\r", "<br />").Replace("\n", ""), DateTime.Now, tbxWebsite.Text);

                DataTable dtBlog = DataLayer.GetBlogsBy_blogID(iBlogID);

                SmtpMail.SmtpServer = "relay-hosting.secureserver.net";
                MailMessage mm = new MailMessage();
                mm.BodyFormat = MailFormat.Html;
                mm.To = "Walt@FordsCleaning.com";
                mm.From = "NoReply@FordsCleaning.com";
                mm.Subject = "New Blog Comment";
                mm.Body = tbxUsername.Text + " posted a comment on your blog titled: " + dtBlog.Rows[0].ItemArray[1].ToString() + "<br />Here it is below:<br /><br />";
                mm.Body += tbxAddComment.Text.Replace("\r", "<br />").Replace("\n", "");
                try
                {
                    SmtpMail.Send(mm);
                }
                catch
                { }

                Response.Redirect("http://www.fordscleaning.com/Blog.aspx?blog=" + iBlogID.ToString());
            }
        }
        else
        {
            cvCode.IsValid = false;
            Session["CaptchaImageText"] = CaptchaImage.GenerateRandomCode(random);
        }
    }
}
