using MvcDemo.Helpers;
using MvcDemo.ViewModels;
using System;
using System.Collections.Generic;
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

        #region "Cascading drop-down list"

        public ViewResult CascadingDropDown()
        {
            var viewModel = new CascadingDropDownViewModel();
            viewModel.ContinentList = GetContinents();

            return View(viewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ViewResult CascadingDropDown(CascadingDropDownViewModel viewModel)
        {
            if (viewModel.ContinentId != (int)Continent.Antarctica && viewModel.CountryId == null)
            {
                ModelState.AddModelError("CountryId", "Please select a country.");
            }

            if (ModelState.IsValid)
            {
                ViewBag.Message = "Selected";
            }

            viewModel.ContinentList = GetContinents();
            viewModel.CountryList = GetCountries(viewModel.ContinentId);

            return View(viewModel);
        }

        public JsonResult Countries(int? id)
        {
            if (HttpContext.Request.IsAjaxRequest())
            {
                return Json(new SelectList(GetCountries(id), "Key", "Value"), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new object { });
            }
        }

        private enum Continent
        {
            Africa = 1,
            Antarctica = 2,
            Asia = 3,
            Europe = 4,
            NorthAmerica = 5,
            Oceania = 6,
            SouthAmerica = 7
        }

        /// <summary>
        /// Gets list of continents.
        /// </summary>
        /// <returns></returns>
        private List<KeyValuePair<int, string>> GetContinents()
        {
            var list = new List<KeyValuePair<int, string>>();

            foreach (var value in Enum.GetValues(typeof(Continent)))
            {
                list.Add(new KeyValuePair<int, string>((int)value, value.ToString()));
            }

            return list;
        }

        /// <summary>
        /// Gets list of countries with specified continent ID.
        /// </summary>
        /// <param name="id">Continent ID.</param>
        /// <returns></returns>
        private List<KeyValuePair<int, string>> GetCountries(int? id)
        {
            var list = new List<KeyValuePair<int, string>>();

            if (id == (int)Continent.Africa)
            {
                list.Add(new KeyValuePair<int, string>(1, "Algeria"));
                list.Add(new KeyValuePair<int, string>(2, "Angola"));
            }
            else if (id == (int)Continent.Asia)
            {
                list.Add(new KeyValuePair<int, string>(3, "Afghanistan"));
            }
            else if (id == (int)Continent.Europe)
            {
                list.Add(new KeyValuePair<int, string>(4, "Albania"));
                list.Add(new KeyValuePair<int, string>(5, "Andorra"));
                list.Add(new KeyValuePair<int, string>(6, "Austria"));
            }
            else if (id == (int)Continent.NorthAmerica)
            {
                list.Add(new KeyValuePair<int, string>(7, "Antigua and Barbuda"));
            }
            else if (id == (int)Continent.Oceania)
            {
                list.Add(new KeyValuePair<int, string>(8, "Australia"));
            }
            else if (id == (int)Continent.SouthAmerica)
            {
                list.Add(new KeyValuePair<int, string>(9, "Argentina"));
            }

            return list;
        }

        #endregion // Cascading drop-down list
    }
}