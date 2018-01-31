using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Portfolio.ViewModels;

namespace Portfolio.Controllers
{
    //[Authorize]      
    public class BlogController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public BlogController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, AppDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }

        public IActionResult Index()
        {
            //List<Post> model = _db.Posts.ToList();
            //return View(model);
            return View(_db.Posts.ToList());
        }

        //[Authorize(Roles = "Administrator")]

        public IActionResult CreatePost()
        {
            return View();
        }

        //[Authorize(Roles = "Administrator")]

        [HttpPost]
        public IActionResult CreatePost(Post post)
        {
            //var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //var currentUser = await _userManager.FindByIdAsync(userId);
            //post.User = currentUser;
            _db.Posts.Add(post);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        //[Authorize(Roles = "Administrator")]

        public IActionResult EditPost(int id)
        {
            Post thisPost = _db.Posts.FirstOrDefault(c => c.PostId == id);
            return View(thisPost);
        }

        //[Authorize(Roles = "Administrator")]

        [HttpPost]
        public IActionResult EditPost(Post post)
        {
            _db.Entry(post).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult DeletePost(int id)
        {
            Post thisPost = _db.Posts.FirstOrDefault(x => x.PostId == id);
            return View(thisPost);
        }

        //[Authorize(Roles = "Administrator")]
       
        [HttpPost, ActionName("Delete")]     
        public IActionResult DeleteConfirmed(Post post)     
        {
            //Post thisPost = _db.Posts.FirstOrDefault(m => m.PostId == id);
            _db.Posts.Remove(post);
            _db.SaveChanges();
            return RedirectToAction("Index");    
        }

        public IActionResult Details(int id)
        {
            Post thisPost = _db.Posts.Include(p => p.Comments)
                                             .FirstOrDefault(c => c.PostId == id);

            return View(new AddComment(thisPost));
        }

        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
            _db.Comments.Add(comment);
            _db.SaveChanges();
            //return RedirectToAction("Index");           
            return RedirectToAction("Details", new { id = comment.PostId });         
        }

       
        public IActionResult DeleteComment(int id)
        {
            Comment thisComment = _db.Comments.FirstOrDefault(c => c.CommentId == id);
            return View(thisComment);
        }


        [HttpPost, ActionName("CommentDelete")]
        public IActionResult DeleteConfirmed(Comment comment)
        {
            //Post thisPost = _db.Posts.FirstOrDefault(m => m.PostId == id);
            _db.Comments.Remove(comment);
            _db.SaveChanges();
            return RedirectToAction("Index"); 
        }           

    }
}
