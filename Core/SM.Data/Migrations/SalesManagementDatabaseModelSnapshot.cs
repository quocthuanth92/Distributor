using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SM.Data;

namespace SM.Data.Migrations
{
    [DbContext(typeof(SalesManagementDatabase))]
    partial class SalesManagementDatabaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SM.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("SM.Entities.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("CompanyName");

                    b.Property<string>("ContactName");

                    b.Property<string>("ContactTitle");

                    b.Property<string>("Country");

                    b.Property<string>("CustomerCode");

                    b.Property<string>("MobileNumber");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("PostalCode");

                    b.Property<string>("Region");

                    b.HasKey("CustomerID");

                    b.ToTable("dbo.Customers");
                });

            modelBuilder.Entity("SM.Entities.CustomerManagement", b =>
                {
                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyCode")
                        .HasMaxLength(30);

                    b.Property<string>("CustomerCode")
                        .HasMaxLength(30);

                    b.Property<string>("LocationCode")
                        .HasMaxLength(30);

                    b.Property<bool>("Active");

                    b.Property<string>("Address");

                    b.Property<string>("Address1");

                    b.Property<string>("Approve");

                    b.Property<string>("AttrCode0")
                        .HasMaxLength(50);

                    b.Property<string>("AttrCode1")
                        .HasMaxLength(50);

                    b.Property<string>("AttrCode2")
                        .HasMaxLength(50);

                    b.Property<string>("AttrCode3")
                        .HasMaxLength(50);

                    b.Property<string>("AttrCode4")
                        .HasMaxLength(50);

                    b.Property<string>("AttrCode5")
                        .HasMaxLength(50);

                    b.Property<string>("AttrCode6")
                        .HasMaxLength(50);

                    b.Property<string>("AttrCode7")
                        .HasMaxLength(50);

                    b.Property<string>("AttrCode8")
                        .HasMaxLength(50);

                    b.Property<string>("AttrCode9")
                        .HasMaxLength(50);

                    b.Property<string>("AvataFile");

                    b.Property<string>("BankAccountName");

                    b.Property<string>("BankAccountNo");

                    b.Property<string>("BankName");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("CreateByCode");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CustomerName")
                        .HasMaxLength(500);

                    b.Property<char>("CustomerType")
                        .HasMaxLength(1);

                    b.Property<string>("DistrictCode")
                        .HasMaxLength(30);

                    b.Property<string>("Email");

                    b.Property<string>("Fax");

                    b.Property<string>("IdentificationNumber");

                    b.Property<string>("LatinName")
                        .HasMaxLength(500);

                    b.Property<decimal>("Latitude");

                    b.Property<string>("LocationName")
                        .HasMaxLength(500);

                    b.Property<decimal>("Longitude");

                    b.Property<string>("MobilePhone")
                        .HasMaxLength(30);

                    b.Property<string>("ProvinceCode")
                        .HasMaxLength(30);

                    b.Property<string>("RegionCode")
                        .HasMaxLength(30);

                    b.Property<char>("Status")
                        .HasMaxLength(50);

                    b.Property<string>("Street")
                        .HasMaxLength(30);

                    b.Property<string>("UpdateByCode");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("WardCode")
                        .HasMaxLength(30);

                    b.HasKey("Code", "CompanyCode", "CustomerCode", "LocationCode");

                    b.ToTable("dbo.CustomerManagements");
                });

            modelBuilder.Entity("SM.Entities.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DistrictCode")
                        .HasMaxLength(30);

                    b.Property<bool>("Active");

                    b.Property<string>("CreateDate");

                    b.Property<string>("DistrictName");

                    b.Property<string>("ProvinceCode")
                        .IsRequired();

                    b.Property<string>("UpdateByCode");

                    b.Property<string>("UpdateDate");

                    b.HasKey("Id", "DistrictCode");

                    b.HasAlternateKey("DistrictCode", "Id");

                    b.ToTable("dbo.Districts");
                });

            modelBuilder.Entity("SM.Entities.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ProductName");

                    b.Property<string>("QuantityPerUnit");

                    b.Property<decimal>("UnitPrice");

                    b.HasKey("ProductID");

                    b.ToTable("dbo.Products");
                });

            modelBuilder.Entity("SM.Entities.Province", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ProvinceCode")
                        .HasMaxLength(30);

                    b.Property<bool>("Active");

                    b.Property<string>("CreateDate");

                    b.Property<string>("ProvinceName");

                    b.Property<string>("RegionCode")
                        .IsRequired();

                    b.Property<string>("UpdateByCode");

                    b.Property<string>("UpdateDate");

                    b.HasKey("Id", "ProvinceCode");

                    b.ToTable("dbo.Provinces");
                });

            modelBuilder.Entity("SM.Entities.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RegionCode")
                        .HasMaxLength(30);

                    b.Property<bool>("Active");

                    b.Property<string>("CountryCode")
                        .IsRequired();

                    b.Property<string>("CreateDate");

                    b.Property<string>("RegionName");

                    b.Property<string>("UpdateByCode");

                    b.Property<string>("UpdateDate");

                    b.HasKey("Id", "RegionCode");

                    b.ToTable("dbo.Region");
                });

            modelBuilder.Entity("SM.Entities.RouteDetail", b =>
                {
                    b.Property<int>("Code");

                    b.Property<string>("RouteCode");

                    b.Property<string>("CustomerCode")
                        .HasMaxLength(50);

                    b.Property<string>("LocationCode")
                        .HasMaxLength(50);

                    b.Property<string>("BranchCode");

                    b.Property<string>("CustomerName");

                    b.Property<string>("DistributorCode");

                    b.Property<DateTime>("EffectiveDate");

                    b.Property<DateTime?>("EndDate");

                    b.Property<bool>("Friday");

                    b.Property<string>("LocationName");

                    b.Property<bool>("Monday");

                    b.Property<bool>("Saturday");

                    b.Property<char>("Status");

                    b.Property<bool>("Sunday");

                    b.Property<bool>("Thursday");

                    b.Property<bool>("Tuesday");

                    b.Property<char>("Type");

                    b.Property<int?>("VisitOrderFri");

                    b.Property<int?>("VisitOrderMon");

                    b.Property<int?>("VisitOrderSat");

                    b.Property<int?>("VisitOrderSun");

                    b.Property<int?>("VisitOrderThu");

                    b.Property<int?>("VisitOrderTue");

                    b.Property<int?>("VisitOrderWed");

                    b.Property<string>("WarehouseCode");

                    b.Property<bool>("Wednesday");

                    b.Property<bool>("Week1");

                    b.Property<bool>("Week2");

                    b.Property<bool>("Week3");

                    b.Property<bool>("Week4");

                    b.HasKey("Code", "RouteCode", "CustomerCode", "LocationCode");

                    b.HasAlternateKey("Code", "CustomerCode", "LocationCode", "RouteCode");

                    b.ToTable("dbo.RouteDetails");
                });

            modelBuilder.Entity("SM.Entities.RouteMaster", b =>
                {
                    b.Property<string>("Code")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<string>("BinCode");

                    b.Property<string>("ChannelCode")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("CheckIn");

                    b.Property<string>("CreateByCode");

                    b.Property<DateTime>("CreateDate");

                    b.Property<int>("Distance");

                    b.Property<DateTime>("EffectiveDate");

                    b.Property<DateTime?>("EndDate");

                    b.Property<bool>("FullVisitOutRoute");

                    b.Property<bool>("GPSLock");

                    b.Property<bool>("GPSOutRouteLock");

                    b.Property<bool>("IsRouteUnderDT");

                    b.Property<bool>("IsSundayRoute");

                    b.Property<bool>("IsVanSales");

                    b.Property<string>("ManageBy");

                    b.Property<string>("Name");

                    b.Property<string>("OutRoute");

                    b.Property<string>("Principle");

                    b.Property<string>("SalesCatCode");

                    b.Property<string>("SalesMan");

                    b.Property<string>("SalesTerritoryCode")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("SalesValueCode")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("SellingProvinceCode")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("UpdateByCode");

                    b.Property<DateTime>("UpdateDate");

                    b.HasKey("Code");

                    b.ToTable("dbo.RouteMasters");
                });

            modelBuilder.Entity("SM.Entities.RouteSetting", b =>
                {
                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RouteCode");

                    b.Property<int>("Distance");

                    b.Property<bool>("FullVisitOutRoute");

                    b.Property<bool>("GPSLock");

                    b.Property<bool>("GPSOutRouteLock");

                    b.Property<bool>("IsSundayRoute");

                    b.Property<bool>("IsVanSales");

                    b.Property<string>("Name");

                    b.Property<string>("U_DeliverCode");

                    b.Property<string>("U_EffectiveDate");

                    b.Property<string>("U_EndDate");

                    b.Property<string>("U_SalesPersonCode");

                    b.Property<string>("U_Status");

                    b.Property<string>("U_Truck");

                    b.HasKey("Code", "RouteCode");

                    b.ToTable("dbo.RouteSettings");
                });

            modelBuilder.Entity("SM.Entities.SalesGeoDetail", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(30);

                    b.Property<string>("SalesTerritoryCode")
                        .HasMaxLength(30);

                    b.Property<DateTime>("EffectiveDate");

                    b.Property<DateTime?>("EndDate");

                    b.Property<string>("GeoCode");

                    b.Property<string>("GeoName");

                    b.Property<char>("GeoType");

                    b.Property<string>("SalesValueCode");

                    b.HasKey("Code", "SalesTerritoryCode");

                    b.HasAlternateKey("Code");

                    b.ToTable("dbo.SalesGeoDetails");
                });

            modelBuilder.Entity("SM.Entities.SalesGeoHeader", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(30);

                    b.Property<string>("SalesTerritoryCode")
                        .HasMaxLength(30);

                    b.Property<string>("BranchCode");

                    b.Property<string>("CompanyCode");

                    b.Property<string>("CreateByCode");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Name");

                    b.Property<string>("SalesValueCode");

                    b.Property<char>("Status");

                    b.Property<string>("UpdateByCode");

                    b.Property<DateTime>("UpdateDate");

                    b.HasKey("Code", "SalesTerritoryCode");

                    b.HasAlternateKey("Code");

                    b.ToTable("dbo.SalesGeoHeaders");
                });

            modelBuilder.Entity("SM.Entities.SalesTerritory", b =>
                {
                    b.Property<string>("Code")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(30);

                    b.Property<bool>("Active");

                    b.Property<string>("ChannelCode")
                        .IsRequired();

                    b.Property<string>("ChannelName");

                    b.Property<string>("CountryCode");

                    b.Property<string>("CountryName");

                    b.Property<DateTime>("CreateDate");

                    b.Property<DateTime>("EffectiveDate");

                    b.Property<DateTime?>("EndDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<char>("Status");

                    b.Property<DateTime>("UpdateDate");

                    b.HasKey("Code");

                    b.ToTable("dbo.SalesTerritorys");
                });

            modelBuilder.Entity("SM.Entities.SalesTerrStruct", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(30);

                    b.Property<string>("TerrStructCode");

                    b.Property<bool>("Active");

                    b.Property<bool>("LastLevel");

                    b.Property<int>("Level");

                    b.Property<string>("Name");

                    b.Property<string>("ParentCode");

                    b.Property<char>("Status");

                    b.Property<string>("TerrStructName");

                    b.HasKey("Code", "TerrStructCode");

                    b.ToTable("dbo.SalesTerrStructs");
                });

            modelBuilder.Entity("SM.Entities.SalesTerrValue", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(30);

                    b.Property<string>("TerrCode");

                    b.Property<bool>("Active");

                    b.Property<bool>("LastLevel");

                    b.Property<int>("Level");

                    b.Property<string>("Name");

                    b.Property<string>("ParentCode");

                    b.Property<char>("Status");

                    b.Property<string>("TerrName");

                    b.HasKey("Code", "TerrCode");

                    b.ToTable("dbo.SalesTerrValues");
                });

            modelBuilder.Entity("SM.Entities.Ward", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("WardCode")
                        .HasMaxLength(30);

                    b.Property<bool>("Active");

                    b.Property<string>("CreateDate");

                    b.Property<string>("DistrictCode")
                        .IsRequired();

                    b.Property<string>("UpdateByCode");

                    b.Property<string>("UpdateDate");

                    b.Property<string>("WardName");

                    b.HasKey("Id", "WardCode");

                    b.ToTable("dbo.Wards");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SM.Data.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SM.Data.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SM.Data.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
