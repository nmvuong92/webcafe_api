using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using VD.Data;
using VD.Data.IRepository;
using VD.Lib;
using VD.Lib.DTO;
using Web.Controllers;
using Web.Security;
using Web.ViewModels;

namespace Web.Areas.Admin.Controllers
{
    [myAuth]
    public class AjaxController : BaseController
    {
        [HttpPost]
        public JsonResult UploadImg(string pathAppSettings = "", int sw = 200, int sh = 200, int reducePercent=70)
        {
            rs r;
            try
            {
                string getPathAppSetting = myAppSetings.Setting<string>(pathAppSettings);
                var file = Request.Files[0];
                string path = "";
                string real_path = "";
                if (file != null)
                {
                    string etx = System.IO.Path.GetExtension(file.FileName);
                    string pic_name = Guid.NewGuid() + etx;
                    path = System.IO.Path.Combine(
                                            Server.MapPath("~" + getPathAppSetting), pic_name);
                    real_path = getPathAppSetting + "/" + pic_name;
                    //file.SaveAs(path);
                    using (var ms = new MemoryStream())
                    {
                        file.InputStream.CopyTo(ms);
                        Image image = Image.FromStream(ms);
                        myImage.ResizeAndSaveImage(image, path, sw, sh,reducePercent);
                    }
                }
                r = rs.T("Okay!", real_path);
            }
            catch (Exception ex)
            {
                r = rs.F(ex.Message);
            }
            return Json(r, JsonRequestBehavior.DenyGet);
        }

    }
}