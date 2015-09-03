using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcDemo.ViewModels
{
    public class CascadingDropDownViewModel
    {
        public CascadingDropDownViewModel()
        {
            ContinentList = new List<KeyValuePair<int, string>>();
            CountryList = new List<KeyValuePair<int, string>>();
        }

        public List<KeyValuePair<int, string>> ContinentList { get; set; }

        public List<KeyValuePair<int, string>> CountryList { get; set; }

        [Required(ErrorMessage = "Please select a continent.")]
        [Display(Name = "Continent")]
        public int? ContinentId { get; set; }

        [Display(Name = "Country")]
        public int? CountryId { get; set; }
    }
}