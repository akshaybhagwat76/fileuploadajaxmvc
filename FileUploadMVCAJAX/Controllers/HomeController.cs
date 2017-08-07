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

    }
}
