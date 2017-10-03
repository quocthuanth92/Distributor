using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Entities
{
    public class SalesTerritory
    {
        [Key]
        [StringLength(30)]
        public string Code { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }
        [StringLength(30)]
        public string CountryCode { get; set; }
        [StringLength(250)]
        public string CountryName { get; set; }

        [Required]
        [StringLength(30)]
        public string ChannelCode { get; set; }
        [StringLength(250)]
        public string ChannelName { get; set; }
        public bool Active { get; set; }
        public char Status { get; set; }

        [Required]
        public DateTime EffectiveDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }

    public class SalesTerrStruct
    {
        [Key, Column(Order = 0)]
        [StringLength(30)]
        public string Code { get; set; }

        public string Name { get; set; }

        [Key, Column(Order = 1)]
        [Required]
        [StringLength(30)]
        public string TerrStructCode { get; set; }
        [StringLength(250)]
        public string TerrStructName { get; set; }
        [StringLength(30)]
        public string ParentCode { get; set; }
        public int Level { get; set; }
        public char Status { get; set; }
        public bool Active { get; set; }
        public bool LastLevel { get; set; }
    }

    public class SalesTerrValue
    {
        [Key, Column(Order = 0)]
        [StringLength(30)]
        public string Code { get; set; }

        public string Name { get; set; }

        [Key, Column(Order = 1)]
        [Required]
        [StringLength(30)]
        public string TerrCode { get; set; }
        [StringLength(250)]
        public string TerrName { get; set; }
        [StringLength(30)]
        public string ParentCode { get; set; }
        public int Level { get; set; }
        public char Status { get; set; }
        public bool Active { get; set; }
        public bool LastLevel { get; set; }
    }
}
