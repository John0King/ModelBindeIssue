using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ModelBindeIssue.Dtos;
using ModelBindeIssue.Models;

namespace ModelBindeIssue.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index( [FromServices] AppDbContext db)
        {
            await db.Database.EnsureCreatedAsync();
            A:
            var user = db.AppUsers.FirstOrDefault();
            if (user == null)
            {

                db.AppUsers.Add(new AppUser
                {
                    CompanyLocation = new List<string> { "山东", "济南" }
                });
                await db.SaveChangesAsync();
                goto A;
            }
            return View(new UserDto { Id = user.Id,UserName = user.UserName,
            Company = user.Company,
            CompanyAddress = user.CompanyAddress,
            CompanyLocation = user.CompanyLocation});
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserDto dto,[FromServices]AppDbContext db)
        {
            await db.Database.EnsureCreatedAsync();
            A:
            var user = db.AppUsers.AsTracking().FirstOrDefault();
            if(user == null)
            {
                
                db.AppUsers.Add(new AppUser
                {
                    CompanyLocation = new List<string> { "山东", "济南" }
                });
                await db.SaveChangesAsync();
                goto A;
            }
            await TryUpdateModelAsync(user);
            db.Update(user);
            await db.SaveChangesAsync();
            return Ok();
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
