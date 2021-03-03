using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassProj.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserStore<IdentityUser> _userStore;

        public AccountController(UserStore<IdentityUser> userStore)
        {
            _userStore = userStore;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
