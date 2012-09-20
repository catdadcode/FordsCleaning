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
    static SqlConnection sConnection = new SqlConnection("dummy");

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

    public static int AddBlog(string sTitle, string sBody, DateTime dtTimeStamp)
    {
        int iBlogID = GetBlogCountDeleted();

        SqlCommand scomm = new SqlCommand("INSERT INTO fordsblogs VALUES (@BlogID,@Title,@Body,@TimeStamp,'false')", sConnection);
        scomm.Parameters.Add(new SqlParameter("Title", sTitle));
        scomm.Parameters.Add(new SqlParameter("Body", sBody));
        scomm.Parameters.Add(new SqlParameter("TimeStamp", dtTimeStamp));
        scomm.Parameters.Add(new SqlParameter("BlogID", iBlogID));
        sConnection.Open();
        int iRowsAffected = scomm.ExecuteNonQuery();
        sConnection.Close();
        return iRowsAffected;
    }

    public static int UpdateBlog(int iBlogID, string sTitle, string sBody)
    {
        SqlCommand scomm = new SqlCommand("UPDATE fordsblogs SET title=@Title,body=@Body WHERE blogID=@BlogID", sConnection);
        scomm.Parameters.Add(new SqlParameter("BlogID", iBlogID));
        scomm.Parameters.Add(new SqlParameter("Title", sTitle));
        scomm.Parameters.Add(new SqlParameter("Body", sBody));
        sConnection.Open();
        int iRowsAffected = scomm.ExecuteNonQuery();
        sConnection.Close();
        return iRowsAffected;
    }

    public static int DeleteBlog(int iBlogID)
    {
        SqlCommand scomm = new SqlCommand("UPDATE fordsblogs SET deleted='true' WHERE blogID=@BlogID", sConnection);
        scomm.Parameters.Add(new SqlParameter("BlogID", iBlogID));
        sConnection.Open();
        int iRowsAffected = scomm.ExecuteNonQuery();
        sConnection.Close();
        return iRowsAffected;
    }

    public static int AddNewsletterEmail(string sEmail)
    {
        SqlCommand scomm = new SqlCommand("INSERT INTO fordsNewsletter VALUES (@Email)", sConnection);
        scomm.Parameters.Add(new SqlParameter("Email", sEmail));
        sConnection.Open();
        int iRowsAffected = scomm.ExecuteNonQuery();
        sConnection.Close();
        return iRowsAffected;
    }

    public static int RemoveNewsletterEmail(string sEmail)
    {
        SqlCommand scomm = new SqlCommand("DELETE FROM fordsNewsletter WHERE Email=@Email", sConnection);
        scomm.Parameters.Add(new SqlParameter("Email", sEmail));
        sConnection.Open();
        int iRowsAffected = scomm.ExecuteNonQuery();
        sConnection.Close();
        return iRowsAffected;
    }

    public static DataTable RetrieveNewsletterList()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT Email FROM fordsNewsletter", sConnection);
        sda.Fill(dt);
        return dt;
    }

    public static int AddComment(int iBlogID, string sUsername,
        string sBody, DateTime dtTimeStamp, string sWebsite)
    {
        int iCommentID = GetCommentCount();

        SqlCommand scomm = new SqlCommand("INSERT INTO fordscomments VALUES (@CommentID,@BlogID,@Username,@Body,@TimeStamp,'false',@Website)", sConnection);
        scomm.Parameters.Add(new SqlParameter("BlogID", iBlogID));
        scomm.Parameters.Add(new SqlParameter("Username", sUsername));
        scomm.Parameters.Add(new SqlParameter("Body", sBody));
        scomm.Parameters.Add(new SqlParameter("TimeStamp", dtTimeStamp));
        scomm.Parameters.Add(new SqlParameter("Website", sWebsite));
        scomm.Parameters.Add(new SqlParameter("CommentID", iCommentID));
        sConnection.Open();
        int iRowsAffected = scomm.ExecuteNonQuery();
        sConnection.Close();
        return iRowsAffected;
    }

    //public static int UpdateComment(int iCommentID, string sBody)
    //{
    //    SqlCommand scomm = new SqlCommand("UPDATE blogs SET title='" + sTitle + "',body='" + sBody + "' WHERE blogID='" + iBlogID.ToString() + "'", sConnection);
    //    sConnection.Open();
    //    int iRowsAffected = scomm.ExecuteNonQuery();
    //    sConnection.Close();
    //    return iRowsAffected;
    //}

    public static int DeleteComment(int iCommentID)
    {
        SqlCommand scomm = new SqlCommand("UPDATE fordscomments SET deleted='true' WHERE commentID=@CommentID", sConnection);
        scomm.Parameters.Add(new SqlParameter("CommentID", iCommentID));
        sConnection.Open();
        int iRowsAffected = scomm.ExecuteNonQuery();
        sConnection.Close();
        return iRowsAffected;
    }

    public static int GetBlogCountNotDeleted()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*)AS 'Blog Count' FROM fordsblogs WHERE deleted='false'", sConnection);
        sda.Fill(dt);
        return Convert.ToInt32(dt.Rows[0].ItemArray[0]);

    }

    public static int GetBlogCountDeleted()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*)AS 'Blog Count' FROM fordsblogs", sConnection);
        sda.Fill(dt);
        return Convert.ToInt32(dt.Rows[0].ItemArray[0]);

    }

    public static int GetCommentCount()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*)AS 'Comment Count' FROM fordscomments", sConnection);
        sda.Fill(dt);
        return Convert.ToInt32(dt.Rows[0].ItemArray[0]);
    }

    public static DataTable GetFiveBlogsBy_page(int iPageNumber)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT TOP 5 * FROM fordsblogs WHERE blogID NOT IN (SELECT TOP (" + iPageNumber.ToString() + "*5) blogID FROM fordsblogs WHERE deleted='false' ORDER BY date DESC) AND deleted='false' ORDER BY date DESC", sConnection);
        sda.Fill(dt);
        return dt;
    }

    public static DataTable GetBlogsBy_blogID(int iBlogID)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT * FROM fordsblogs WHERE blogID=@BlogID", sConnection);
        sc.Parameters.Add(new SqlParameter("BlogID", iBlogID));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }

    public static DataTable GetLatestBlog()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT TOP 1 * FROM fordsblogs WHERE deleted='false' ORDER BY date DESC", sConnection);
        sda.Fill(dt);
        return dt;
    }

    public static DataTable GetCommentsBy_blogID(int iBlogID)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT * FROM fordscomments WHERE blogID=@BlogID", sConnection);
        sc.Parameters.Add(new SqlParameter("BlogID", iBlogID));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return dt;
    }


    public static int GetCommentCountBy_blogID(int iBlogID)
    {
        DataTable dt = new DataTable();
        SqlCommand sc = new SqlCommand("SELECT COUNT(*)AS 'Comment Count' FROM fordscomments WHERE blogID=@BlogID AND deleted='false'", sConnection);
        sc.Parameters.Add(new SqlParameter("BlogID", iBlogID));
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        sda.Fill(dt);
        return Convert.ToInt32(dt.Rows[0].ItemArray[0]);
    }

    public static DataSet CustomQuery(string sQuery)
    {
        DataSet ds = new DataSet();
        SqlDataAdapter sda = new SqlDataAdapter(sQuery, sConnection);
        sda.Fill(ds);
        return ds;
    }
}
