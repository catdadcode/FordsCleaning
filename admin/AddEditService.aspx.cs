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

public partial class fordscleaning_admin_AddEditService : System.Web.UI.Page
{
    static string sSERVICESFILE = "~/DataFiles/Services.dat";
    static string sIMAGEPATH = "~/Images/ServiceImages/";
    ArrayList alServices;
    int iService;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.ViewState["alServices"] == null)
        {
            alServices = new ArrayList();
            StreamReader sr = new StreamReader(MapPath(sSERVICESFILE));
            while (!sr.EndOfStream)
            {
                alServices.Add(sr.ReadLine());
            }
            sr.Close();            

            if (Request.QueryString["Service"] == null)
            {
                iService = (alServices.Count/4);                
                addOrEdit.InnerText = "Add New Service";
                alServices.Add(iService.ToString());
                alServices.Add("");
                alServices.Add("No Image.");
                alServices.Add("");                
            }
            else
            {
                cbxDeleteService.Visible = true;
                iService = Convert.ToInt32(Request.QueryString["Service"]);
                addOrEdit.InnerText = "Edit " + alServices[(iService * 4) + 1] + " Service";
                tbxName.Text = alServices[(iService * 4) + 1].ToString();
                string sImage = alServices[(iService * 4) + 2].ToString();
                if (sImage != "No Image.")
                {
                    ServiceImage.InnerHtml = "<br/><img src=\"http://www.fordscleaning.com/MakeThumbnail.aspx?Image=ServiceImages/" + sImage + "&Size=150\" />";
                    cbxDeleteImage.Visible = true;
                }
                tbxSummary.Text = alServices[(iService * 4) + 3].ToString().Replace("<br />","\r\n");
            }
            this.ViewState["alServices"] = alServices;
            this.ViewState["iService"] = iService;
        }
        else
        {
            alServices = (ArrayList)this.ViewState["alServices"];
            iService = Convert.ToInt32(this.ViewState["iService"]);
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
        if (!cbxDeleteService.Checked)
        {
            alServices[(iService * 4) + 1] = tbxName.Text;
            this.ViewState["alServices"] = alServices;
            if (!cbxDeleteImage.Checked)
            {
                if (fuImage.HasFile)
                {
                    alServices[(iService * 4) + 2] = iService.ToString() + fuImage.FileName.Remove(0, fuImage.FileName.Length - 4);
                    this.ViewState["alServices"] = alServices;
                    fuImage.SaveAs(MapPath(sIMAGEPATH + alServices[(iService * 4) + 2]));
                }
            }
            else
            {
                alServices[(iService * 4) + 2] = "No Image.";
                this.ViewState["alServices"] = alServices;
            }
            string sSummary = tbxSummary.Text.Replace("\r", "<br />").Replace("\n", "");            
            alServices[(iService * 4) + 3] = sSummary;
            this.ViewState["alServices"] = alServices;
        }
        else
        {
            for (int iCount = 3; iCount >= 0; iCount--)
            {
                alServices.RemoveAt((iService * 4) + iCount);
            }
            this.ViewState["alServices"] = alServices;
        }

        //Write to file.
        StreamWriter sw = new StreamWriter(MapPath(sSERVICESFILE));
        foreach (string s in alServices)
        {
            sw.WriteLine(s);
        }
        sw.Close();
        Response.Redirect("http://www.fordscleaning.com/OurServices.aspx");
    }

    protected void cbxDeleteService_CheckedChanged(object sender, EventArgs e)
    {
        if (cbxDeleteService.Checked)
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
