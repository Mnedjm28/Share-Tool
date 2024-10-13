using ShareTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShareTool.Controllers
{
    [HandleError]
    public class SharedToolController : Controller
    {
        public List<SharedTool> sharedTools = new List<SharedTool>()
            {
                new SharedTool("غسالة","غسالة مستعملة بحالة مية بالمية",1),
                new SharedTool("دراجة","دراجة هوائية كبيرة الحجم يمكن استخدامه ",4),
                new SharedTool("تلفاز","تلفاز مكسور النصف العلوي من شاشته",2),
                new SharedTool("كمبيوتر","كمبيوتر بمعالج i5 بحالة جيدة",0),
            };
        // GET: Sharedtool
        public ActionResult Index()
        {
            ViewBag.UserName = "نجم الدين";
            ViewData["FirstName"] = "نجم الدين";
            TempData["HeyMessage"] = "مرحبا";
            return View(sharedTools);
        }

        //[HandleError] //Could handle errors only in this action
        public ActionResult Create() {
            var heyMessage = "";
            if(TempData.ContainsKey("HeyMessage"))
                heyMessage= TempData["HeyMessage"].ToString();

            TempData.Keep();
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind (Include ="Name, Quantity", Exclude ="Description")] SharedTool sharedTool) {
            if(!ModelState.IsValid) { return View(sharedTool); }
            var name = sharedTool.Name;
            var description = sharedTool.Description;
            var quantity = sharedTool.Quantity;
            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public ActionResult Create([Bind (Include ="Name, Quantity", Exclude ="Description")] FormCollection values) {
        //    if(!ModelState.IsValid) { return View(values); }
        //    var name = values[nameof(SharedTool.Name)];
        //    var description = values[nameof(SharedTool.Description)];
        //    var quantity = values[nameof(SharedTool.Quantity)];
        //    return RedirectToAction("Index");
        //}

        public ActionResult RequestTool() {
            return Content("تم ظلب الأداة");
        }
    }
}