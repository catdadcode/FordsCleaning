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

public partial class fordscleaning_Promo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string sPromoFile = Request.QueryString["pid"].ToString();

        StreamReader sr = new StreamReader(MapPath("~/DataFiles/Promotions/" + sPromoFile + ".dat"));
        string sTitle = sr.ReadLine();
        string sBody = sr.ReadToEnd();
        sr.Close();

        promotitle.InnerHtml = sTitle;
        if ((User.Identity.IsAuthenticated) && (User.Identity.Name.ToUpper() == "WALT"))
        {
            LiteralControl lcon = new LiteralControl("<center>");
            promobody.Controls.Add(lcon);
            Button btnEdit = new Button();
            btnEdit.Text = "Edit Promo";
            btnEdit.PostBackUrl = "http://www.fordscleaning.com/admin/AddEditPromotion.aspx?pid=" + sPromoFile;
            promobody.Controls.Add(btnEdit);
            lcon = new LiteralControl("</center><div style=\"color:red;text-align:center;\"><span style=\"font-size:14px;\">If you just created this promotion then be sure to copy the red URL below so you can use it elsewhere.</span><br /><br />http://www.fordscleaning.com/Promo.aspx?pid=" + sPromoFile + "</div>");
            promobody.Controls.Add(lcon);
        }
        LiteralControl lc = new LiteralControl("<br />" + sBody);
        promobody.Controls.Add(lc);
    }
}
