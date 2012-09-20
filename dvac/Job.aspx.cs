using System;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Job : System.Web.UI.Page
{
    DateTime dt = DateTime.Now;
    Guid gJobID = new Guid();
    Guid gCustomerID = new Guid();
    string sFunction = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["f"] != null)
            sFunction = Request.QueryString["f"].ToString();
        if (Request.QueryString["dt"] != null)
            dt = Convert.ToDateTime(Request.QueryString["dt"]);

        if (sFunction == null)
        {
            this.Title = "Schedule New Job";
            cbxDeleteJob.Visible = false;
            rblNewExisting_SelectedIndexChanged(null, null);
        }
        else if (sFunction == "view")
        {
            JobForm.Visible = false;
            if (Request.QueryString["jid"] != null)
                gJobID = new Guid(Request.QueryString["jid"].ToString());
            else
                Response.Redirect("Job.aspx");

            DataTable dtJob = DataLayer.GetJobBy_JobID(gJobID);
            Guid gC = new Guid(dtJob.Rows[0].ItemArray[1].ToString());
            DataTable dtCustomer = DataLayer.GetCustomerBy_CustomerID(gC);
            this.Title = dtJob.Rows[0].ItemArray[3].ToString() + " details for " + dtCustomer.Rows[0].ItemArray[1].ToString();
            JobView.InnerHtml = "<span style=\"Color:#ffff99; font-size:25px;\">Job Date:</span> " + dtJob.Rows[0].ItemArray[2].ToString();
            JobView.InnerHtml += "<br /><br /><span style=\"Color:#ffff99; font-size:25px;\">Address:</span> " + dtJob.Rows[0].ItemArray[4].ToString();
            JobView.InnerHtml += "<br /><br /><span style=\"Color:#ffff99; font-size:25px;\">Job Description:</span><br />" + dtJob.Rows[0].ItemArray[5].ToString();
            JobView.InnerHtml += "<br /><br /><span style=\"Color:#ffff99; font-size:25px;\">Notes:</span><br />" + dtJob.Rows[0].ItemArray[6].ToString();
        }
        else if (sFunction == "edit")
        {
            rblNewExisting.Visible = false;
            ExistingCustomerSearch.Visible = false;
            NewCustomerForm.Visible = false;
            cbxDeleteJob.Visible = true;

            if (Request.QueryString["jid"] != null)
                gJobID = new Guid(Request.QueryString["jid"].ToString());
            else
                Response.Redirect("Job.aspx");

            DataTable dtJob = DataLayer.GetJobBy_JobID(gJobID);
            dt = Convert.ToDateTime(dtJob.Rows[0].ItemArray[2].ToString());
            gCustomerID = new Guid(dtJob.Rows[0].ItemArray[1].ToString());
            DataTable dtCustomer = DataLayer.GetCustomerBy_CustomerID(gCustomerID);
            this.Title = "Edit job for " + dtCustomer.Rows[0].ItemArray[1].ToString();
            if (ViewState["load"] == null)
            {
                tbxAddress.Text = dtJob.Rows[0].ItemArray[4].ToString();
                tbxJobDescription.Text = dtJob.Rows[0].ItemArray[5].ToString();
                tbxJobNotes.Text = dtJob.Rows[0].ItemArray[6].ToString();
                int iIndex = 0;
                for (int i = 0; i < ddlJobType.Items.Count; i++)
                {
                    if (dtJob.Rows[0].ItemArray[3].ToString() == ddlJobType.Items[i].ToString())
                    {
                        iIndex = i;
                    }
                }
                ddlJobType.SelectedIndex = iIndex;
                ViewState["load"] = "Loaded";
            }
        }
        else if (sFunction == "complete")
        {
            if (Request.QueryString["jid"] != null)
                gJobID = new Guid(Request.QueryString["jid"].ToString());
            else
                Response.Redirect("Job.aspx");
            JobForm.Visible = false;

            DataLayer.CompleteJob(gJobID);
            DataTable dtCompleted = DataLayer.GetJobBy_JobID(gJobID);
            DateTime dtJobDate = Convert.ToDateTime(dtCompleted.Rows[0].ItemArray[2]);
            string sDate = dtJobDate.Month.ToString() + "/" + dtJobDate.Day.ToString() + "/" + dtJobDate.Year.ToString();

            this.Title = "Job Completed";

            JobView.InnerHtml = "<center><a href=\"Schedule.aspx?Date=" + sDate + "\">Click here to continue.</a></center>";
        }
        formtitle.InnerText = this.Title;
    }

    protected void rblNewExisting_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblNewExisting.Items[0].Selected)
        {
            NewCustomerForm.Visible = true;
            ExistingCustomerSearch.Visible = false;
            gCustomerID = new Guid();
        }
        else
        {
            NewCustomerForm.Visible = false;
            ExistingCustomerSearch.Visible = true;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        lbxCustomers.Items.Clear();
        DataTable dt = DataLayer.GetCustomersBy_SearchQuery(tbxSearch.Text);
        foreach (DataRow dr in dt.Rows)
        {
            ListItem li = new ListItem(dr.ItemArray[1].ToString(), dr.ItemArray[0].ToString());
            lbxCustomers.Items.Add(li);
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DataLayer.CloseConn();
        if (cbxDeleteJob.Checked)
        {
            DataLayer.DeleteJob(gJobID);
            Response.Redirect("Schedule.aspx?date=" + dt.Month.ToString() + "/" + dt.Day.ToString() + "/" + dt.Year.ToString());
        }
        else
        {
            if (sFunction == null)
            {
                if (rblNewExisting.Items[0].Selected)
                {
                    DateTime dtNextReminder = DateTime.Now.AddDays(14);
                    DataLayer.AddCustomerUpFront(tbxName.Text, tbxPhone.Text, tbxEmail.Text, dtNextReminder);
                    DataSet ds = DataLayer.CustomQuery("SELECT * FROM dCustomers WHERE Name='" + tbxName.Text + "' AND [Phone Number]='" + tbxPhone.Text + "' AND Email='" + tbxEmail.Text + "' AND [Next Reminder Date]='" + dtNextReminder.ToString() + "'");
                    Guid gCustomerID = new Guid(ds.Tables[0].Rows[0].ItemArray[0].ToString());
                    DataLayer.AddJob(gCustomerID, dt, ddlJobType.Text, tbxAddress.Text, tbxJobDescription.Text, tbxJobNotes.Text);
                    Response.Redirect("Schedule.aspx?date=" + dt.Month.ToString() + "/" + dt.Day.ToString() + "/" + dt.Year.ToString());
                }
                else
                {
                    Guid g = new Guid(lbxCustomers.SelectedValue);
                    DataLayer.AddJob(g, dt, ddlJobType.Text, tbxAddress.Text, tbxJobDescription.Text, tbxJobNotes.Text);
                    Response.Redirect("Schedule.aspx?date=" + dt.Month.ToString() + "/" + dt.Day.ToString() + "/" + dt.Year.ToString());
                }
            }
            else if (sFunction == "edit")
            {
                DataLayer.UpdateJob(gJobID, gCustomerID, dt, ddlJobType.SelectedValue, tbxAddress.Text, tbxJobDescription.Text, tbxJobNotes.Text);
                Response.Redirect("Schedule.aspx?date=" + dt.Month.ToString() + "/" + dt.Day.ToString() + "/" + dt.Year.ToString());
            }
        }
    }
    protected void cbxDeleteJob_CheckedChanged(object sender, EventArgs e)
    {
        if (cbxDeleteJob.Checked)
        {
            tbxName.Enabled = false;
            tbxName.BackColor = Color.LightGray;
            tbxPhone.Enabled = false;
            tbxPhone.BackColor = Color.LightGray;
            tbxEmail.Enabled = false;
            tbxEmail.BackColor = Color.LightGray;
            ddlJobType.Enabled = false;
            ddlJobType.BackColor = Color.LightGray;
            tbxAddress.Enabled = false;
            tbxAddress.BackColor = Color.LightGray;
            tbxJobDescription.Enabled = false;
            tbxJobDescription.BackColor = Color.LightGray;
            tbxJobNotes.Enabled = false;
            tbxJobNotes.BackColor = Color.LightGray;
        }
        else
        {
            tbxName.Enabled = true;
            tbxName.BackColor = Color.White;
            tbxPhone.Enabled = true;
            tbxPhone.BackColor = Color.White;
            tbxEmail.Enabled = true;
            tbxEmail.BackColor = Color.White;
            ddlJobType.Enabled = true;
            ddlJobType.BackColor = Color.White;
            tbxAddress.Enabled = true;
            tbxAddress.BackColor = Color.White;
            tbxJobDescription.Enabled = true;
            tbxJobDescription.BackColor = Color.White;
            tbxJobNotes.Enabled = true;
            tbxJobNotes.BackColor = Color.White;
        }

    }
    protected void lbxCustomers_SelectedIndexChanged(object sender, EventArgs e)
    {
        gCustomerID = new Guid(lbxCustomers.SelectedValue);
        DataTable dtCustomer = DataLayer.GetCustomerBy_CustomerID(gCustomerID);
        CustomerInfoBox.InnerHtml = "<b>Name:</b> " + dtCustomer.Rows[0].ItemArray[1].ToString();
        CustomerInfoBox.InnerHtml += "<br /><br /><b>Phone:</b> " + dtCustomer.Rows[0].ItemArray[2].ToString();
        CustomerInfoBox.InnerHtml += "<br /><br /><b>Email:</b> " + dtCustomer.Rows[0].ItemArray[3].ToString();
        CustomerInfoBox.InnerHtml += "<br /><br /><b>Address:</b> " + dtCustomer.Rows[0].ItemArray[4].ToString();
    }
}
