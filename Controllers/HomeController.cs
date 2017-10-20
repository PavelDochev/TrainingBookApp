using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrainingBookApp.Models;

namespace TrainingBookApp.Controllers
{
    
    public class HomeController : Controller
    {
        private TrainingBookAppContext _context;

        public HomeController(TrainingBookAppContext context)
        {
            _context = context;
        }

        [Route("api/[controller]/[action]")]
        [HttpGet("[action]")]
        public List<TrainingType> Test()
        {
            //if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            //    return null;

            return _context.TrainingType.ToList();

            // check if username exists
            //if (user == null)
            //    return null;

            // check if password is correct
            //if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            //    return null;

            // authentication successful
            //return user;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            //ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
