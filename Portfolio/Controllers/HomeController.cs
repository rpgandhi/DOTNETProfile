using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            

            return View();
        }

        public IActionResult Contact()
        {
            

            return View();
        }

        public IActionResult Blog()
        {
          
            return View();
        }

        public IActionResult Projects()
        {
            var starredProjects = GithubRepos.GetStarredRepos();
            return View(starredProjects);
        }

        public IActionResult Photography()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}
