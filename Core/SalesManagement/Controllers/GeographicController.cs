using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SM.Common;
using Microsoft.Extensions.Localization;
using SM.Resources;

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
    }
}