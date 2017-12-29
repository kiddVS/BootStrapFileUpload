using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootStrapFileUpload.Controllers
{
    public class UploadResult
    {
        public string FileName { get; set; }
        public string Error { get; set; }
    }
    public class UpLoadController : Controller
    {
        // GET: UpLoad
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult UploadFile()
        {
            UploadResult result = new UploadResult();
            var file = Request.Files["txt_file"];
            result.FileName = file.FileName;
            using (FileStream fs = new FileStream(@"D:/" + file.FileName, FileMode.OpenOrCreate))
            {
                var stream = file.InputStream;
                stream.CopyTo(fs);
                
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}