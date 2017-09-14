using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SM.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbo.Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    ContactName = table.Column<string>(nullable: true),
                    ContactTitle = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    CustomerCode = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "dbo.CustomerManagements",
                columns: table => new
                {
                    Code = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyCode = table.Column<string>(maxLength: 30, nullable: false),
                    CustomerCode = table.Column<string>(maxLength: 30, nullable: false),
                    LocationCode = table.Column<string>(maxLength: 30, nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Address1 = table.Column<string>(nullable: true),
                    Approve = table.Column<string>(nullable: true),
                    AttrCode0 = table.Column<string>(maxLength: 50, nullable: true),
                    AttrCode1 = table.Column<string>(maxLength: 50, nullable: true),
                    AttrCode2 = table.Column<string>(maxLength: 50, nullable: true),
                    AttrCode3 = table.Column<string>(maxLength: 50, nullable: true),
                    AttrCode4 = table.Column<string>(maxLength: 50, nullable: true),
                    AttrCode5 = table.Column<string>(maxLength: 50, nullable: true),
                    AttrCode6 = table.Column<string>(maxLength: 50, nullable: true),
                    AttrCode7 = table.Column<string>(maxLength: 50, nullable: true),
                    AttrCode8 = table.Column<string>(maxLength: 50, nullable: true),
                    AttrCode9 = table.Column<string>(maxLength: 50, nullable: true),
                    AvataFile = table.Column<string>(nullable: true),
                    BankAccountName = table.Column<string>(nullable: true),
                    BankAccountNo = table.Column<string>(nullable: true),
                    BankName = table.Column<string>(nullable: true),
                    CountryCode = table.Column<string>(maxLength: 30, nullable: false),
                    CreateByCode = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CustomerName = table.Column<string>(maxLength: 500, nullable: true),
                    CustomerType = table.Column<char>(maxLength: 1, nullable: false),
                    DistrictCode = table.Column<string>(maxLength: 30, nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    IdentificationNumber = table.Column<string>(nullable: true),
                    LatinName = table.Column<string>(maxLength: 500, nullable: true),
                    Latitude = table.Column<decimal>(nullable: false),
                    LocationName = table.Column<string>(maxLength: 500, nullable: true),
                    Longitude = table.Column<decimal>(nullable: false),
                    MobilePhone = table.Column<string>(maxLength: 30, nullable: true),
                    ProvinceCode = table.Column<string>(maxLength: 30, nullable: true),
                    RegionCode = table.Column<string>(maxLength: 30, nullable: true),
                    Status = table.Column<char>(maxLength: 50, nullable: false),
                    Street = table.Column<string>(maxLength: 30, nullable: true),
                    UpdateByCode = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    WardCode = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.CustomerManagements", x => new { x.Code, x.CompanyCode, x.CustomerCode, x.LocationCode });
                });

            migrationBuilder.CreateTable(
                name: "dbo.Districts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DistrictCode = table.Column<string>(maxLength: 30, nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<string>(nullable: true),
                    DistrictName = table.Column<string>(nullable: true),
                    ProvinceCode = table.Column<string>(nullable: false),
                    UpdateByCode = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Districts", x => new { x.Id, x.DistrictCode });
                    table.UniqueConstraint("AK_dbo.Districts_DistrictCode_Id", x => new { x.DistrictCode, x.Id });
                });

            migrationBuilder.CreateTable(
                name: "dbo.Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductName = table.Column<string>(nullable: true),
                    QuantityPerUnit = table.Column<string>(nullable: true),
                    UnitPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Products", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "dbo.Provinces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProvinceCode = table.Column<string>(maxLength: 30, nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<string>(nullable: true),
                    ProvinceName = table.Column<string>(nullable: true),
                    RegionCode = table.Column<string>(nullable: false),
                    UpdateByCode = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Provinces", x => new { x.Id, x.ProvinceCode });
                });

            migrationBuilder.CreateTable(
                name: "dbo.Region",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegionCode = table.Column<string>(maxLength: 30, nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CountryCode = table.Column<string>(nullable: false),
                    CreateDate = table.Column<string>(nullable: true),
                    RegionName = table.Column<string>(nullable: true),
                    UpdateByCode = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Region", x => new { x.Id, x.RegionCode });
                });

            migrationBuilder.CreateTable(
                name: "dbo.RouteDetails",
                columns: table => new
                {
                    Code = table.Column<int>(nullable: false),
                    RouteCode = table.Column<string>(nullable: false),
                    CustomerCode = table.Column<string>(maxLength: 50, nullable: false),
                    LocationCode = table.Column<string>(maxLength: 50, nullable: false),
                    BranchCode = table.Column<string>(nullable: true),
                    CustomerName = table.Column<string>(nullable: true),
                    DistributorCode = table.Column<string>(nullable: true),
                    EffectiveDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    Friday = table.Column<bool>(nullable: false),
                    LocationName = table.Column<string>(nullable: true),
                    Monday = table.Column<bool>(nullable: false),
                    Saturday = table.Column<bool>(nullable: false),
                    Status = table.Column<char>(nullable: false),
                    Sunday = table.Column<bool>(nullable: false),
                    Thursday = table.Column<bool>(nullable: false),
                    Tuesday = table.Column<bool>(nullable: false),
                    Type = table.Column<char>(nullable: false),
                    VisitOrderFri = table.Column<int>(nullable: true),
                    VisitOrderMon = table.Column<int>(nullable: true),
                    VisitOrderSat = table.Column<int>(nullable: true),
                    VisitOrderSun = table.Column<int>(nullable: true),
                    VisitOrderThu = table.Column<int>(nullable: true),
                    VisitOrderTue = table.Column<int>(nullable: true),
                    VisitOrderWed = table.Column<int>(nullable: true),
                    WarehouseCode = table.Column<string>(nullable: true),
                    Wednesday = table.Column<bool>(nullable: false),
                    Week1 = table.Column<bool>(nullable: false),
                    Week2 = table.Column<bool>(nullable: false),
                    Week3 = table.Column<bool>(nullable: false),
                    Week4 = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.RouteDetails", x => new { x.Code, x.RouteCode, x.CustomerCode, x.LocationCode });
                    table.UniqueConstraint("AK_dbo.RouteDetails_Code_CustomerCode_LocationCode_RouteCode", x => new { x.Code, x.CustomerCode, x.LocationCode, x.RouteCode });
                });

            migrationBuilder.CreateTable(
                name: "dbo.RouteMasters",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    BinCode = table.Column<string>(nullable: true),
                    ChannelCode = table.Column<string>(maxLength: 30, nullable: false),
                    CheckIn = table.Column<string>(nullable: true),
                    CreateByCode = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Distance = table.Column<int>(nullable: false),
                    EffectiveDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    FullVisitOutRoute = table.Column<bool>(nullable: false),
                    GPSLock = table.Column<bool>(nullable: false),
                    GPSOutRouteLock = table.Column<bool>(nullable: false),
                    IsRouteUnderDT = table.Column<bool>(nullable: false),
                    IsSundayRoute = table.Column<bool>(nullable: false),
                    IsVanSales = table.Column<bool>(nullable: false),
                    ManageBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    OutRoute = table.Column<string>(nullable: true),
                    Principle = table.Column<string>(nullable: true),
                    SalesCatCode = table.Column<string>(nullable: true),
                    SalesMan = table.Column<string>(nullable: true),
                    SalesTerritoryCode = table.Column<string>(maxLength: 30, nullable: false),
                    SalesValueCode = table.Column<string>(maxLength: 30, nullable: false),
                    SellingProvinceCode = table.Column<string>(maxLength: 30, nullable: false),
                    UpdateByCode = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.RouteMasters", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "dbo.RouteSettings",
                columns: table => new
                {
                    Code = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RouteCode = table.Column<string>(nullable: false),
                    Distance = table.Column<int>(nullable: false),
                    FullVisitOutRoute = table.Column<bool>(nullable: false),
                    GPSLock = table.Column<bool>(nullable: false),
                    GPSOutRouteLock = table.Column<bool>(nullable: false),
                    IsSundayRoute = table.Column<bool>(nullable: false),
                    IsVanSales = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    U_DeliverCode = table.Column<string>(nullable: true),
                    U_EffectiveDate = table.Column<string>(nullable: true),
                    U_EndDate = table.Column<string>(nullable: true),
                    U_SalesPersonCode = table.Column<string>(nullable: true),
                    U_Status = table.Column<string>(nullable: true),
                    U_Truck = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.RouteSettings", x => new { x.Code, x.RouteCode });
                });

            migrationBuilder.CreateTable(
                name: "dbo.SalesGeoDetails",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 30, nullable: false),
                    SalesTerritoryCode = table.Column<string>(maxLength: 30, nullable: false),
                    EffectiveDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    GeoCode = table.Column<string>(nullable: true),
                    GeoName = table.Column<string>(nullable: true),
                    GeoType = table.Column<char>(nullable: false),
                    SalesValueCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.SalesGeoDetails", x => new { x.Code, x.SalesTerritoryCode });
                    table.UniqueConstraint("AK_dbo.SalesGeoDetails_Code", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "dbo.SalesGeoHeaders",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 30, nullable: false),
                    SalesTerritoryCode = table.Column<string>(maxLength: 30, nullable: false),
                    BranchCode = table.Column<string>(nullable: true),
                    CompanyCode = table.Column<string>(nullable: true),
                    CreateByCode = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SalesValueCode = table.Column<string>(nullable: true),
                    Status = table.Column<char>(nullable: false),
                    UpdateByCode = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.SalesGeoHeaders", x => new { x.Code, x.SalesTerritoryCode });
                    table.UniqueConstraint("AK_dbo.SalesGeoHeaders_Code", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "dbo.SalesTerritorys",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 30, nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    ChannelCode = table.Column<string>(nullable: false),
                    ChannelName = table.Column<string>(nullable: true),
                    CountryCode = table.Column<string>(nullable: true),
                    CountryName = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    EffectiveDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Status = table.Column<char>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.SalesTerritorys", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "dbo.SalesTerrStructs",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 30, nullable: false),
                    TerrStructCode = table.Column<string>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    LastLevel = table.Column<bool>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ParentCode = table.Column<string>(nullable: true),
                    Status = table.Column<char>(nullable: false),
                    TerrStructName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.SalesTerrStructs", x => new { x.Code, x.TerrStructCode });
                });

            migrationBuilder.CreateTable(
                name: "dbo.SalesTerrValues",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 30, nullable: false),
                    TerrCode = table.Column<string>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    LastLevel = table.Column<bool>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ParentCode = table.Column<string>(nullable: true),
                    Status = table.Column<char>(nullable: false),
                    TerrName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.SalesTerrValues", x => new { x.Code, x.TerrCode });
                });

            migrationBuilder.CreateTable(
                name: "dbo.Wards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WardCode = table.Column<string>(maxLength: 30, nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<string>(nullable: true),
                    DistrictCode = table.Column<string>(nullable: false),
                    UpdateByCode = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<string>(nullable: true),
                    WardName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Wards", x => new { x.Id, x.WardCode });
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "dbo.Customers");

            migrationBuilder.DropTable(
                name: "dbo.CustomerManagements");

            migrationBuilder.DropTable(
                name: "dbo.Districts");

            migrationBuilder.DropTable(
                name: "dbo.Products");

            migrationBuilder.DropTable(
                name: "dbo.Provinces");

            migrationBuilder.DropTable(
                name: "dbo.Region");

            migrationBuilder.DropTable(
                name: "dbo.RouteDetails");

            migrationBuilder.DropTable(
                name: "dbo.RouteMasters");

            migrationBuilder.DropTable(
                name: "dbo.RouteSettings");

            migrationBuilder.DropTable(
                name: "dbo.SalesGeoDetails");

            migrationBuilder.DropTable(
                name: "dbo.SalesGeoHeaders");

            migrationBuilder.DropTable(
                name: "dbo.SalesTerritorys");

            migrationBuilder.DropTable(
                name: "dbo.SalesTerrStructs");

            migrationBuilder.DropTable(
                name: "dbo.SalesTerrValues");

            migrationBuilder.DropTable(
                name: "dbo.Wards");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
