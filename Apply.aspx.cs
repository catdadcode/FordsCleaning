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
using System.Web.Mail;
using System.Security.Cryptography;

public partial class fordscleaning_Apply : System.Web.UI.Page
{
    string sTxtVerify;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["JobName"] == null)
        {
            Response.Redirect("http://www.fordscleaning.com/");
        }

        tbxPositionDesired.Text = Request.QueryString["JobName"];
        if (this.ViewState["sTxtVerify"] == null)
        {
            sTxtVerify = getRandomAlphaNumeric();
            this.ViewState["sTxtVerify"] = sTxtVerify;
        }
        else
        {
            sTxtVerify = (string)this.ViewState["sTxtVerify"];
        }
        imgVerify.BorderColor = System.Drawing.Color.Black;
        imgVerify.BorderWidth = 3;
        imgVerify.BorderStyle = BorderStyle.Solid;
        imgVerify.ImageUrl = "GenerateVerificationImage.aspx?txt=" + sTxtVerify;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        requiredagree.InnerHtml = "";
        requiredAuthentication.InnerHtml = "";
        if ((cbxIAgree.Checked)&&(tbxVerify.Text == sTxtVerify))
        {
            SmtpMail.SmtpServer = "relay-hosting.secureserver.net";

            MailMessage mm = new MailMessage();
            mm.To = "walt@fordscleaning.com; alex@fordscleaning.com";
            mm.From = "Applicant@fordscleaning.com";
            mm.BodyFormat = MailFormat.Html;
            mm.Subject = "New Job Application";
            mm.Body = "<h2>Ford's Cleaning Job Application</h2><br />";
            mm.Body += "Name: " + tbxName.Text + "<br />";
            mm.Body += "SSN: " + tbxSocialSecurity.Text + "<br /><br />";

            mm.Body += "<b><u>Present Address</u></b><br />";
            mm.Body += "Street: " + tbxPresentStreet.Text + "<br />";
            mm.Body += "City: " + tbxPresentCity.Text + "<br />";
            mm.Body += "State: " + ddlPresentState.Text + "<br />";
            mm.Body += "Zip: " + tbxPresentZip.Text + "<br /><br />";

            mm.Body += "<b><u>Permanent Address</u></b><br />";
            mm.Body += "Street: " + tbxPermanentStreet.Text + "<br />";
            mm.Body += "City: " + tbxPermanentCity.Text + "<br />";
            mm.Body += "State: " + ddlPermanentState.Text + "<br />";
            mm.Body += "Zip: " + tbxPermanentZip.Text + "<br /><br />";

            mm.Body += "Phone #: " + tbxPhoneNumber.Text + "<br /><br />";

            mm.Body += "Referred By: " + tbxReferredBy.Text + "<br />";
            mm.Body += "Position Desired: " + tbxPositionDesired.Text + "<br />";
            mm.Body += "Start Date: " + tbxDateCanStart.Text + "<br />";
            mm.Body += "Desired Wage: " + tbxDesiredWage.Text + "<br />";
            if (rbtnCurrentlyEmployed.Checked)
            {
                mm.Body += "Currently Employed: Yes<br />";
            }
            else
            {
                mm.Body += "Currently Employed: No<br />";
            }
            if (rbtnCurrentEmployerYes.Checked)
            {
                mm.Body += "If yes, Can we contact your current employer? Yes<br />";
            }
            else
            {
                mm.Body += "If yes, Can we contact your current employer? No<br />";
            }
            if (rbtnAppliedBefore.Checked)
            {
                mm.Body += "Applied to Ford's before? Yes<br /><br />";
            }
            else
            {
                mm.Body += "Applied to Ford's before? No<br /><br />";
            }

            mm.Body += "<b><u>Former Employer #1</u></b><br />";
            mm.Body += "Date Job Began: " + tbxDateJobBegan1.Text + "<br />";
            mm.Body += "Date Job Ended: " + tbxDateJobEnded1.Text + "<br />";
            mm.Body += "Name of Employer: " + tbxEmployerName1.Text + "<br />";
            mm.Body += "Wage: " + tbxEmployerWage1.Text + "<br />";
            mm.Body += "Position Held: " + tbxPositionHeld1.Text + "<br />";
            mm.Body += "Reason for leaving: " + tbxReasonForLeaving1.Text + "<br /><br />";

            mm.Body += "<b><u>Former Employer #2</u></b><br />";
            mm.Body += "Date Job Began: " + tbxDateJobBegan2.Text + "<br />";
            mm.Body += "Date Job Ended: " + tbxDateJobEnded2.Text + "<br />";
            mm.Body += "Name of Employer: " + tbxEmployerName2.Text + "<br />";
            mm.Body += "Wage: " + tbxEmployerWage2.Text + "<br />";
            mm.Body += "Position Held: " + tbxPositionHeld2.Text + "<br />";
            mm.Body += "Reason for leaving: " + tbxReasonForLeaving2.Text + "<br /><br />";

            mm.Body += "<b><u>Former Employer #3</u></b><br />";
            mm.Body += "Date Job Began: " + tbxDateJobBegan3.Text + "<br />";
            mm.Body += "Date Job Ended: " + tbxDateJobEnded3.Text + "<br />";
            mm.Body += "Name of Employer: " + tbxEmployerName3.Text + "<br />";
            mm.Body += "Wage: " + tbxEmployerWage3.Text + "<br />";
            mm.Body += "Position Held: " + tbxPositionHeld3.Text + "<br />";
            mm.Body += "Reason for leaving: " + tbxReasonForLeaving3.Text + "<br /><br />";

            mm.Body += "<b><u>Reference #1</u></b><br />";
            mm.Body += "Name: " + tbxReferenceName1.Text + "<br />";
            mm.Body += "Address: " + tbxReferenceAddress1.Text + "<br />";
            mm.Body += "Phone #: " + tbxReferencePhone1.Text + "<br />";

            mm.Body += "<b><u>Reference #2</u></b><br />";
            mm.Body += "Name: " + tbxReferenceName2.Text + "<br />";
            mm.Body += "Address: " + tbxReferenceAddress2.Text + "<br />";
            mm.Body += "Phone #: " + tbxReferencePhone2.Text + "<br />";

            mm.Body += "<b><u>Reference #3</u></b><br />";
            mm.Body += "Name: " + tbxReferenceName3.Text + "<br />";
            mm.Body += "Address: " + tbxReferenceAddress3.Text + "<br />";
            mm.Body += "Phone #: " + tbxReferencePhone3.Text + "<br />";

            try
            {
                SmtpMail.Send(mm);
                Response.Write("Application sent successfully! Thank you.");
            }
            catch
            {
                Response.Write("<font color=\"#ff0000\">Sending of application has failed. We apologize for the inconvenience. Please call (801) 785-8188 or email to Apply@Fordscleaning.com.</font>");
            }
            finally
            {
                Response.End();
            }
        }
        else
        {
            if (!cbxIAgree.Checked)
                requiredagree.InnerHtml = "You must agree to the terms or forego applying.";
            if (tbxVerify.Text != sTxtVerify)
                requiredAuthentication.InnerHtml = "The code you entered does not match the image.";
        }
    }

    public string getRandomAlphaNumeric()
    {

        RandomNumberGenerator rm;
        rm = RandomNumberGenerator.Create();

        byte[] data = new byte[3];

        rm.GetNonZeroBytes(data);

        string sRand = "";
        string sTmp = "";

        for (int nCnt = 0; nCnt <= data.Length - 1; nCnt++)
        {
            int nVal = Convert.ToInt32(data.GetValue(nCnt));

            if (nVal > 32 && nVal < 127)
            {
                sTmp = Convert.ToChar(nVal).ToString();
            }
            else
            {
                sTmp = nVal.ToString();
            }

            sRand += sTmp.ToString();
        }

        return sRand;
    }
}
