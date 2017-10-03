using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Entities
{
    [Table("Region")]
    public class Region
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key, Column(Order = 1)]
        [StringLength(30)]
        public string RegionCode { get; set; }

        [StringLength(250)]
        public string RegionName { get; set; }

        [Required]
        [StringLength(30)]
        public string CountryCode { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        [StringLength(50)]
        public string UpdateByCode { get; set; }

        [Required]
        public bool Active { get; set; }
    }

    public class Province
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key, Column(Order = 1)]
        [StringLength(30)]
        public string ProvinceCode { get; set; }

        [StringLength(250)]
        public string ProvinceName { get; set; }

        [Required]
        [StringLength(30)]
        public string RegionCode { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        [StringLength(50)]
        public string UpdateByCode { get; set; }

        [Required]
        public bool Active { get; set; }
    }

    public class District
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key, Column(Order = 1)]
        [StringLength(30)]
        public string DistrictCode { get; set; }

        [StringLength(250)]
        public string DistrictName { get; set; }

        [Required]
        [StringLength(30)]
        public string ProvinceCode { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        [StringLength(50)]
        public string UpdateByCode { get; set; }

        [Required]
        public bool Active { get; set; }
    }

    public class Ward
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key, Column(Order = 1)]
        [StringLength(30)]
        public string WardCode { get; set; }

        [StringLength(250)]
        public string WardName { get; set; }

        [Required]
        [StringLength(30)]
        public string DistrictCode { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        [StringLength(50)]
        public string UpdateByCode { get; set; }

        [Required]
        public bool Active { get; set; }
    }
}
