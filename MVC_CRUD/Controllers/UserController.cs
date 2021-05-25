using Microsoft.AspNetCore.Mvc;
using MVC_CRUD.DataContext;
using MVC_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CRUD.Controllers
{
    public class UserController : Controller
    {
        private readonly CRUDDBCONTEXT _cruddbcontext;
        public UserController(CRUDDBCONTEXT crudDBCONTEXT)
        {
            _cruddbcontext = crudDBCONTEXT;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User u)
        {
            if (ModelState.IsValid)
            {
                _cruddbcontext.Users.Add(u);
                _cruddbcontext.SaveChanges();
                return RedirectToAction("Allusers");
            }
            return View("Index");
        }


        public IActionResult Allusers()
        {
            return View(_cruddbcontext.Users.ToList());

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {

            if(id == 0)
            {
                return NotFound();
            }
            var user = _cruddbcontext.Users.FirstOrDefault(u => u.UserId == id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User u)
        {
            if(u == null)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                _cruddbcontext.Update(u);
                _cruddbcontext.SaveChanges();
                return RedirectToAction("Allusers");
            }
            return View("Edit");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var user = _cruddbcontext.Users.FirstOrDefault(u => u.UserId == id);

            _cruddbcontext.Remove(user);
            _cruddbcontext.SaveChanges();
            return RedirectToAction("Allusers");
        }
    }
}
