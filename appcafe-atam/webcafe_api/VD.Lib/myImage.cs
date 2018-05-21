using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace VD.Lib
{
    public class myImage
    {
        public MemoryStream BytearrayToStream(byte[] arr)
        {
            return new MemoryStream(arr, 0, arr.Length);
        }
        public static Image RezizeImage(Image img, int maxWidth, int maxHeight)
        {
            if (img.Height < maxHeight && img.Width < maxWidth) return img;
            using (img)
            {
                Double xRatio = (double)img.Width / maxWidth;
                Double yRatio = (double)img.Height / maxHeight;
                Double ratio = Math.Max(xRatio, yRatio);
                int nnx = (int)Math.Floor(img.Width / ratio);
                int nny = (int)Math.Floor(img.Height / ratio);
                Bitmap cpy = new Bitmap(nnx, nny, PixelFormat.Format32bppArgb);
                using (Graphics gr = Graphics.FromImage(cpy))
                {
                    gr.Clear(Color.Transparent);

                    // This is said to give best quality when resizing images
                    gr.InterpolationMode = InterpolationMode.HighQualityBicubic;

                    gr.DrawImage(img,
                        new Rectangle(0, 0, nnx, nny),
                        new Rectangle(0, 0, img.Width, img.Height),
                        GraphicsUnit.Pixel);
                }
                return cpy;
            }
        }
        public static void ResizeAndSaveImage(Image image, string path, int rzW, int rzH, int reducePercent = 70)
        {

            if (image.Size.Width > rzW || image.Size.Height > rzH)
            {
                image = myImage.RezizeImage(image, rzW, rzH);

            }
            if (true)
            {
                // Encoder parameter for image quality 
                EncoderParameter qualityParam = new EncoderParameter(Encoder.Quality, reducePercent);
                // JPEG image codec 
                string ext = Path.GetExtension(path).ToLower();
                bool png = ext.Contains("png") || ext.Contains("gif");
                ImageCodecInfo jpegCodec = GetEncoderInfo(png?"image/png":"image/jpeg");
                EncoderParameters encoderParams = new EncoderParameters(1);
                encoderParams.Param[0] = qualityParam;
                image.Save(path, jpegCodec, encoderParams);

            }
            else
            {
                image.Save(path);
            }
        }

        /// <summary> 
        /// Saves an image as a jpeg image, with the given quality 
        /// </summary> 
        /// <param name="path"> Path to which the image would be saved. </param> 
        /// <param name="quality"> An integer from 0 to 100, with 100 being the highest quality. </param> 
        public static void SaveJpeg(string path, Image img, int quality)
        {
            if (quality < 0 || quality > 100)
                throw new ArgumentOutOfRangeException("quality must be between 0 and 100.");

            // Encoder parameter for image quality 
            EncoderParameter qualityParam = new EncoderParameter(Encoder.Quality, quality);
            // JPEG image codec 
            ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;
            img.Save(path, jpegCodec, encoderParams);
        }

        /// <summary> 
        /// Returns the image codec with the given mime type 
        /// </summary> 
        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            // Get image codecs for all image formats 
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            // Find the correct image codec 
            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];

            return null;
        }
        public static string GetImg(string link)
        {
            if (string.IsNullOrWhiteSpace(link))
            {
                link = "http://b.dryicons.com/images/icon_sets/iconika_grey_icons/png/128x128/upload.png";
            }
            return link;
        }
    }
}
