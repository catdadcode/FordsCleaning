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

public partial class fordscleaning_admin_EditWelcomeMessage : System.Web.UI.Page
{
    static string WELCOMEMESSAGE = "~/DataFiles/HomePage.dat";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            StreamReader sr = new StreamReader(MapPath(WELCOMEMESSAGE));
            rteBody.Text = sr.ReadLine().Replace("&lt;", "<").Replace("&gt;", ">").Replace("&amp;", "&");
            sr.Close();

            string[] sFiles = Directory.GetFiles(MapPath("~/images/contentimages/"));
            foreach (string s in sFiles)
            {
                string s2 = s.Remove(0, s.LastIndexOf('\\') + 1);
                ddlExistingImages.Items.Add(s2);
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        StreamWriter sw = new StreamWriter(MapPath(WELCOMEMESSAGE));
        sw.WriteLine(rteBody.Text.Replace("&lt;", "<").Replace("&gt;", ">").Replace("&amp;", "&"));
        sw.Close();
        Response.Redirect("http://www.fordscleaning.com", true);
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
