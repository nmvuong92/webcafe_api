using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace Web
{
    public class XuLyAnh
    {
        public byte[] ImageToByte(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
        }
        public byte[] BitmapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }

        public Bitmap ByteToBitmap(byte[] bytearray)
        {
            Bitmap bmp;
            using (var ms = new MemoryStream(bytearray))
            {
                bmp = new Bitmap(ms);
            }
            return bmp;
        }
        public Bitmap Merge(List<string> paths)
        {
            
            var first_target = new Bitmap(paths.First());

            var target = new Bitmap(first_target.Width, first_target.Height, PixelFormat.Format32bppArgb);
            var graphics = Graphics.FromImage(target);
            graphics.CompositingMode = CompositingMode.SourceOver; // this is the default, but just to be clear


            graphics.DrawImage(first_target, 0, 0);


            for (int i = 1; i < paths.Count; i++)
            {
                Bitmap source = new Bitmap(paths[i]);
                graphics.DrawImage(source, 0, 0);
            }
           

           // target.Save("filename.png", ImageFormat.Png);

            return target;
        }
        /*
        public void DeleteAllFileInFolder()
        {
            CreateFolderIfNotExists();
            System.IO.DirectoryInfo di = new DirectoryInfo(@"C:\EkkoTest\");

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }
        */
        /*
        public Image LayAnhTuPath(string path)
        {
            path=System.Web.HttpContext.Current.Server.MapPath(path);

            Image img;
            using (var bmpTemp = new Bitmap(path))
            {
                img = new Bitmap(bmpTemp);
            }

            return img;
        }*/
        // This method is for converting bitmap into a byte array
      
        /*
        public void CreateFolderIfNotExists()
        {

            bool exists = Directory.Exists(@"C:\EkkoTest\");
            if (!exists)
                Directory.CreateDirectory(@"C:\EkkoTest\");
        }*/
        /*
        public byte[] NenAnh(Image img, int quality)
        {
            CreateFolderIfNotExists();
            EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            // JPEG image codec 
            ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;
            string __p =System.Web.HttpContext.Current.Server.MapPath("~/content/bqc-export/1.png");
            img.Save(__p, jpegCodec, encoderParams);
            Image anh = LayAnhTuPath(__p);
            return ImageToByteArray(anh);
        }

        */
        /// <summary> 
        /// Returns the image codec with the given mime type 
        /// </summary> 
        /*private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            // Get image codecs for all image formats 
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            // Find the correct image codec 
            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];

            return null;
        } */

    }
}