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

namespace SalesManagement.Controllers
{
    public class GeographicController : Controller
    {
        // GET: Geographic
        public ActionResult Region()
        {
            ViewBag.abc = Resource.Name;
            CustomLog.LogError("sdsdsdsd");
            return View();
        }

        // GET: Geographic/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Geographic/Create
        public ActionResult Create()
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
        public ActionResult Import(ImportExportMV importMV)
        {
            var fileUpload = new FileInfo(importMV.Attachment.FileName);
            var fileExtension = fileUpload.Extension;
            //Check if file is an Excel File
            if (fileExtension.Contains(".xls") || fileExtension.Contains(".xlsx"))
            {
                try
                {
                    using (ExcelPackage excelPackage = new ExcelPackage(fileUpload))
                    {
                        StringBuilder sb = new StringBuilder();
                        ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[1];
                        int rowCount = worksheet.Dimension.Rows;
                        int ColCount = worksheet.Dimension.Columns;
                        bool bHeaderRow = true;
                        for (int row = 1; row <= rowCount; row++)
                        {
                            for (int col = 1; col <= ColCount; col++)
                            {
                                if (bHeaderRow)
                                {
                                    sb.Append(worksheet.Cells[row, col].Value.ToString() + "\t");
                                }
                                else
                                {
                                    sb.Append(worksheet.Cells[row, col].Value.ToString() + "\t");
                                }
                            }
                            sb.Append(Environment.NewLine);
                        }
                        CustomLog.LogError(sb.ToString());
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