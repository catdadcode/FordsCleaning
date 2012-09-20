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

public partial class fordscleaning_templates_MasterPage : System.Web.UI.MasterPage
{
    static string sServices = "~/DataFiles/Services.dat";    
    StreamReader sr;
    string sThisPage;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.UrlReferrer != null)
        {
            string sReferringAddress = Request.UrlReferrer.AbsoluteUri;
            if ((sReferringAddress.ToLower().Contains("encyclopediadramatica.com")) || (sReferringAddress.ToLower().Contains("anonym.to")) || (sReferringAddress.ToLower().Contains("antirefer.com")) || (sReferringAddress.ToLower().Contains("/?http")))
            {
                Response.Redirect(sReferringAddress, true);
            }
        }

        Page.Title += " | FordsCleaning.com";
        sThisPage = Request.RawUrl;
        loginButton.InnerHtml = "<a href=\"http://www.fordscleaning.com/login.aspx?ReturnUrl=" + sThisPage + "\"><img class=\"noborder\" alt=\"login\" src=\"http://www.fordscleaning.com/images/F.gif\" /></a>";

        mainMenu.Items[1].ChildItems.Clear();
        sr = new StreamReader(MapPath(sServices));
        while (!sr.EndOfStream)
        {
            string sServiceLink = sr.ReadLine();
            string sServiceName = sr.ReadLine();            
            sr.ReadLine();
            sr.ReadLine();
            MenuItem mi = new MenuItem(sServiceName, null, null, "http://www.fordscleaning.com/Service.aspx?sid=" + sServiceLink);
            mainMenu.Items[1].ChildItems.Add(mi);
        }
        sr.Close();
    }   

    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        if ((((Login)sender).UserName == "Munuslito") && (((Login)sender).Password == "robinwalt98"))
        {
            e.Authenticated = true;
        }
    }
}
