using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TalTechGym.Models;
using Microsoft.EntityFrameworkCore;
using TalTechGym.Data;
using TalTechGym.Models.GymViewModels;

namespace TalTechGym.Controllers
{
    public class HomeController : Controller
    {
        private readonly TalTechGymContext _context;

        public HomeController(TalTechGymContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> About()
        {
            IQueryable<EnrollmentDateGroup> data = 
                from student in _context.Students
                group student by student.EnrollmentDate into dateGroup
                select new EnrollmentDateGroup()
                {
                    EnrollmentDate = dateGroup.Key,
                    StudentCount = dateGroup.Count()
                };
            return View(await data.AsNoTracking().ToListAsync());
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
