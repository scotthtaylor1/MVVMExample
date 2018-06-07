using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Data;
using System.ComponentModel.DataAnnotations;

namespace MVVMExample.Models
{
    public class LocationModel
    {
        public int LocationID { get; set; }
        public int CustomerID { get; set; }

        [Display(Name = "Location Name")]
        public string LocationName { get; set; }
        public string ParentLocationID { get; set; }

        [Display(Name = "Headquarters")]
        public string ParentLocationName { get; set; }
        public int SystemID { get; set; }
        public string SystemName { get; set; }

        [Display(Name = "Address")]
        public string FullAddress { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string Fax { get; set; }
        public int DoorCount { get; set; }
        public bool Deleted { get; set; }

        public List<Location> Locations { get; set; }

    }
}