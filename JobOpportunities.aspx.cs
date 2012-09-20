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

public partial class fordscleaning_JobOpportunities : System.Web.UI.Page
{
    static string sJOBS = "~/DataFiles/Jobs.dat";

    protected void Page_Load(object sender, EventArgs e)
    {
        StreamReader sr = new StreamReader(MapPath(sJOBS));
        string sFloat = "floatLeft";        
        if (User.Identity.IsAuthenticated)
        {
            LiteralControl lcTemp = new LiteralControl("<br />");
            jobs.Controls.Add(lcTemp);
            Button btnAddJob = new Button();
            btnAddJob.PostBackUrl = "http://www.fordscleaning.com/admin/AddEditJobOpportunities.aspx";
            btnAddJob.UseSubmitBehavior = false;
            btnAddJob.CausesValidation = false;
            btnAddJob.Text = "Add New Job";
            btnAddJob.ID = "btnAddeNewJob";
            jobs.Controls.Add(btnAddJob);
        }
        LiteralControl lc = new LiteralControl("<br /><table width=\"100%\">");
        jobs.Controls.Add(lc);
        int iX = 0;
        while (!sr.EndOfStream)
        {
            string sJobAnchor = sr.ReadLine();
            string sJobName = sr.ReadLine();            
            string sJobImage = sr.ReadLine();
            string sJobSummary = sr.ReadLine();

            lc = new LiteralControl("<tr><td><div class=\"serviceTitle\"><table width=\"100%\"><tr><td><a name=\"" + sJobAnchor + "\">" + sJobName + "</a></td><td style=\"text-align:right;\">");
            jobs.Controls.Add(lc);
            Button btnApply = new Button();
            btnApply.PostBackUrl = "http://www.fordscleaning.com/Apply.aspx?JobName=" + sJobName;
            btnApply.Text = "Apply For This Job";
            btnApply.UseSubmitBehavior = false;
            btnApply.CausesValidation = false;
            btnApply.ID = "ApplyForJob";
            jobs.Controls.Add(btnApply);
            if (User.Identity.IsAuthenticated)
            {
                Button btnEdit = new Button();
                btnEdit.Text = "Edit This Job";
                btnEdit.UseSubmitBehavior = false;
                btnEdit.CausesValidation = false;
                btnEdit.ID = "Edit" + sJobAnchor;
                btnEdit.PostBackUrl = "http://www.fordscleaning.com/admin/AddEditJobOpportunities.aspx?Job=" + iX;
                jobs.Controls.Add(btnEdit);
            }
            lc = new LiteralControl("</td></tr></table></div>");
            jobs.Controls.Add(lc);
            if (sJobImage != "No Image.")
            {
                Image img = new Image();
                img.ImageUrl = "http://www.fordscleaning.com/MakeThumbnail.aspx?Image=JobImages/" + sJobImage + "&Size=250";
                img.CssClass = sFloat;
                jobs.Controls.Add(img);
            }
            lc = new LiteralControl("&nbsp &nbsp &nbsp " + sJobSummary + "</td></tr>");
            jobs.Controls.Add(lc);
            if (sFloat == "floatLeft")
                sFloat = "floatRight";
            else
                sFloat = "floatLeft";
            iX++;
        }
        if (iX == 0)
        {
            lc = new LiteralControl("<tr><td><div class=\"serviceTitle\"> No Jobs </td></tr>");
            jobs.Controls.Add(lc);
        }
        lc = new LiteralControl("</table>");
        jobs.Controls.Add(lc);
        sr.Close();
    }
}
