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

public partial class fordscleaning_Default : System.Web.UI.Page
{
    static string sWelcomeFile = "~/DataFiles/HomePage.dat";
    static string sAdFile = "~/DataFiles/HomeAds.dat";
    ArrayList alAds;
    Button btnDel;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.ViewState["alAds"] == null)
        {
            StreamReader sr = new StreamReader(MapPath(sAdFile));
            alAds = new ArrayList();
            while (!sr.EndOfStream)
            {
                alAds.Add(sr.ReadLine());
                alAds.Add(sr.ReadLine());
            }
            sr.Close();
            this.ViewState["alAds"] = alAds;
        }
        else
        {
            alAds = (ArrayList)this.ViewState["alAds"];
        }

        for (int i = 0; i < alAds.Count; i += 2)
        {
            string sLink = alAds[i].ToString();
            string sImage = alAds[i + 1].ToString();
            LiteralControl lc = new LiteralControl("<div style=\"margin-bottom:10px;\"><a href=\"" + sLink + "\" >");
            AdSpace.Controls.Add(lc);
            lc = new LiteralControl("<img style=\"border-width: 0px; width:150px;\" src=\"http://www.fordscleaning.com/images/AdImages/" + sImage + "\" /></a>");
            AdSpace.Controls.Add(lc);
            if ((User.Identity.IsAuthenticated) && (User.Identity.Name == "Walt"))
            {
                btnDel = new Button();
                btnDel.Text = "X";
                btnDel.ID = sImage;
                btnDel.Click += new EventHandler(btnDel_Click);
                AdSpace.Controls.Add(btnDel);
            }
            lc = new LiteralControl("</div>");
            AdSpace.Controls.Add(lc);
        }

        DataTable dtBlog = DataLayer.GetLatestBlog();
        int iNumComments = DataLayer.GetCommentCountBy_blogID(Convert.ToInt32(dtBlog.Rows[0].ItemArray[0]));
        blogtitle.InnerHtml = "<a class=\"titlelink\" href=\"Blog.aspx?blog=" + dtBlog.Rows[0].ItemArray[0].ToString() + "\">" + dtBlog.Rows[0].ItemArray[1].ToString() + "</a>";
        blogdate.InnerHtml = Convert.ToDateTime(dtBlog.Rows[0].ItemArray[3]).ToString("D") + " | " + iNumComments.ToString() + " Comment(s)";
        blogcontent.InnerHtml = dtBlog.Rows[0].ItemArray[2].ToString() + "<br /><br /><a href=\"http://www.fordscleaning.com/Blog.aspx?blog=" + dtBlog.Rows[0].ItemArray[0].ToString() + "\">(Read More)</a>"; ;
    }

    void btnDel_Click(object sender, EventArgs e)
    {
        string sImage = ((Button)sender).ID;
        int iIndex = 0;
        for (int i = 0; i < alAds.Count; i++)
        {
            if (alAds[i].ToString() == sImage)
            {
                iIndex = i;
            }
        }
        alAds.RemoveAt(iIndex);
        alAds.RemoveAt(iIndex - 1);
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
