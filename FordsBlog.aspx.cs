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

public partial class _Default : System.Web.UI.Page
{
    int iPageNum;
    int iPages = 0;
    HyperLink hl;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            iPageNum = Convert.ToInt32(Request.QueryString["p"]);
        }
        catch
        {
            iPageNum = 0;
        }

        bool bShow = false;

        AddPageNav();

        LiteralControl lcc = new LiteralControl("<br />");
        blogposts.Controls.Add(lcc);

        DataTable dtBlogs = DataLayer.GetFiveBlogsBy_page(iPageNum);

        foreach (DataRow drBlog in dtBlogs.Rows)
        {
            int iBlogID = Convert.ToInt32(drBlog.ItemArray[0]);
            string sTitle = drBlog.ItemArray[1].ToString();
            DateTime dtDate = Convert.ToDateTime(drBlog.ItemArray[3]);
            string sBody = drBlog.ItemArray[2].ToString(); ;

            if (sBody.Contains("~"))
            {
                int iIndex = sBody.IndexOf('~');
                sBody = sBody.Remove(iIndex) + "<br /><br /><a href=\"http://www.fordscleaning.com/Blog.aspx?blog=" + iBlogID.ToString() + "\">(Read More)</a>";
            }
            else
            {
                sBody = "No Summary. <a href=\"http://www.fordscleaning.com/Blog.aspx?blog=" + iBlogID.ToString() + "\">(Read)</a>"; ;
            }

            int iNumComments = DataLayer.GetCommentCountBy_blogID(iBlogID);

            LiteralControl lc = new LiteralControl(
                "<div class=\"blog\">" +
                "<table border=\"0\" cellspacing=\"0\" width=\"100%\"><tr><td><div class=\"blogtitle\"><a class=\"titlelink\" href=\"http://www.fordscleaning.com/Blog.aspx?blog=" + iBlogID.ToString() + "\">" + sTitle + "</a></div>" + dtDate.ToString() + " &nbsp " + iNumComments.ToString() +
                " Comments</td><td align=\"right\">"
            );
            blogposts.Controls.Add(lc);
            if ((User.Identity.Name.ToUpper() == "WALT") && (User.Identity.IsAuthenticated))
            {
                Button btnEdit = new Button();
                btnEdit.ID = iBlogID.ToString();
                btnEdit.PostBackUrl = "http://www.fordscleaning.com/admin/AddEditBlog.aspx?blog=" + iBlogID.ToString();
                btnEdit.Text = "Edit";
                blogposts.Controls.Add(btnEdit);
            }
            lc = new LiteralControl(
                "</td></tr><tr><td colspan=\"2\">" +
                "<div class=\"blogcontent\">" + sBody + "</div>" +
                "</td></tr></table></div>"
            );
            blogposts.Controls.Add(lc);
        }

        AddPageNav();

        LiteralControl lc2 = new LiteralControl("<br /><br />");
        blogposts.Controls.Add(lc2);

    }

    protected void AddPageNav()
    {
        LiteralControl lc = new LiteralControl("<div style=\"text-align: right;\">");
        blogposts.Controls.Add(lc);

        iPages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(DataLayer.GetBlogCountNotDeleted()) / 5m)) - 1;
        if (iPageNum > iPages)
        {
            iPageNum = 0;
        }

        if (iPageNum > 0)
        {
            hl = new HyperLink();
            hl.Text = "<<";
            hl.NavigateUrl = "http://www.fordscleaning.com/FordsBlog.aspx?p=0";
            blogposts.Controls.Add(hl);

            lc = new LiteralControl(" ");
            blogposts.Controls.Add(lc);

            hl = new HyperLink();
            hl.Text = "<";
            hl.NavigateUrl = "http://www.fordscleaning.com/FordsBlog.aspx?p=" + Convert.ToString(iPageNum - 1);
            blogposts.Controls.Add(hl);

            lc = new LiteralControl(" ");
            blogposts.Controls.Add(lc);
        }

        int imin = 0;
        int imax = iPages;

        if (iPageNum < 5)
        {
            imin = 0;
            if (iPages >= 9)
            {
                imax = 9;
            }
        }
        else if (iPageNum > (iPages - 5))
        {
            if (iPages >= 9)
            {
                imin = iPages - 9;
            }
            imax = iPages;
        }
        else
        {
            if (iPages >= 9)
            {
                imin = iPageNum - 5;
                imax = iPageNum + 5;
            }
        }

        for (int iPageCount = imin; iPageCount <= imax; iPageCount++)
        {
            if (iPageNum != iPageCount)
            {
                hl = new HyperLink();
                hl.Text = Convert.ToString(iPageCount + 1);
                hl.NavigateUrl = "http://www.fordscleaning.com/FordsBlog.aspx?p=" + iPageCount;
                blogposts.Controls.Add(hl);
            }
            else
            {
                if (imax > 0)
                {
                    lc = new LiteralControl("<span style=\"font-size: 35px;\">" + Convert.ToString(iPageCount + 1) + "</span>");
                    blogposts.Controls.Add(lc);
                }
            }

            lc = new LiteralControl(" ");
            blogposts.Controls.Add(lc);
        }

        if (iPageNum < iPages)
        {
            hl = new HyperLink();
            hl.Text = ">";
            hl.NavigateUrl = "http://www.fordscleaning.com/FordsBlog.aspx?p=" + Convert.ToString(iPageNum + 1);
            blogposts.Controls.Add(hl);

            lc = new LiteralControl(" ");
            blogposts.Controls.Add(lc);

            hl = new HyperLink();
            hl.Text = ">>";
            hl.NavigateUrl = "http://www.fordscleaning.com/FordsBlog.aspx?p=" + iPages;
            blogposts.Controls.Add(hl);
        }

        lc = new LiteralControl("</div>");
        blogposts.Controls.Add(lc);
    }
}
