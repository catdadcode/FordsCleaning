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

public partial class fordscleaning_admin_NewAd : System.Web.UI.Page
{
    ArrayList alAds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            alAds = new ArrayList();
            StreamReader sr = new StreamReader(MapPath("~/DataFiles/HomeAds.dat"));
            while (!sr.EndOfStream)
            {
                alAds.Add(sr.ReadLine());
            }
            sr.Close();
            if (alAds.Count == 20)
            {
                Response.Write("<h2 align=\"center\">You already have three ads. Delete one on the home page before you can create another.</h2><center><a href=\"http://www.fordscleaning.com\">(Click here to continue)</a></center>");
                Response.End();
            }
            this.ViewState["alAds"] = alAds;
        }
        else
        {
            alAds = (ArrayList)this.ViewState["alAds"];
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        alAds.Add(tbxURL.Text);
        fuAdImage.SaveAs(MapPath("~/images/AdImages/" + fuAdImage.FileName));
        alAds.Add(fuAdImage.FileName);
        this.ViewState["alAds"] = alAds;
        StreamWriter sw = new StreamWriter(MapPath("~/DataFiles/HomeAds.dat"));
        foreach (string s in alAds)
        {
            sw.WriteLine(s);
        }
        sw.Close();
        Response.Redirect("http://www.fordscleaning.com");
    }
}
