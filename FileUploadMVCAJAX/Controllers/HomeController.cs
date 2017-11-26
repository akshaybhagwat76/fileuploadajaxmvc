using FileUploadMVCAJAX.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileUploadMVCAJAX.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult  DatepickerCounter()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult ImageUpload(ImageModal img)
        {
            var file = img.imageFile;
            if (file!=null)
            {
                var fname = Path.GetFileName(file.FileName);
                var ext = Path.GetExtension(file.FileName);
                var without = Path.GetFileNameWithoutExtension(file.FileName);
                file.SaveAs(Server.MapPath("/imagefolder/" + file.FileName));
            }
            return Json(file.FileName, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Savefile(String Name,float Price)
        {
            var uniqueName = "";
            if (Request.Files["myFile"]!=null)
            {
                var file = Request.Files["myFile"];
                if (file.FileName!="")
                {

                    var ext = System.IO.Path.GetExtension(file.FileName);
                    uniqueName = Guid.NewGuid().ToString() + ext;
                    var rootPath = Server.MapPath("~/imagefolder/");
                    var filesave = System.IO.Path.Combine(rootPath, uniqueName);
                }
            }
            var data = new
            {
                success = false,
                name = uniqueName
            };

            return Json(data,JsonRequestBehavior.AllowGet);
        }
        public ActionResult google()
        {
            return View();
        }
        public ActionResult ddSlick()
        {
            return View();
        }
    }
}
