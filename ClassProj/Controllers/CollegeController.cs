using ClassProj.Data.Entities;
using ClassProj.Data.Services;
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
        private readonly ICollegeService _collegeService;

        public CollegeController(ICollegeService collegeService)
        {
            _collegeService = collegeService;
        }

        public IActionResult Index()
        {
            var colleges = _collegeService.GetAllColleges();
            var models = GetViewModels(colleges);
            return View(models);
        }

        private List<CollegeViewModel> GetViewModels(List<College> colleges)
        {
            List<CollegeViewModel> models = new List<CollegeViewModel>();

            foreach(var college in colleges)
            {
                var model = new CollegeViewModel
                {
                    ID = college.ID,
                    Name = college.Name,
                    Address = college.Address,
                    Email  = college.Email
                };

                models.Add(model);
            }
            return models;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CollegeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var dbModel = GetDataModel(model);
            _collegeService.AddCollege(dbModel);

            return RedirectToAction(nameof(Index));
        }

        private College GetDataModel(CollegeViewModel model)
        {
            var dbModel = new College
            {
                ID = model.ID,
                Name = model.Name,
                Address = model.Address,
                Email = model.Email
            };
            return dbModel;
        }
    }
}
