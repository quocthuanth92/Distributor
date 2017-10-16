using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using SM.Interfaces;

namespace SalesManagement.Controllers
{
    public class TestController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IProvinceDataService _provinceDataService;

        public TestController(IHostingEnvironment hostingEnvironment, IProvinceDataService provinceDataService)
        {
            _hostingEnvironment = hostingEnvironment;
            _provinceDataService = provinceDataService;
        }

        public IActionResult Index()
        {
            _provinceDataService.CreateSession();
            var abc = _provinceDataService.GetAll();
            return View();
        }
    }
}