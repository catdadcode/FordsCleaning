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

public partial class fordscleaning_OurServices : System.Web.UI.Page
{
    static string sSERVICES = "~/DataFiles/Services.dat";

    protected void Page_Load(object sender, EventArgs e)
    {
        StreamReader sr = new StreamReader(MapPath(sSERVICES));
        string sFloat = "floatLeft";
        if (User.Identity.IsAuthenticated)
        {
            LiteralControl lcTemp = new LiteralControl("<br />");
            services.Controls.Add(lcTemp);
            Button btnAddService = new Button();
            btnAddService.PostBackUrl = "http://www.fordscleaning.com/admin/AddEditService.aspx";
            btnAddService.UseSubmitBehavior = false;
            btnAddService.CausesValidation = false;
            btnAddService.Text = "Add New Service";
            btnAddService.ID = "btnAddeNewService";
            services.Controls.Add(btnAddService);
        }
        LiteralControl lc = new LiteralControl("<br /><table width=\"100%\">");
        services.Controls.Add(lc);
        int iX = 0;
        while (!sr.EndOfStream)
        {
            string sServiceAnchor = sr.ReadLine();
            string sServiceName = sr.ReadLine();            
            string sServiceImage = sr.ReadLine();
            string sServiceSummary = sr.ReadLine();

            lc = new LiteralControl("<tr><td><div class=\"serviceTitle\"><table width=\"100%\"><tr><td><a style=\"color:#ffffff;\" href=\"http://www.fordscleaning.com/Service.aspx?sid=" + sServiceAnchor + "\" name=\"" + sServiceAnchor + "\">" + sServiceName + "</a></td><td style=\"text-align:right;\">");
            services.Controls.Add(lc);
            if (User.Identity.IsAuthenticated)
            {
                Button btnEdit = new Button();
                btnEdit.Text = "Edit";
                btnEdit.UseSubmitBehavior = false;
                btnEdit.CausesValidation = false;
                btnEdit.ID = "Edit" + sServiceAnchor;
                btnEdit.PostBackUrl = "http://www.fordscleaning.com/admin/AddEditService.aspx?Service=" + iX;
                services.Controls.Add(btnEdit);
            }
            lc = new LiteralControl("</td></tr></table></div>");
            services.Controls.Add(lc);
            if (sServiceImage != "No Image.")
            {
                Image img = new Image();
                img.ImageUrl = "http://www.fordscleaning.com/MakeThumbnail.aspx?Image=ServiceImages/" + sServiceImage + "&Size=250";
                img.CssClass = sFloat;
                services.Controls.Add(img);
            }
            lc = new LiteralControl("&nbsp &nbsp &nbsp " + sServiceSummary + "</td></tr>");
            services.Controls.Add(lc);
            if (sFloat == "floatLeft")
                sFloat = "floatRight";
            else
                sFloat = "floatLeft";
            iX++;
        }
        lc = new LiteralControl("</table>");
        services.Controls.Add(lc);
        sr.Close();
    }
}
