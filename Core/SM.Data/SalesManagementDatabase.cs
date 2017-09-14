using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SM.Entities;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SM.Data
{
    /// <summary>
    /// SalesManagement Entity Framework Database Context
    /// </summary>
    public class SalesManagementDatabase : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Region> Regions { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Ward> Wards { get; set; }

        public DbSet<SalesTerritory> SalesTerritorys { get; set; }
        public DbSet<SalesTerrStruct> SalesTerrStructs { get; set; }
        public DbSet<SalesTerrValue> SalesTerrValues { get; set; }

        public DbSet<SalesGeoHeader> SalesGeoHeaders { get; set; }
        public DbSet<SalesGeoDetail> SalesGeoDetails { get; set; }

        public DbSet<RouteMaster> RouteMasters { get; set; }
        public DbSet<RouteSetting> RouteSettings { get; set; }
        public DbSet<RouteDetail> RouteDetails { get; set; }

        public DbSet<CustomerManagement> CustomerManagements { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }


        public SalesManagementDatabase(DbContextOptions<SalesManagementDatabase> options)
            : base(options)
        {
        }

        //public SalesManagementDatabase()
        //{
        //    //ATT: I also don't understand why ef requires the parameterless constructor
        //}

        /// <summary>
        /// Model Creation
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            //{
            //    relationship.DeleteBehavior = DeleteBehavior.Restrict;
            //}

            modelBuilder.Entity<Region>().HasKey(c => new { c.Id, c.RegionCode });
            modelBuilder.Entity<Region>().ToTable("dbo.Region");
            modelBuilder.Entity<Province>().HasKey(c => new { c.Id, c.ProvinceCode });
            modelBuilder.Entity<Province>().ToTable("dbo.Provinces");
            modelBuilder.Entity<District>().HasKey(c => new { c.Id, c.DistrictCode });
            modelBuilder.Entity<District>().ToTable("dbo.Districts");
            modelBuilder.Entity<Ward>().HasKey(c => new { c.Id, c.WardCode });
            modelBuilder.Entity<Ward>().ToTable("dbo.Wards");

            modelBuilder.Entity<SalesTerritory>().HasKey(c => new { c.Code });
            modelBuilder.Entity<SalesTerritory>().ToTable("dbo.SalesTerritorys");
            modelBuilder.Entity<SalesTerrStruct>().HasKey(c => new { c.Code, c.TerrStructCode });
            modelBuilder.Entity<SalesTerrStruct>().ToTable("dbo.SalesTerrStructs");
            modelBuilder.Entity<SalesTerrValue>().HasKey(c => new { c.Code, c.TerrCode });
            modelBuilder.Entity<SalesTerrValue>().ToTable("dbo.SalesTerrValues");

            modelBuilder.Entity<SalesGeoHeader>().HasKey(c => new { c.Code, c.SalesTerritoryCode });
            modelBuilder.Entity<SalesGeoHeader>().ToTable("dbo.SalesGeoHeaders");
            modelBuilder.Entity<SalesGeoDetail>().HasKey(c => new { c.Code, c.SalesTerritoryCode });
            modelBuilder.Entity<SalesGeoDetail>().ToTable("dbo.SalesGeoDetails");

            modelBuilder.Entity<RouteMaster>().HasKey(c => new { c.Code });
            modelBuilder.Entity<RouteMaster>().ToTable("dbo.RouteMasters");
            modelBuilder.Entity<RouteSetting>().HasKey(c => new { c.Code, c.RouteCode });
            modelBuilder.Entity<RouteSetting>().ToTable("dbo.RouteSettings");
            modelBuilder.Entity<RouteDetail>().HasKey(c => new { c.Code, c.RouteCode, c.CustomerCode, c.LocationCode });
            modelBuilder.Entity<RouteDetail>().ToTable("dbo.RouteDetails");

            modelBuilder.Entity<CustomerManagement>().HasKey(c => new { c.Code, c.CompanyCode, c.CustomerCode, c.LocationCode });
            modelBuilder.Entity<CustomerManagement>().ToTable("dbo.CustomerManagements");
            modelBuilder.Entity<Customer>().ToTable("dbo.Customers");
            modelBuilder.Entity<Product>().ToTable("dbo.Products");
        }
    }
}
