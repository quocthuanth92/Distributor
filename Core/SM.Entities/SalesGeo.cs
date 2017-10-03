using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Entities
{
    public class SalesGeoHeader
    {
        [Key]
        [StringLength(30)]
        public string Code { get; set; }

        public string Name { get; set; }

        [StringLength(30)]
        public string SalesTerritoryCode { get; set; }
        [StringLength(50)]
        public string SalesValueCode { get; set; }
        public char Status { get; set; }
        public string CompanyCode { get; set; }
        public string BranchCode { get; set; }

        public DateTime CreateDate { get; set; }
        public string CreateByCode { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateByCode { get; set; }
    }

    public class SalesGeoDetail
    {
        [Key]
        [StringLength(30)]
        public string Code { get; set; }

        [StringLength(30)]
        public string SalesTerritoryCode { get; set; }
        [StringLength(50)]
        public string SalesValueCode { get; set; }

        public char GeoType { get; set; }
        [StringLength(50)]
        public string GeoCode { get; set; }
        [StringLength(50)]
        public string GeoName { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime? EndDate { get; set; }
       
    }
}
