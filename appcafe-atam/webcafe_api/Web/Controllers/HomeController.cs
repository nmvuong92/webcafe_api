using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Web.Mvc;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using VD.Lib;
using VD.Lib.DTO;
using Web.Security;

namespace Web.Controllers
{
    public class HomeController : BaseController
    {
        public ContentResult SendOneSignal()
        {
            OneSignalAPI api =new OneSignalAPI();
            string msgr = "ax";// api.SendMsg();
            return Content(msgr);
        }
        // GET: Home
        public ActionResult Index()
        {
            return RedirectToAction("Index", "DonHang", new {area = "Admin"});
        }
        [HttpPost]
        public JsonResult validation_captcha(string capt, string prefix)
        {
            rs r;
            //validate captcha 
            var trueCapt = (Session["Captcha" + prefix] != null && Session["Captcha" + prefix].ToString().ToLower() == capt.ToLower());
            if (trueCapt)
            {
                r = rs.T("ok");
            }
            else
            {
                r = rs.F("err");

            }
            return Json(r, JsonRequestBehavior.DenyGet);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult SetCulture(string culture)
        {
            // Validate input
            //culture = CultureHelper.GetImplementedCulture(culture);
            // Save culture in a cookie
            myCookies.SetLang(culture);
            return Json(culture, JsonRequestBehavior.AllowGet);
        }


        public ActionResult CaptchaImage(string prefix, bool noisy = true)
        {
            var rand = new Random((int)DateTime.Now.Ticks);
            //generate new question 
            int a = rand.Next(10, 99);
            int b = rand.Next(0, 9);

            var captcha = myNumbers.RandomString(3);

            //store answer 
            Session["Captcha" + prefix] = captcha;

            //image stream 
            FileContentResult img = null;

            using (var mem = new MemoryStream())
            using (var bmp = new Bitmap(130, 30))
            using (var gfx = Graphics.FromImage((Image)bmp))
            {
                gfx.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                gfx.SmoothingMode = SmoothingMode.AntiAlias;
                gfx.FillRectangle(Brushes.White, new Rectangle(0, 0, bmp.Width, bmp.Height));

                //add noise 
                if (noisy)
                {
                    int i, r, x, y;
                    var pen = new Pen(Color.Yellow);
                    for (i = 1; i < 10; i++)
                    {
                        pen.Color = Color.FromArgb(
                            (rand.Next(0, 255)),
                            (rand.Next(0, 255)),
                            (rand.Next(0, 255)));

                        r = rand.Next(0, (130 / 3));
                        x = rand.Next(0, 130);
                        y = rand.Next(0, 30);
                        gfx.DrawEllipse(pen, x - r, y - r, r, r);
                    }
                }

                //add question 
                gfx.DrawString(captcha, new Font("Tahoma", 15), Brushes.Gray, 2, 3);

                //render as Jpeg 
                bmp.Save(mem, System.Drawing.Imaging.ImageFormat.Jpeg);
                img = this.File(mem.GetBuffer(), "image/Jpeg");
            }

            return img;
        }

    }
}