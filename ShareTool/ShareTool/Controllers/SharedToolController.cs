using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SharedTool.Business;
using SharedTool.DAL;
using ShareTool.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ShareTool.Controllers
{
    [HandleError]
    public class SharedToolController : Controller
    {
        private ToolRepository _toolRepository { get; set; } = new ToolRepository();
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
        [HandleError]
        public ActionResult Create()
        {
            var heyMessage = "";
            if (TempData.ContainsKey("HeyMessage"))
                heyMessage = TempData["HeyMessage"].ToString();

            TempData.Keep();
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include = "Name, Quantity", Exclude = "Description")] /*FormCollection*/ Tool sharedTool, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid) { return View(sharedTool); }

            string path = null;
            var tool = new Tool()
            {
                Name = sharedTool.Name,
                Description = sharedTool.Description,
                Quantity = sharedTool.Quantity,
            };

            if (file != null)
            {
                var imageFileName = Path.GetFileName(file.FileName);
                path = Path.Combine(Server.MapPath("~/Images"), imageFileName);
                file.SaveAs(path);
                tool.ImageUrl = "/Images/" + imageFileName;
            }
            try
            {
                await _toolRepository.Add(tool);
            }
            catch (Exception ex)
            {
                if (path != null)
                    System.IO.File.Delete(path);
                throw ex;
            }

            return RedirectToAction("Index");
        }

        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            var imageUrl = await _toolRepository.Delete(id);
            if (imageUrl != null)
            {
                imageUrl = imageUrl.Replace("/Images/", string.Empty);
                System.IO.File.Delete(Path.Combine(Server.MapPath("~/Images"), imageUrl));
            }
            return RedirectToAction("Index");
        }


        [Authorize]
        public async Task<ActionResult> RequestTool(int id)
        {
            try
            {
                var borrowRepo = new BorrowedToolRepository();
                var borrowedTool = new BorrowedTool() { UserId = User.Identity.GetUserId(), ToolId = id, Date = DateTime.Now };
                await borrowRepo.Add(borrowedTool);
                TempData["SuccessMessage"] = Resources.ShareToolResource.RequestToolSuccessfuly;
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            return RedirectToAction("Index");
        }
    }
}