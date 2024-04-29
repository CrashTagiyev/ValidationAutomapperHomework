using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ValidationAutomapperHomework.Models;
using ValidationAutomapperHomework.View_Models;

namespace ValidationAutomapperHomework.Controllers
{
    public class UsersController : Controller
    {
        private readonly UsersDBContext _context;
        private readonly IMapper _mapper;

        public UsersController(UsersDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context._users.ToListAsync());
        }
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LogIn(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                User loggedUser = IsUserExist(user);
                if (loggedUser is not null)
                {
                    return RedirectToAction("Profile", loggedUser);
                }
                return View();
            }
            return View();
        }
        public IActionResult Profile(User user)
        {
            return View(user);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegistrationViewModel user)
        {
            User newUser=_mapper.Map<User>(user);
            if (ModelState.IsValid)
            {
                _context.Add(newUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        private User IsUserExist(LoginViewModel login)
        {
            return _context._users.FirstOrDefault(u => u.Usernaame == login.Username && u.Password == login.Password);
        }

    }
}
