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

        private CollegeViewModel GetViewModel(College dbModel)
        {
            var model = new CollegeViewModel
            {
                ID = dbModel.ID,
                Name = dbModel.Name,
                Address = dbModel.Address,
                Email = dbModel.Email
            };
            return model;
        }

        public IActionResult Delete(int id)
        {
            _collegeService.DeleteCollege(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var dbCollege = _collegeService.GetCollegeById(id);

            var model = GetViewModel(dbCollege);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(CollegeViewModel model)
        {
            var dbModel = GetDataModel(model);
            _collegeService.UpdateCollege(dbModel);

            return RedirectToAction(nameof(Index));
        }
    }
}
