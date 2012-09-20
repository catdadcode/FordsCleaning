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
using System.Net;

public partial class admin_AddEditBlog : System.Web.UI.Page
{
    int iBlogID;
    DateTime dtDate;
    bool bNew = true;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            string[] sFiles = Directory.GetFiles(MapPath("~/images/contentimages/"));
            foreach (string s in sFiles)
            {
                string s2 = s.Remove(0, s.LastIndexOf('\\') + 1);
                ddlExistingImages.Items.Add(s2);
            }
        }

        if (Request.QueryString["blog"] != null)
        {
            bNew = false;
            if (this.ViewState["iBlogID"] == null)
            {
                iBlogID = Convert.ToInt32(Request.QueryString["blog"]);
                DataTable dtBlog = DataLayer.GetBlogsBy_blogID(iBlogID);
                tbxTitle.Text = dtBlog.Rows[0].ItemArray[1].ToString();
                dtDate = Convert.ToDateTime(dtBlog.Rows[0].ItemArray[3]);
                rteBody.Text = dtBlog.Rows[0].ItemArray[2].ToString();

                this.ViewState["iBlogID"] = iBlogID;
            }
            else
            {
                iBlogID = Convert.ToInt32(this.ViewState["iBlogID"]);
            }
        }
        else
        {
            bNew = true;
            cbxDelete.Visible = false;
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (!cbxDelete.Checked)
        {
            if (bNew)
            {
                dtDate = DateTime.Now;
                int iBlogNum = DataLayer.GetBlogCountDeleted();
                DataLayer.AddBlog(tbxTitle.Text, rteBody.Text.Replace("&lt;", "<").Replace("&gt;", ">").Replace("&amp;", "&"), dtDate);

                try
                {
                    Yedda.Twitter t = new Yedda.Twitter();
                    WebRequest wrGETURL;
                    wrGETURL = WebRequest.Create("http://tinyurl.com/api-create.php?url=http://www.fordscleaning.com/Blog.aspx?blog=" + iBlogNum.ToString());
                    Stream objStream;
                    objStream = wrGETURL.GetResponse().GetResponseStream();
                    StreamReader objReader = new StreamReader(objStream);
                    string sURL = objReader.ReadToEnd();

                    t.Update("WALTatRNX", "robinwalt98", "New Blog Post: " + tbxTitle.Text + " " + sURL, Yedda.Twitter.OutputFormatType.XML);
                }
                catch
                {

                }
                Response.Redirect("http://www.fordscleaning.com/Blog.aspx?blog=" + Convert.ToString(DataLayer.GetBlogCountDeleted() - 1));
            }
            else
            {
                DataLayer.UpdateBlog(iBlogID, tbxTitle.Text, rteBody.Text.Replace("&lt;", "<").Replace("&gt;", ">").Replace("&amp;", "&"));
                Response.Redirect("http://www.fordscleaning.com/Blog.aspx?blog=" + iBlogID.ToString());
            }
        }
        else
        {
            DataLayer.DeleteBlog(iBlogID);
            Response.Redirect("http://www.fordscleaning.com/FordsBlog.aspx");
        }


    }
    protected void cbxDelete_CheckedChanged(object sender, EventArgs e)
    {
        if (cbxDelete.Checked)
        {
            tbxTitle.Enabled = false;
            rteBody.Enabled = false;
            tbxTitle.BackColor = System.Drawing.Color.Gray;
        }
        else
        {
            tbxTitle.Enabled = true;
            rteBody.Enabled = true;
            tbxTitle.BackColor = System.Drawing.Color.Black;
        }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        fuContentImage.SaveAs(MapPath("~/images/contentimages/" + fuContentImage.FileName));
        ddlExistingImages.Items.Add(fuContentImage.FileName);
        rteBody.Text += "<img src=\"http://www.fordscleaning.com/MakeThumbnail.aspx?size=815&image=contentimages/" + fuContentImage.FileName + "\" />";
    }

    protected void btnAddImage_Click(object sender, EventArgs e)
    {
        if (ddlExistingImages.SelectedValue != "Not Selected")
        {
            rteBody.Text += "<img src=\"http://www.fordscleaning.com/MakeThumbnail.aspx?size=815&image=contentimages/" + ddlExistingImages.SelectedValue + "\" />";
        }
    }
}
