using Microsoft.AspNetCore.Mvc.Rendering;

namespace WorldClockApp.Models
{
    public class FormModel
    {
        public string message { get; set; }
        public string CityName { get; set; }
        public string ContinentName { get; set; }
        public string abbreviation { get; set; }
        public string client_ip { get; set; }
        public bool? Dst { get; set; }
        public string DstFrom { get; set; }
        public string DstUntil { get; set; }
        public string timezone { get; set; }
        public long? Unixtime { get; set; }
        public string Utc_Datetime { get; set; }
        public string Datetime { get; set; }

        public List<SelectListItem> ContinentList { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "", Text = "Select a Continent" },
            new SelectListItem { Value = "America", Text = "America" },
            new SelectListItem { Value = "Europe", Text = "Europe" },
            new SelectListItem { Value = "Australia", Text = "Australia"  },
            new SelectListItem { Value = "Asia", Text = "Asia"  },
            new SelectListItem { Value = "Oceania", Text = "Oceania"  },
            new SelectListItem { Value = "Africa", Text = "Africa"  },
            new SelectListItem { Value = "Antartica", Text = "Antartica"  },
            new SelectListItem { Value = "Pacific", Text = "Pacific"  },
            new SelectListItem { Value = "Indian", Text = "Indian"  },
            new SelectListItem { Value = "Antarctica", Text = "Antarctica"  },
        };
    }
}