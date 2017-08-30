using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeProject.Business.Entities;
using System.Data.Entity;

namespace CodeProject.Data.EntityFramework
{
    /// <summary>
    /// CodeProject Entity Framework Database Context
    /// </summary>
    public class CodeProjectDatabase : DbContext
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
      




        /// <summary>
        /// Model Creation
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Region>().ToTable("dbo.Regions");
            modelBuilder.Entity<Province>().ToTable("dbo.Provinces");
            modelBuilder.Entity<District>().ToTable("dbo.Districts");
            modelBuilder.Entity<Ward>().ToTable("dbo.Wards");
            
            modelBuilder.Entity<SalesTerritory>().ToTable("dbo.SalesTerritorys");
            modelBuilder.Entity<SalesTerrStruct>().ToTable("dbo.SalesTerrStructs");
            modelBuilder.Entity<SalesTerrValue>().ToTable("dbo.SalesTerrValues");

            modelBuilder.Entity<SalesGeoHeader>().ToTable("dbo.SalesGeoHeaders");
            modelBuilder.Entity<SalesGeoDetail>().ToTable("dbo.SalesGeoDetails");

            modelBuilder.Entity<RouteMaster>().ToTable("dbo.RouteMasters");
            modelBuilder.Entity<RouteSetting>().ToTable("dbo.RouteSettings");
            modelBuilder.Entity<RouteDetail>().ToTable("dbo.RouteDetails");

            modelBuilder.Entity<CustomerManagement>().ToTable("dbo.CustomerManagements");
            modelBuilder.Entity<Customer>().ToTable("dbo.Customers");
            modelBuilder.Entity<Product>().ToTable("dbo.Products");
         


        }
    }
}
