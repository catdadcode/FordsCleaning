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

public partial class fordscleaning_test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        StreamReader sr = new StreamReader(MapPath("~/fordscleaning/DataFiles/WelcomeMessage.dat"));
        sr.ReadLine();
        string sImage = sr.ReadLine();
        string sChangeDate = sr.ReadLine();
        sr.Close();
        main.InnerHtml += "Server Time: <font color=#ff0000>" + DateTime.Now.ToString() + "</font>";
        main.InnerHtml += "<br /><br />Change Picture Time: <font color=#ff0000>" + sChangeDate + "</font>";
        main.InnerHtml += "<br /><br />Current Picture: <font color=#ff0000>" + sImage + "</font>";
        main.InnerHtml += "<br /><br />Your IP Address: <font color=#ff0000>" + Request.UserHostAddress.ToString() + "</font>";
        if (Request.UrlReferrer != null)
        {
            main.InnerHtml += "<br /><br />You came here from:<br /><font color=#ff0000><a href=\"" + Request.UrlReferrer.ToString() + "\">" + Request.UrlReferrer.ToString() + "</a></font>";
        }        
    }
}
