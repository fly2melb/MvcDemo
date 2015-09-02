using MvcDemo.Helpers;
using System.Web.Mvc;

namespace MvcDemo.Controllers
{
    public class DemoController : Controller
    {
        #region "Two submit buttons"

        public ViewResult TwoSubmitButtons()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        [ActionName("TwoSubmitButtons"), AcceptButtonName(Name = "Accept")]
        public ViewResult Accept(string message)
        {
            ViewBag.Response = "Accepted";

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        [ActionName("TwoSubmitButtons"), AcceptButtonName(Name = "Decline")]
        public ViewResult Decline(string message)
        {
            ViewBag.Response = "Declined";

            return View();
        }

        #endregion // Two submit buttons
    }
}