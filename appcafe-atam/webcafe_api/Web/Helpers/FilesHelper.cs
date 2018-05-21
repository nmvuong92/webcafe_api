using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Hosting;
using VD.Lib;

namespace Web.Helpers
{
    public class FilesHelper
    {

        String DeleteURL = null;
        String DeleteType = null;
        String StorageRoot = null;
        String UrlBase = null;
        String tempPath = null;
        //ex:"~/Files/something/";
        String serverMapPath = null;
        public FilesHelper(String DeleteURL, String DeleteType, String StorageRoot, String UrlBase, String tempPath, String serverMapPath)
        {
            this.DeleteURL = DeleteURL;
            this.DeleteType = DeleteType;
            this.StorageRoot = StorageRoot;
            this.UrlBase = UrlBase;
            this.tempPath = tempPath;
            this.serverMapPath = serverMapPath;
        }

        public void DeleteFiles(String pathToDelete)
        {
         
            string path = HostingEnvironment.MapPath(pathToDelete);

            System.Diagnostics.Debug.WriteLine(path);
            if (Directory.Exists(path))
            {
                DirectoryInfo di = new DirectoryInfo(path);
                foreach (FileInfo fi in di.GetFiles())
                {
                    System.IO.File.Delete(fi.FullName);
                    System.Diagnostics.Debug.WriteLine(fi.Name);
                }

                di.Delete(true);
            }
        }

        public String DeleteFile(String file)
        {
            System.Diagnostics.Debug.WriteLine("DeleteFile");
            //    var req = HttpContext.Current;
            System.Diagnostics.Debug.WriteLine(file);
 
            String fullPath = Path.Combine(StorageRoot, file);
            System.Diagnostics.Debug.WriteLine(fullPath);
            System.Diagnostics.Debug.WriteLine(System.IO.File.Exists(fullPath));
            String thumbPath = "/" + file + "80x80.jpg";
            String partThumb1 = Path.Combine(StorageRoot, "thumbs");
            String partThumb2 = Path.Combine(partThumb1, file + "80x80.jpg");

            System.Diagnostics.Debug.WriteLine(partThumb2);
            System.Diagnostics.Debug.WriteLine(System.IO.File.Exists(partThumb2));
            if (System.IO.File.Exists(fullPath))
            {
                //delete thumb 
                if (System.IO.File.Exists(partThumb2))
                {
                    System.IO.File.Delete(partThumb2);
                }
                System.IO.File.Delete(fullPath);
                String succesMessage = "Ok";
                return succesMessage;
            }
            String failMessage = "Error Delete";
            return failMessage;
        }
        public JsonFiles GetFileList()
        {

            var r = new List<ViewDataUploadFilesResult>();
       
            String fullPath = Path.Combine(StorageRoot);
            if (Directory.Exists(fullPath))
            {
                DirectoryInfo dir = new DirectoryInfo(fullPath);
                foreach (FileInfo file in dir.GetFiles())
                {
                    int SizeInt = unchecked((int)file.Length);
                    r.Add(UploadResult(file.Name,SizeInt));
                }

            }
            JsonFiles files = new JsonFiles(r);

            return files;
        }

        public void UploadAndShowResults(HttpContextBase ContentBase, List<ViewDataUploadFilesResult> resultList, int thumbw, int thumbh)
        {
            var httpRequest = ContentBase.Request;
            String fullPath = Path.Combine(StorageRoot);
            Directory.CreateDirectory(fullPath);
            // Create new folder for thumbs
            Directory.CreateDirectory(fullPath + "/thumbs/");

            foreach (String inputTagName in httpRequest.Files)
            {

                var headers = httpRequest.Headers;

                var file = httpRequest.Files[inputTagName];
                System.Diagnostics.Debug.WriteLine(file.FileName);

                if (string.IsNullOrEmpty(headers["X-File-Name"]))
                {
                    UploadWholeFile(ContentBase, resultList,thumbw,thumbh);
                }
            }
        }

        public string LayNgauNhien()
        {
            return DateTime.Now.ToString("ddMMyyyyHHmmss") + "_" + myNumbers.LayMaNgauNhien10ChuSo() + "_";
        }

        private void UploadWholeFile(HttpContextBase requestContext, List<ViewDataUploadFilesResult> statuses,int thumbw,int thumbh)
        {

            var request = requestContext.Request;
            for (int i = 0; i < request.Files.Count; i++)
            {
                var file = request.Files[i];
                String pathOnServer = Path.Combine(StorageRoot);
                string _filename = LayNgauNhien() + file.FileName;
                var fullPath = Path.Combine(pathOnServer, _filename);
                file.SaveAs(fullPath);
    
              
                //Create thumb
                string[] imageArray = file.FileName.Split('.');
                string  ThumbfullPath = "";
                if (imageArray.Length != 0)
                {
                    String extansion = imageArray[imageArray.Length - 1].ToLower();
                    if (extansion != "jpg" && extansion != "png" && extansion != "jpeg") //Do not create thumb if file is not an image
                    {
                        
                    }
                    else
                    {
                        //String fileThumb = file.FileName + ".80x80.jpg";
                        ThumbfullPath = Path.Combine(Path.Combine(pathOnServer, "thumbs"), _filename);
                        myImage.ResizeAndSaveImage(Image.FromStream(file.InputStream, true, true), ThumbfullPath, thumbw, thumbh);
                    }
                }
                statuses.Add(UploadResult(_filename, file.ContentLength));
            }
        }




        public ViewDataUploadFilesResult UploadResult(String filename, int fileSize)
        {
            String getType = System.Web.MimeMapping.GetMimeMapping(filename);
            var result = new ViewDataUploadFilesResult()
            {
                name = filename,
                size = fileSize,
                type = getType,
                url = "/Files/somefiles/" + filename,
                deleteUrl = "",
                thumbnailUrl = "/Files/somefiles/thumbs/" + filename,
                deleteType = DeleteType,
            };
            return result;
        }
  
    }
    public class ViewDataUploadFilesResult
    {
        public string name { get; set; }
        public int size { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public string deleteUrl { get; set; }
        public string thumbnailUrl { get; set; }
        public string deleteType { get; set; }
    }

    public class JsonFiles
    {
        public ViewDataUploadFilesResult[] files;
        public string TempFolder { get; set; }
        public JsonFiles(List<ViewDataUploadFilesResult> filesList)
        {
            files = new ViewDataUploadFilesResult[filesList.Count];
            for (int i = 0; i < filesList.Count; i++)
            {
                files[i] = filesList.ElementAt(i);
            }

        }
    }
}

    