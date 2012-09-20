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
using System.Drawing;

public partial class fordscleaning_admin_AddEditPromotion : System.Web.UI.Page
{
    string sPID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["pid"] != null)
        {
            cbxDelete.Visible = true;
            tbxName.Visible = false;
            pn.Visible = false;
            if (!this.IsPostBack)
            {
                sPID = Request.QueryString["pid"].ToString();
                this.ViewState["pid"] = sPID;
                StreamReader sr = new StreamReader(MapPath("~/DataFiles/Promotions/" + sPID + ".dat"));
                tbxTitle.Text = sr.ReadLine();
                rteBody.Text = sr.ReadToEnd().Replace("&lt;", "<").Replace("&gt;", ">").Replace("&amp;", "&");
                sr.Close();

                string[] sFiles = Directory.GetFiles(MapPath("~/images/contentimages/"));
                foreach (string s in sFiles)
                {
                    string s2 = s.Remove(0, s.LastIndexOf('\\') + 1);
                    ddlExistingImages.Items.Add(s2);
                }
            }
            else
            {
                sPID = this.ViewState["pid"].ToString();
            }
        }
        else
        {
            tbxName.Visible = true;
            pn.Visible = true;
            cbxDelete.Visible = false;
            string[] sFiles = Directory.GetFiles(MapPath("~/images/contentimages/"));
            foreach (string s in sFiles)
            {
                string s2 = s.Remove(0, s.LastIndexOf('\\') + 1);
                ddlExistingImages.Items.Add(s2);
            }
        }
    }

    protected void cbxDelete_CheckedChanged(object sender, EventArgs e)
    {
        if (cbxDelete.Checked)
        {
            tbxTitle.Enabled = false;
            tbxTitle.BackColor = Color.LightGray;
            rteBody.Enabled = false;
        }
        else
        {
            tbxTitle.Enabled = true;
            tbxTitle.BackColor = Color.White;
            rteBody.Enabled = true;
        }
            
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (sPID != null)
        {
            if (cbxDelete.Checked)
            {
                File.Delete(MapPath("~/DataFiles/Promotions/" + sPID + ".dat"));
                Response.Write("<h2 align=\"center\">Promotion deleted.</h2><center><a href=\"http://www.fordscleaning.com\">(Click here to continue)</a></center>");
                Response.End();
            }
            else
            {
                StreamWriter sw = new StreamWriter(MapPath("~/DataFiles/Promotions/" + sPID + ".dat"));
                sw.WriteLine(tbxTitle.Text);
                sw.WriteLine(rteBody.Text.Replace("&lt;", "<").Replace("&gt;", ">").Replace("&amp;", "&"));
                sw.Close();
                Response.Redirect("http://www.fordscleaning.com/Promo.aspx?pid=" + sPID);
            }
        }
        else
        {
            
            StreamWriter sw = new StreamWriter(MapPath("~/DataFiles/Promotions/" + tbxName.Text + ".dat"));
            sw.WriteLine(tbxTitle.Text);
            sw.WriteLine(rteBody.Text.Replace("&lt;", "<").Replace("&gt;", ">").Replace("&amp;", "&"));
            sw.Close();
            Response.Redirect("http://www.fordscleaning.com/Promo.aspx?pid=" + tbxName.Text);
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
