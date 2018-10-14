using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
namespace myPuzzle
{
    class CutPicture
    {
        public static string picturePath = "";
        public static List<Bitmap> BitMapList = null;
        ///</summary>
        ///<param name="path"> 文件路径 </param>
        ///调整的宽，高
        ///<returns>
        public static Image Resize(string path,int iWidth,int iHight)
        {
            Image thumbnail = null;
            try
            {
                var img = Image.FromFile(path);
                thumbnail = img.GetThumbnailImage(iWidth, iHight, null, IntPtr.Zero);
                thumbnail.Save(Application.StartupPath.ToString() + "\\Picture\\img.jpeg");

            }
            catch(Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            return thumbnail;



        }
        ///剪切图片
        public static Bitmap Cut(Image b, int StartX,int StartY,int iWidth,int iHight)
        {
            if (b == null) return null;
            int w = b.Width;
            int h = b.Height;
            if (StartX >= w || StartY >= h) return null;
            if (StartX + iWidth > 
                w) iWidth = w - StartX;
            if (StartY + iHight > h) iHight = h - StartY;
            try
            {
                Bitmap bmpOut = new Bitmap(iWidth, iHight, PixelFormat.Format24bppRgb);
                Graphics g = Graphics.FromImage(bmpOut);
                g.DrawImage(b, new Rectangle(0, 0, iWidth, iHight), new Rectangle(StartX, StartY, iWidth, iHight), GraphicsUnit.Pixel);
                g.Dispose();
                return bmpOut;
            }
            catch
            {
                return null;
            }
        }
    }
}
