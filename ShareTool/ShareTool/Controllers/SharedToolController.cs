using SharedTool.Business;
using SharedTool.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ShareTool.Controllers
{
    [HandleError]
    public class SharedToolController : Controller
    {
        // GET: Sharedtool
        public async Task<ActionResult> Index()
        {
            try
            {
                ViewBag.UserName = "نجم الدين";
                ViewData["FirstName"] = "نجم الدين";
                TempData["HeyMessage"] = "مرحبا";

                ToolRepository toolRepository = new ToolRepository();
                var tools = await toolRepository.GetAllTools();
                return View(tools);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize(Roles = "Admin")]
        //[HandleError] //Could handle errors only in this action
        public ActionResult Create() {
            var heyMessage = "";
            if (TempData.ContainsKey("HeyMessage"))
                heyMessage = TempData["HeyMessage"].ToString();

            TempData.Keep();
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include = "Name, Quantity", Exclude = "Description")] Tool sharedTool) {
            if (!ModelState.IsValid) { return View(sharedTool); }

            var toolRepository = new ToolRepository();
            await toolRepository.Add(sharedTool);

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

        [Authorize]
        public ActionResult RequestTool() {
            return Content("تم ظلب الأداة");
        }
    }
}