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
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Design;
using System.Drawing.Text;

public partial class GenerateVerificationImage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string sText = Request.QueryString["txt"];
        if (sText != null)
        {
            Bitmap bmp = generateImage(sText);
            Response.ContentType = "image/gif";
            bmp.Save(Response.OutputStream, ImageFormat.Gif);
            bmp.Dispose();
        }
    }

    public Bitmap generateImage(string sTextToImg)
    {
        PixelFormat pxImagePattern = PixelFormat.Format32bppArgb;
        Bitmap bmpImage = new Bitmap(1, 1, pxImagePattern);
        Font fntImageFont = new Font("COURIER ", 15);
        Graphics gdImageGrp = Graphics.FromImage(bmpImage);

        float iWidth = gdImageGrp.MeasureString(sTextToImg, fntImageFont).Width;
        float iHeight = gdImageGrp.MeasureString(sTextToImg, fntImageFont).Height;

        bmpImage = new Bitmap((int)iWidth, (int)iHeight, pxImagePattern);

        gdImageGrp = Graphics.FromImage(bmpImage);
        gdImageGrp.Clear(Color.White);

        gdImageGrp.TextRenderingHint = TextRenderingHint.AntiAlias;

        gdImageGrp.DrawString(sTextToImg, fntImageFont, new SolidBrush(Color.Red), 0, 0);
        gdImageGrp.Flush();

        return bmpImage;
    }
}
