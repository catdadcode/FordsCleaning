using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;

public partial class AboutUs : System.Web.UI.Page
{
    static string sWelcomeFile = "~/DataFiles/HomePage.dat";

    protected void Page_Load(object sender, EventArgs e)
    {
        StreamReader sr = new StreamReader(MapPath(sWelcomeFile));
        string sMessage = sr.ReadLine();
        sr.Close();
        WelcomeMessage.InnerHtml = sMessage;
        
    }
}
