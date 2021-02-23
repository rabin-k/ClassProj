using ClassProj.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassProj.Controllers
{
    public class CollegeController : Controller
    {
        public IActionResult Index()
        { 
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CollegeViewModel model)
        {
            //data save logic

            return View(model);
        }
    }
}
