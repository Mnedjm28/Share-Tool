using ShareTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShareTool.Controllers
{
    public class SharedToolController : Controller
    {
        // GET: Sharedtool
        public ActionResult Index()
        {
            return View(new List<SharedTool>()
            {
                new SharedTool("غسالة","غسالة مستعملة بحالة مية بالمية",1),
                new SharedTool("دراجة","دراجة هوائية كبيرة الحجم يمكن استخدامه ",4),
                new SharedTool("تلفاز","تلفاز مكسور النصف العلوي من شاشته",2),
                new SharedTool("كمبيوتر","كمبيوتر بمعالج i5 بحالة جيدة",2),
            });
        }
    }
}