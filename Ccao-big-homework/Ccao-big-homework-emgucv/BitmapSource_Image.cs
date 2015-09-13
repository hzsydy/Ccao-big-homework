//Du 2015.9
//All rights reserved.
//参考了官方文档http://www.emgu.com/wiki/index.php/WPF_in_CSharp

using Emgu.CV;
using Emgu.CV.Structure;
using System.Runtime.InteropServices;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Ccao_big_homework_emgucv
{
    /// <summary>
    /// 将Bitmapsource和IImage互相转化的辅助类。
    /// </summary>
    public class BitmapSource_Image
    {
        /// <summary>
        /// 来自官方文档
        /// Delete a GDI object
        /// </summary>
        /// <param name="o">The poniter to the GDI object to be deleted</param>
        /// <returns></returns>
        [DllImport("gdi32")]
        private static extern int DeleteObject(IntPtr o);

        /// <summary>
        /// 来自官方文档
        /// Convert an IImage to a WPF BitmapSource. The result can be used in the Set Property of Image.Source
        /// </summary>
        /// <param name="image">The Emgu CV Image</param>
        /// <returns>The equivalent BitmapSource</returns>
        public static BitmapSource Image2BitmapSource(IImage image)
        {
            using (System.Drawing.Bitmap source = image.Bitmap)
            {
                IntPtr ptr = source.GetHbitmap(); //obtain the Hbitmap

                BitmapSource bs = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                    ptr,
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());

                DeleteObject(ptr); //release the HBitmap
                return bs;
            }
        }

        public static Image<Bgr, Byte> BitmapSource2Image(BitmapSource bitmapsource)
        {
            System.Drawing.Bitmap bitmap;
            MemoryStream outStream = new MemoryStream();
            BitmapEncoder be = new BmpBitmapEncoder();
            be.Frames.Add(BitmapFrame.Create(bitmapsource));
            be.Save(outStream);
            bitmap = new System.Drawing.Bitmap(outStream);
            Image<Bgr, Byte> image = new Image<Bgr, Byte>(bitmap);
            return image;
        }
    }
}
