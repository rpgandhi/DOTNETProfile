//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.AspNetCore.Http;
//using Portfolio.Models;
//using Portfolio.ViewModels;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.AspNetCore.Authorization;

//namespace Portfolio.Controllers
//{
//    [Authorize(Roles = "Administrator")]
//    public class RoleController : Controller
//    {
//        private readonly AppDbContext _db;
//        private readonly UserManager<AppUser> _userManager;
//        private readonly SignInManager<AppUser> _signInManager;
//      

//        public RoleController(UserManager<AppUser> userManager, SignInManager<AppUser>
//          signInManager,  AppDbContext db)
//        {
//            _userManager = userManager;
//            _signInManager = signInManager;
//            _roleManager = roleManager;
//            _db = db;
//        }

//        public IActionResult Index()
//        {
//            return View(_db.Roles.ToList());
//        }

//        public IActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        public IActionResult Create(CreateRoleViewModel model)
//        {
//            try
//            {
//                _db.Roles.Add(new IdentityRole()
//                {
//                    Name = model.RoleName
//                });
//                _db.SaveChanges();
//                ViewBag.ResultMessage = "Role created!";
//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        public IActionResult Delete(string roleName)
//        {
//            var thisRole = _db.Roles.Where(r => r.Name == roleName).FirstOrDefault();
//            _db.Roles.Remove(thisRole);
//            _db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        public IActionResult ManageUserRoles()
//        {
//            ViewBag.RoleList = new SelectList(_db.Roles, "Name", "Name");
//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> RoleAddToUser(string UserName, string RoleName)
//        {
//            var user = _db.Users.Where(u => u.UserName == UserName).FirstOrDefault();
//            await _userManager.AddToRoleAsync(user, RoleName);

//            ViewBag.RoleList = new SelectList(_db.Roles, "Name", "Name");

//            return View("ManageUserRoles");
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> GetRoles(string UserName)
//        {
//            if (!string.IsNullOrWhiteSpace(UserName))
//            {
//                AppUser user = _db.Users.Where(u => u.UserName == UserName).FirstOrDefault();


//                ViewBag.RolesForThisUser = await _userManager.GetRolesAsync(user);

//                ViewBag.RoleList = new SelectList(_db.Roles, "Name", "Name");
//            }

//            return View("ManageUserRoles");
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteRoleForUser(string UserName, string RoleName)
//        {
//            AppUser user = _db.Users.Where(u => u.UserName == UserName).FirstOrDefault();

//            if (await _userManager.IsInRoleAsync(user, RoleName))
//            {
//                await _userManager.RemoveFromRoleAsync(user, RoleName);
//            }

//            ViewBag.RoleList = new SelectList(_db.Roles, "Name", "Name");

//            return View("ManageUserRoles");
//        }
//    }
//}