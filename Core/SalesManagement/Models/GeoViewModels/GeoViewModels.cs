using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagement.Models.GeoViewModels
{
    public class GeoViewModels
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string ParentCode { get; set; }

        public ProvinceMV ProvinceMV { get; set; }
        public List<ProvinceMV> ListResult { get; set; }

    }

    public class GeoCreateEditMV
    {
        public string TitleHeader { get; set; }
        public string SubmitDisplay { get; set; }
        public string FormAction { get; set; }
    }

    public class RegionMV
    {

    }

    public class ProvinceMV : GeoCreateEditMV
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string ProvinceCode { get; set; }
        
        public string ProvinceName { get; set; }

        [Required]
        public string RegionCode { get; set; }

        public string RegionName { get; set; }

        public DateTime UpdateDate { get; set; }

        public bool Active { get; set; }

        public List<SelectListItem> ListRegion { get; set; }
    }
}
