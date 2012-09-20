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

public partial class fordscleaning_Service : System.Web.UI.Page
{
    static string sSERVICES = "~/DataFiles/Services.dat";
    ArrayList alServices;

    protected void Page_Load(object sender, EventArgs e)
    {
        string sSID = Request.QueryString["sid"];
        alServices = new ArrayList();

        StreamReader sr = new StreamReader(MapPath(sSERVICES));
        while (!sr.EndOfStream)
        {
            alServices.Add(sr.ReadLine());
        }
        sr.Close();

        int iIndex = 0;

        foreach (string s in alServices)
        {
            if (s == sSID)
            {
                break;
            }
            iIndex++;
        }

        string sTitle = alServices[iIndex+1].ToString();
        string sBody = alServices[iIndex+3].ToString();
        string sImage = alServices[iIndex+2].ToString();

        this.Title = sTitle;
        ServiceTitle.InnerHtml = sTitle;
        ServiceBody.InnerHtml = "<img style=\"float:right; margin-left:10px; margin-bottom:5px; width:300px;\" src=\"http://www.fordscleaning.com/images/ServiceImages/" + sImage + "\" />";
        ServiceBody.InnerHtml += "&nbsp &nbsp &nbsp " + sBody;
    }
}
