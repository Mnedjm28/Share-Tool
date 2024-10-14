using SharedTool.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ShareTool.Areas.Dashboard.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RequestsController : Controller
    {
        // GET: Dashboard/Requests
        public async Task<ActionResult> Index()
        {
            var borrowedRepo = new BorrowedToolRepository();
            return View(await borrowedRepo.GetAllBorrowedTools());
        }

        public async Task<ActionResult> ApproveBorrowingTool(int id)
        {
            try
            {
                var borrowedRepo = new BorrowedToolRepository();
                await borrowedRepo.ApproveBorrowTool(id);
                TempData["SuccessMessage"] = Resources.ShareToolResource.RequestToolAcceptedSuccessfuly;
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            return RedirectToAction("Index");
        }
    }
}