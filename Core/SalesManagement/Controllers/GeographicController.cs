using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SM.Common;
using Microsoft.Extensions.Localization;
using SM.Resources;
using SM.Common.ViewModel;
using System.IO;
using OfficeOpenXml;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using SM.Entities;
using SM.Data.DataServices;
using SM.Interfaces;
using SM.Data;
using SalesManagement.Models.GeoViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SalesManagement.Controllers
{
    public class GeographicController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly SalesManagementDatabase _salesManagementDatabase;

        public GeographicController(IHostingEnvironment hostingEnvironment, SalesManagementDatabase salesManagementDatabase)
        { 
            _hostingEnvironment = hostingEnvironment;
            _salesManagementDatabase = salesManagementDatabase;
        }

        #region Region Management
        // GET: Geographic
        [HttpGet, ResponseCache(Duration = 300, Location = ResponseCacheLocation.Any)]
        public ActionResult Region()
        {
            ViewBag.Time = DateTime.Now.ToString();
            _salesManagementDatabase.Provinces.ToList();
            ViewBag.abc = Resource.Name;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ImportRegion(ImportExportMV importMV)
        {
            var fileUpload = new FileInfo(importMV.Attachment.FileName);
            var fileExtension = fileUpload.Extension;
            //Check if file is an Excel File
            if (fileExtension.Contains(".xls") || fileExtension.Contains(".xlsx"))
            {
                try
                {
                    List<Province> listProvinces = new List<Province>();
                    using (ExcelPackage excelPackage = new ExcelPackage(importMV.Attachment.OpenReadStream()))
                    {
                        StringBuilder sb = new StringBuilder();
                        ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.FirstOrDefault();
                        int rowCount = worksheet.Dimension.Rows;
                        int ColCount = worksheet.Dimension.Columns;
                        bool bHeaderRow = true;
                        for (int row = 2; row <= rowCount; row++)
                        {
                            Province province = new Province()
                            {
                                ProvinceCode = worksheet.Cells[row, 1].Value.ToString(),
                                ProvinceName = worksheet.Cells[row, 2].Value.ToString(),
                                RegionCode = worksheet.Cells[row, 1].Value.ToString(),
                                CreateDate = DateTime.Now,
                                UpdateDate = DateTime.Now,
                                Active = true,
                                UpdateByCode = "System"
                            };
                            listProvinces.Add(province);
                        }
                    }

                    if (listProvinces.Count > 0)
                    {
                        //_provinceDataService.CreateSession();
                        //foreach(Province elm in listProvinces)
                        //{
                        //    var abc = _provinceDataService.Create(elm);
                        //}

                        //_provinceDataService.CommitTransaction(true);
                    }
                }
                catch (Exception ex)
                {
                    CustomLog.LogError(ex);
                    Console.WriteLine("Some error occured while importing." + ex.Message);
                }
            }
            // full path to file in temp location
            Console.WriteLine(importMV.OptionImport.ToString());
            return RedirectToAction("Region");
        }
        #endregion

        #region Province Management
        // GET: Province
        [HttpGet, ResponseCache(CacheProfileName = "Cache1Hour")]
        public ActionResult Province()
        {
            ViewBag.Time = DateTime.Now.ToString();
            GeoViewModels geoViewModels = new GeoViewModels();
            geoViewModels.ProvinceMV = new ProvinceMV()
            {
                TitleHeader = Resource.TitleAdd,
                FormAction = "CreateProvince",
                SubmitDisplay = Resource.Register,
                ListRegion = _salesManagementDatabase.Regions.Select(s => new SelectListItem()
                {
                    Value = s.RegionCode,
                    Text = s.RegionName
                }).ToList()
            };


            geoViewModels.ListResult = (from p in _salesManagementDatabase.Provinces
                                        join r in _salesManagementDatabase.Regions
                                        on p.RegionCode equals r.RegionCode into joined
                                        from j in joined.DefaultIfEmpty()
                                        select new ProvinceMV()
                                        {
                                            Id = p.Id,
                                            ProvinceCode = p.ProvinceCode,
                                            ProvinceName = p.ProvinceName,
                                            RegionName = j.RegionName,
                                            Active = p.Active,
                                            UpdateDate = p.UpdateDate
                                        }).ToList();
            return View(geoViewModels);
        }

        // GET: Geographic/CreateProvince
        [HttpGet]
        public ActionResult CreateProvince()
        {
            ProvinceMV model = new ProvinceMV();
            model.Active = true;
            return PartialView("EditProvincePartial", model);
        }

        // POST: Geographic/CreateProvince
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProvince(ProvinceMV provinceMV)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Province province = new Province()
                    {
                        ProvinceCode = provinceMV.ProvinceCode,
                        ProvinceName = provinceMV.ProvinceName,
                        RegionCode = provinceMV.RegionCode,
                        CreateDate = DateTime.Now,
                        UpdateDate = DateTime.Now,
                        UpdateByCode = "System",
                        Active = provinceMV.Active
                    };
                    _salesManagementDatabase.Provinces.Add(province);
                    _salesManagementDatabase.SaveChanges();
                }
                return RedirectToAction("Province");
            }
            catch
            {
                return PartialView("EditProvincePartial", provinceMV);
            }
        }

        // GET: Geographic/EditProvince/5
        public ActionResult EditProvince(int Id)
        {
            ProvinceMV model = new ProvinceMV();
            model.TitleHeader = Resource.TitleEdit;
            model.FormAction = "EditProvince";
            model.SubmitDisplay = Resource.Update;
            model.ListRegion = _salesManagementDatabase.Regions.Select(s => new SelectListItem()
            {
                Value = s.RegionCode,
                Text = s.RegionName
            }).ToList();

            if (Id != 0)
            {
                var province = _salesManagementDatabase.Provinces.Where(x => x.Id == Id).FirstOrDefault();
                if (province != null)
                {
                    model.Id = province.Id;
                    model.ProvinceCode = province.ProvinceCode;
                    model.ProvinceName = province.ProvinceName;
                    model.RegionCode = province.RegionCode;
                    model.Active = province.Active;
                }
            }
            return PartialView("EditProvincePartial", model);
        }

        // POST: Geographic/EditProvince/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProvince(ProvinceMV provinceMV)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var provinceEdit = _salesManagementDatabase.Provinces.Where(x => x.Id == provinceMV.Id).FirstOrDefault();
                    provinceEdit.ProvinceName = provinceMV.ProvinceName;
                    provinceEdit.RegionCode = provinceMV.RegionCode;
                    provinceEdit.Active = provinceMV.Active;
                    provinceEdit.UpdateDate = DateTime.Now;
                    _salesManagementDatabase.Provinces.Update(provinceEdit);
                    _salesManagementDatabase.SaveChanges();
                }
                return RedirectToAction("Province");
            }
            catch
            {
                return PartialView("EditProvincePartial", provinceMV);
            }
        }

        // POST: Geographic/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProvince(int id, IFormCollection collection)
        {
            try
            {
                var province = _salesManagementDatabase.Provinces.Where(x => x.Id == id).FirstOrDefault();
                _salesManagementDatabase.Provinces.Remove(province);
                _salesManagementDatabase.SaveChanges();

                return RedirectToAction("Province");
            }
            catch
            {
                return View();
            }
        }

        // POST: Geographic/ImportProvince
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ImportProvince(ImportExportMV importMV)
        {
            var fileUpload = new FileInfo(importMV.Attachment.FileName);
            var fileExtension = fileUpload.Extension;
            //Check if file is an Excel File
            if (fileExtension.Contains(".xls") || fileExtension.Contains(".xlsx"))
            {
                try
                {
                    List<Province> listProvinces = new List<Province>();
                    using (ExcelPackage excelPackage = new ExcelPackage(importMV.Attachment.OpenReadStream()))
                    {
                        StringBuilder sb = new StringBuilder();
                        ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.FirstOrDefault();
                        int rowCount = worksheet.Dimension.Rows;
                        int ColCount = worksheet.Dimension.Columns;
                        bool bHeaderRow = true;
                        for (int row = 2; row <= rowCount; row++)
                        {
                            Province province = new Province()
                            {
                                ProvinceCode = worksheet.Cells[row, 1].Value.ToString(),
                                ProvinceName = worksheet.Cells[row, 2].Value.ToString(),
                                RegionCode = worksheet.Cells[row, 1].Value.ToString(),
                                CreateDate = DateTime.Now,
                                UpdateDate = DateTime.Now,
                                Active = true,
                                UpdateByCode = "System"
                            };
                            listProvinces.Add(province);
                        }
                    }

                    if (listProvinces.Count > 0)
                    {
                        foreach (Province elm in listProvinces)
                        {
                            var abc = _salesManagementDatabase.Provinces.Add(elm);
                        }
                        _salesManagementDatabase.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    CustomLog.LogError(ex);
                    Console.WriteLine("Some error occured while importing." + ex.Message);
                }
            }
            // full path to file in temp location
            Console.WriteLine(importMV.OptionImport.ToString());
            return RedirectToAction("Region");
        }

        #endregion
        
    }
}