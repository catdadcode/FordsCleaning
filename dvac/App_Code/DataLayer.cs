using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for DataLayer
/// </summary>
public class DataLayer
{
    static SqlConnection sConnection = new SqlConnection("Data Source=whsql-v22.prod.mesa1.secureserver.net; Initial Catalog=JiddSpace; User ID=JiddSpace; Password='Ch3vyF0rd!';");

    public DataLayer()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static void CloseConn()
    {
        sConnection.Close();
    }

    public static int AddJob(Guid gCustomerID, DateTime dtDate, string sJobType, string sAddress, string sJobDescription, string sJobNotes)
    {
        sAddress = sAddress.Replace("'", "''");
        sJobDescription = sJobDescription.Replace("'", "''");
        sJobNotes = sJobNotes.Replace("'", "''");
        SqlCommand scomm = new SqlCommand("INSERT INTO dJobs VALUES (NEWID(), '" + gCustomerID.ToString() + "', '" + dtDate + "', '" + sJobType + "', '" + sAddress + "', '" + sJobDescription + "', '" + sJobNotes + "', 'False')", sConnection);
        sConnection.Open();
        int iRowsAffected = scomm.ExecuteNonQuery();
        sConnection.Close();
        return iRowsAffected;
    }

    public static int UpdateJob(Guid gJobID, Guid gCustomerID, DateTime dtDate, string sJobType, string sAddress, string sJobDescription, string sJobNotes)
    {
        sAddress = sAddress.Replace("'", "''");
        sJobDescription = sJobDescription.Replace("'", "''");
        sJobNotes = sJobNotes.Replace("'", "''");
        SqlCommand scomm = new SqlCommand("UPDATE dJobs SET [Customer ID]='" + gCustomerID.ToString() + "', Date='" + dtDate + "', [Job Type]='" + sJobType + "', Address='" + sAddress + "', Description='" + sJobDescription + "', Notes='" + sJobNotes + "' WHERE [Job ID]='" + gJobID.ToString() + "'", sConnection);
        sConnection.Open();
        int iRowsAffected = scomm.ExecuteNonQuery();
        sConnection.Close();
        return iRowsAffected;
    }

    public static int DeleteJob(Guid gJobID)
    {
        SqlCommand scomm = new SqlCommand("DELETE FROM dJobs WHERE [Job ID]='" + gJobID.ToString() + "'", sConnection);
        sConnection.Open();
        int iRowsAffected = scomm.ExecuteNonQuery();
        sConnection.Close();
        return iRowsAffected;
    }

    public static int CompleteJob(Guid gJobID)
    {
        SqlCommand scomm = new SqlCommand("UPDATE dJobs SET Complete='True' WHERE [Job ID]='" + gJobID.ToString() + "'", sConnection);
        sConnection.Open();
        int iRowsAffected = scomm.ExecuteNonQuery();
        sConnection.Close();
        return iRowsAffected;
    }

    public static DataTable GetJobsBy_Date(DateTime dtDate)
    {
        DataTable dt = new DataTable();
        string sDate = dtDate.Month.ToString() + "/" + dtDate.Day.ToString() + "/" + dtDate.Year.ToString();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM dJobs WHERE Date BETWEEN '" + sDate + " 7:00:00 AM' AND '" + sDate + " 7:30:00 PM' AND Complete='False' ORDER BY Date ASC", sConnection);
        sda.Fill(dt);
        return dt;
    }

    public static DataTable GetJobBy_JobID(Guid gJobID)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM dJobs WHERE [Job ID]='" + gJobID.ToString() + "'", sConnection);
        sda.Fill(dt);
        return dt;
    }

    public static int AddCustomerUpFront(string sName, string sPhone, string sEmail, DateTime dtNextReminder)
    {
        sEmail = sEmail.Replace("'", "''");
        SqlCommand scomm = new SqlCommand("INSERT INTO dCustomers VALUES (NEWID(), '" + sName + "', '" + sPhone + "', '" + sEmail + "', NULL, NULL, NULL, NULL, '" + dtNextReminder.ToString() + "', NULL)", sConnection);
        sConnection.Open();
        int iRowsAffected = scomm.ExecuteNonQuery();
        sConnection.Close();
        return iRowsAffected;
    }

    public static DataTable GetCustomerBy_CustomerID(Guid gCustomerID)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM dCustomers WHERE [Customer ID]='" + gCustomerID.ToString() + "'", sConnection);
        sda.Fill(dt);
        return dt;
    }

    public static DataTable GetCustomersBy_SearchQuery(string sQuery)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM dCustomers WHERE Name LIKE '%" + sQuery + "%'", sConnection);
        sda.Fill(dt);
        return dt;
    }

    public static DataSet CustomQuery(string sQuery)
    {
        DataSet ds = new DataSet();
        SqlDataAdapter sda = new SqlDataAdapter(sQuery, sConnection);
        sda.Fill(ds);
        return ds;
    }
}
