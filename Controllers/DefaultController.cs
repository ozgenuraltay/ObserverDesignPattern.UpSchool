using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ObserverDesignPattern.Upschool.DAL;
using ObserverDesignPattern.Upschool.Models;
using ObserverDesignPattern.Upschool.ObserverDesignPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObserverDesignPattern.Upschool.Controllers
{
    public class DefaultController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly UserObserverSubject _userObserverSubject;

        public DefaultController(UserManager<AppUser> userManager, UserObserverSubject userObserverSubject)
        {
            _userManager = userManager;
            _userObserverSubject = userObserverSubject;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterVM userRegisterVM)
        {
            var appUser = new AppUser()
            {
                UserName = userRegisterVM.UserName,
                Email = userRegisterVM.Mail,
                Name = userRegisterVM.Name,
                Surname = userRegisterVM.Surname
            };

            var result = await _userManager.CreateAsync(appUser, userRegisterVM.Password);
            if (result.Succeeded)
            {
                _userObserverSubject.NotifyObserver(appUser);
                ViewBag.message = "Üyelik sistemi başarılı bir şekilde oluşturuldu.";
            }
            else
            {
                ViewBag.message = "Üyelik kaydında bir hata oluştu.";
            }
            return View();
        }
    }
}
