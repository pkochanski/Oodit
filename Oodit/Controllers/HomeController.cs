using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Oodit.Services;

namespace Oodit.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICheckService _checkService;
        public HomeController(ICheckService checkService)
        {
            _checkService = checkService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckArray(string inputString) 
        {
            var result = _checkService.CheckArray(inputString);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
