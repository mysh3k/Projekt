using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;
using Microsoft.AspNetCore.Http;
using MvcMovie.Helpers;

namespace MvcMovie.Controllers
{
    public class UsersController : Controller
    {
        private readonly MvcMovieContext _context;

        public UsersController(MvcMovieContext context)
        {
            _context = context;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Id,Login,Password,Username,Permissions")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Movies");
            }
            return View(user);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Login,Password,Username,Permissions")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    {
                        _context.Update(user);
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Edit));
            }
            return View(user);
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            bool exists = _context.User.Any(u => u.Login == user.Login && u.Password == user.Password);
            if (exists)
            {
                var usr = await _context.User.FirstOrDefaultAsync(u => u.Login == user.Login);
                
                HttpContext.Session.SetInt32("UserID", usr.Id);
                HttpContext.Session.SetString("Username",usr.Username);
                HttpContext.Session.SetString("Permissions", usr.Permissions.ToString());
                
                return RedirectToAction("Index", "Movies");
            }
            ViewBag.Message = "Invalid Login / Password";
            return View(user);
        }

        public IActionResult Logout()
        {
            
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Users");
        }

    }
}
