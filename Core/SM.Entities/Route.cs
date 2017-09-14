using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Entities
{
    public class RouteMaster
    {
        [Key]
        [StringLength(50)]
        public string Code { get; set; }
        public string Name { get; set; }

        [Required]
        [StringLength(30)]
        public string ChannelCode { get; set; }
        public string SalesCatCode { get; set; }

        [Required]
        [StringLength(30)]
        public string SalesTerritoryCode { get; set; }

        [Required]
        [StringLength(30)]
        public string SalesValueCode { get; set; }
        public string Principle { get; set; }
        public bool IsRouteUnderDT { get; set; }

        [Required]
        [StringLength(30)]
        public string SellingProvinceCode { get; set; }

        [Required]
        public DateTime EffectiveDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Distance { get; set; }
        public bool GPSLock { get; set; }
        public bool FullVisitOutRoute { get; set; }
        public bool GPSOutRouteLock { get; set; }
        public bool IsSundayRoute { get; set; }
        public bool IsVanSales { get; set; }
        public string BinCode { get; set; }

        public string ManageBy { get; set; }
        public string SalesMan { get; set; }
        public string OutRoute { get; set; }
        public string CheckIn { get; set; }

        public DateTime CreateDate { get; set; }
        public string CreateByCode { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateByCode { get; set; }
    }

    public class RouteSetting
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Code { get; set; }
        public string Name { get; set; }
        [Key, Column(Order = 1)]
        public string RouteCode { get; set; }

        public int Distance { get; set; }
        public bool GPSLock { get; set; }
        public bool FullVisitOutRoute { get; set; }
        public bool GPSOutRouteLock { get; set; }
        public bool IsSundayRoute { get; set; }
        public bool IsVanSales { get; set; }

        public string U_DeliverCode { get; set; }
        public string U_EffectiveDate { get; set; }
        public string U_EndDate { get; set; }
        public string U_Status { get; set; }
        public string U_SalesPersonCode { get; set; }
        public string U_Truck { get; set; }
    }

    public class RouteDetail
    {
        [Key, Column(Order = 0)]
        public int Code { get; set; }
        [Key, Column(Order = 1)]
        public string RouteCode { get; set; }
        [Key, Column(Order = 3)]
        [StringLength(50)]
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        [Key, Column(Order = 4)]
        [StringLength(50)]
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public string DistributorCode { get; set; }
        public string BranchCode { get; set; }
        public string WarehouseCode { get; set; }
        public char Type { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
        public bool Week1 { get; set; }
        public bool Week2 { get; set; }
        public bool Week3 { get; set; }
        public bool Week4 { get; set; }
        public int? VisitOrderMon { get; set; }
        public int? VisitOrderTue { get; set; }
        public int? VisitOrderWed { get; set; }
        public int? VisitOrderThu { get; set; }
        public int? VisitOrderFri { get; set; }
        public int? VisitOrderSat { get; set; }
        public int? VisitOrderSun { get; set; }
        public char Status { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
