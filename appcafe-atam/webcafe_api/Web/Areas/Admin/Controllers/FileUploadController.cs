using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Transactions;
using System.Web.Hosting;
using System.Web.Mvc;
using VD.Data;
using VD.Data.Entity.MF;
using VD.Lib.DTO;
using Web.Helpers;
using Web.Models;
using Web.Security;

namespace Web.Areas.Admin.Controllers
{
    [myAuth(Roles = "1")]
    public class FileUploadController : Controller
    {
        private vuong_cms_context __db = new vuong_cms_context();
        FilesHelper filesHelper;
        String tempPath = "~/somefiles/";
        String serverMapPath = "~/Files/somefiles/";
        private string StorageRoot
        {
            get { return Path.Combine(HostingEnvironment.MapPath(serverMapPath)); }
        }
        private string UrlBase = "/Files/somefiles/";
        String DeleteURL = "/FileUpload/DeleteFile/?file=";
        String DeleteType = "GET";
        public FileUploadController()
        {
            filesHelper = new FilesHelper(DeleteURL, DeleteType, StorageRoot, UrlBase, tempPath, serverMapPath);
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Show()
        {
            JsonFiles ListOfFiles = filesHelper.GetFileList();
            var model = new FilesViewModel()
            {
                Files = ListOfFiles.files
            };

            return View(model);
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Upload(int imgtmpid, int thumbw, int thumbh)
        {
            var resultList = new List<ViewDataUploadFilesResult>();
            var currentContext = HttpContext;
            filesHelper.UploadAndShowResults(currentContext, resultList,thumbw,thumbh);
            JsonFiles files = new JsonFiles(resultList);

            bool isEmpty = !resultList.Any();
            if (isEmpty)
            {
                return Json("Error ");
            }
            else
            {
                var lst = new List<ImgTmpDetail>();
                foreach (var item in files.files)
                {
                    ImgTmpDetail model = new ImgTmpDetail();
                    model.FullImage = item.url;
                    model.Thumbnail = item.thumbnailUrl;
                    model.ImgTmpId = imgtmpid;
                    lst.Add(model);
                }
                if (lst.Any())
                {
                    __db.ImgTmpDetail.AddRange(lst);
                    __db.SaveChanges();
                }
                return Json(files);
            }
        }
        public JsonResult GetFileList()
        {
            var list = filesHelper.GetFileList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult DeleteFile(string file)
        {
            filesHelper.DeleteFile(file);
            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult GetFiles(int imgtempid)
        {
            var model = __db.ImgTmp.FirstOrDefault(f => f.Id == imgtempid);
            return PartialView(model);
        }

        [HttpGet]
        public JsonResult DeleteImage(int id)
        {
            rs rs;
            try
            {
                var tim = __db.ImgTmpDetail.FirstOrDefault(f => f.Id == id);
                __db.ImgTmpDetail.Remove(tim);
                __db.SaveChanges();

                try
                {

                    string fullPath = Request.MapPath("~" + tim.FullImage);
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }
                    string fullPath2 = Request.MapPath("~" + tim.Thumbnail);
                    if (System.IO.File.Exists(fullPath2))
                    {
                        System.IO.File.Delete(fullPath2);
                    }
                }
                catch (Exception ex)
                {
                    
                }
                rs = rs.T("Ok");
            }
            catch (Exception ex)
            {
                rs = rs.F(ex.Message);
            }
            return Json(rs, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult SetMain(int id)
        {
            rs rs;
            try
            {
                using (var dbcontext = new vuong_cms_context())
                {
                    using (var tx = new TransactionScope())
                    {
                        var tim = dbcontext.ImgTmpDetail.FirstOrDefault(f => f.Id == id);
                        dbcontext.Database.ExecuteSqlCommand("UPDATE ImgTmpDetails SET [IsMain]=0 WHERE [ImgTmpId]=" + tim.ImgTmpId);
                        dbcontext.Database.ExecuteSqlCommand("UPDATE ImgTmpDetails SET [IsMain]=1 WHERE Id=" + id);
                        tx.Complete();
                        rs = rs.T("Ok");
                    }
                }
            }
            catch (Exception ex)
            {
                rs = rs.F(ex.Message);
            }
            return Json(rs, JsonRequestBehavior.AllowGet);
        }

    }
}