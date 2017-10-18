using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagement.Models.GeoViewModels
{
    public class GeoViewModels
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string ParentCode { get; set; }

        public List<ProvinceMV> ListResult { get; set; }
    }

    public class RegionMV
    {

    }

    public class ProvinceMV
    {
        public string ProvinceCode { get; set; }
        
        public string ProvinceName { get; set; }

        public string RegionCode { get; set; }

        public string RegionName { get; set; }

        public DateTime UpdateDate { get; set; }

        public bool Active { get; set; }
    }
}
