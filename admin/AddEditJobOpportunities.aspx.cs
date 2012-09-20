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

public partial class fordscleaning_admin_AddEditJobOpportunities : System.Web.UI.Page
{
    static string sJOBSFILE = "~/DataFiles/Jobs.dat";
    static string sIMAGEPATH = "~/Images/JobImages/";
    ArrayList alJobs;
    int iJob;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.ViewState["alJobs"] == null)
        {
            alJobs = new ArrayList();
            StreamReader sr = new StreamReader(MapPath(sJOBSFILE));
            while (!sr.EndOfStream)
            {
                alJobs.Add(sr.ReadLine());
            }
            sr.Close();            

            if (Request.QueryString["Job"] == null)
            {
                iJob = (alJobs.Count/4);                
                addOrEdit.InnerText = "Add New Job";
                alJobs.Add(iJob.ToString());
                alJobs.Add("");
                alJobs.Add("No Image.");
                alJobs.Add("");
            }
            else
            {
                cbxDeleteJob.Visible = true;
                iJob = Convert.ToInt32(Request.QueryString["Job"]);
                addOrEdit.InnerText = "Edit " + alJobs[(iJob * 4) + 1] + " Job";
                tbxName.Text = alJobs[(iJob * 4) + 1].ToString();
                string sImage = alJobs[(iJob * 4) + 2].ToString();
                if (sImage != "No Image.")
                {
                    JobImage.InnerHtml = "<br/><img src=\"http://www.fordscleaning.com/MakeThumbnail.aspx?Image=JobImages/" + sImage + "&Size=150\" />";
                    cbxDeleteImage.Visible = true;
                }
                tbxSummary.Text = alJobs[(iJob * 4) + 3].ToString().Replace("<br />","\r\n");
            }
            this.ViewState["alJobs"] = alJobs;
            this.ViewState["iJob"] = iJob;
        }
        else
        {
            alJobs = (ArrayList)this.ViewState["alJobs"];
            iJob = Convert.ToInt32(this.ViewState["iJob"]);
        }
    }

    protected void cbxDeleteImage_CheckedChanged(object sender, EventArgs e)
    {
        if (cbxDeleteImage.Checked)
        {
            fuImage.Enabled = false;
        }
        else
        {
            fuImage.Enabled = true;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //Decide what to write.
        if (!cbxDeleteJob.Checked)
        {
            alJobs[(iJob * 4) + 1] = tbxName.Text;
            this.ViewState["alJobs"] = alJobs;
            if (!cbxDeleteImage.Checked)
            {
                if (fuImage.HasFile)
                {
                    alJobs[(iJob * 4) + 2] = iJob.ToString() + fuImage.FileName.Remove(0, fuImage.FileName.Length - 4);
                    this.ViewState["alJobs"] = alJobs;
                    fuImage.SaveAs(MapPath(sIMAGEPATH + alJobs[(iJob * 4) + 2]));
                }
            }
            else
            {
                alJobs[(iJob * 4) + 2] = "No Image.";
                this.ViewState["alJobs"] = alJobs;
            }
            string sSummary = tbxSummary.Text.Replace("\r", "<br />").Replace("\n", "");            
            alJobs[(iJob * 4) + 3] = sSummary;
            this.ViewState["alJobs"] = alJobs;
        }
        else
        {
            for (int iCount = 3; iCount >= 0; iCount--)
            {
                alJobs.RemoveAt((iJob * 4) + iCount);
            }
            this.ViewState["alJobs"] = alJobs;
        }

        //Write to file.
        StreamWriter sw = new StreamWriter(MapPath(sJOBSFILE));
        foreach (string s in alJobs)
        {
            sw.WriteLine(s);
        }
        sw.Close();
        Response.Redirect("http://www.fordscleaning.com/JobOpportunities.aspx");
    }

    protected void cbxDeleteJob_CheckedChanged(object sender, EventArgs e)
    {
        if (cbxDeleteJob.Checked)
        {
            tbxName.Enabled = false;
            fuImage.Enabled = false;
            cbxDeleteImage.Enabled = false;
            tbxSummary.Enabled = false;
        }
        else
        {
            tbxName.Enabled = true;
            fuImage.Enabled = true;
            cbxDeleteImage.Enabled = true;
            tbxSummary.Enabled = true;
        }
    }
}
