using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeProject.Business.Entities
{
    public class CustomerManagement
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Code { get; set; }

        [Key, Column(Order = 1)]
        [StringLength(30)]
        public string CompanyCode { get; set; }

        [Key, Column(Order = 2)]
        [StringLength(30)]
        public string CustomerCode { get; set; }

        [StringLength(500)]
        public string CustomerName { get; set; }

        [StringLength(500)]
        public string LatinName { get; set; }

        [Key, Column(Order = 3)]
        [StringLength(30)]
        public string LocationCode { get; set; }

        [StringLength(500)]
        public string LocationName { get; set; }

        public string Address { get; set; }

        public string Address1 { get; set; }

        [Required]
        [StringLength(1)]
        public char CustomerType { get; set; }

        [Required]
        [StringLength(30)]
        public string CountryCode { get; set; }

        [StringLength(30)]
        public string RegionCode { get; set; }

        [StringLength(30)]
        public string ProvinceCode { get; set; }

        [StringLength(30)]
        public string DistrictCode { get; set; }

        [StringLength(30)]
        public string WardCode { get; set; }

        [StringLength(30)]
        public string Street { get; set; }

        [StringLength(30)]
        public string MobilePhone { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }

        public string Fax { get; set; }

        public string AvataFile { get; set; }

        public string IdentificationNumber { get; set; }

        public string BankName { get; set; }

        public string BankAccountNo { get; set; }

        public string BankAccountName { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        //Attribute Distributer

        [StringLength(50)]
        public string AttrCode0 { get; set; }

        [StringLength(50)]
        public string AttrCode1 { get; set; }

        [StringLength(50)]
        public string AttrCode2 { get; set; }

        [StringLength(50)]
        public string AttrCode3 { get; set; }

        [StringLength(50)]
        public string AttrCode4 { get; set; }

        [StringLength(50)]
        public string AttrCode5 { get; set; }

        [StringLength(50)]
        public string AttrCode6 { get; set; }

        [StringLength(50)]
        public string AttrCode7 { get; set; }

        [StringLength(50)]
        public string AttrCode8 { get; set; }

        [StringLength(50)]
        public string AttrCode9 { get; set; }

        [Required]
        [StringLength(50)]
        public char Status { get; set; }

        public string Approve { get; set; }

        public DateTime CreateDate { get; set; }

        public string CreateByCode { get; set; }

        public DateTime UpdateDate { get; set; }

        public string UpdateByCode { get; set; }

        public bool Active { get; set; }

    }
}
