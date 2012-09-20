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

public partial class fordscleaning_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        if ((((Login)sender).UserName.ToLower() == "walt") && (((Login)sender).Password == "robinwalt98"))
        {
            e.Authenticated = true;
        }
        else if ((((Login)sender).UserName.ToLower() == "chevex") && (((Login)sender).Password == "Ch3vyF0rd!"))
        {
            e.Authenticated = true;
        }
    }
}
