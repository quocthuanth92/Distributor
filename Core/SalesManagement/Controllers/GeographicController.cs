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

        // GET: Geographic
        public ActionResult Region()
        {
            _salesManagementDatabase.Provinces.ToList();
            ViewBag.abc = Resource.Name;
            CustomLog.LogError("sdsdsdsd");
            return View();
        }


        // GET: Geographic
        public ActionResult Province()
        {
            GeoViewModels geoViewModels = new GeoViewModels();
            geoViewModels.ListResult = (from p in _salesManagementDatabase.Provinces
                                        join r in _salesManagementDatabase.Regions
                                        on p.RegionCode equals r.RegionCode into joined
                                        from j in joined.DefaultIfEmpty()
                                        select new ProvinceMV()
                                        {
                                            ProvinceCode = p.ProvinceCode,
                                            ProvinceName = p.ProvinceName,
                                            RegionName = j.RegionName,
                                            Active = p.Active,
                                            UpdateDate = p.UpdateDate
                                        }).ToList();
            return View(geoViewModels);
        }


        // GET: Geographic/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Geographic/CreateProvince
        public ActionResult CreateProvince()
        {
            return View();
        }

        // POST: Geographic/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Geographic/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Geographic/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Geographic/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Geographic/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

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
                            Province province = new Province() {
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
    }
}