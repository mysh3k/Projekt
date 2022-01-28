using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class PostsController : Controller
    {
        private readonly MvcMovieContext _context;

        public PostsController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Post
                .FirstOrDefaultAsync(m => m.Id == id);
            var user = await _context.User.FirstOrDefaultAsync(u => u.Id == post.UserID);
            ViewData["Username"] = user.Username;
            ViewData["UserID"] = user.Id;
            ViewData["Replies"] = _context.Reply.Where(r => r.PostID == id);

            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Posts/Create
        public async Task<IActionResult> Create(int? id)
        {
            ViewData["Message"] = id;
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Thread,Contents,UserID,MovieID")] Post post)
        {
            if (ModelState.IsValid)
            {
                Post obj = new Post();
                obj.Thread = post.Thread;
                obj.Contents = post.Contents;
                obj.MovieID = post.MovieID;
                obj.UserID = post.UserID;
                _context.Post.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Details", "Posts", new { id = obj.Id});
            }
            var id = post.MovieID;
            ViewData["Message"] = id;
            return View(post);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed()
        {
            int id = Convert.ToInt32(HttpContext.Request.Form["postid"]);
            var post = await _context.Post.FindAsync(id);
            _context.Post.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Movies", new { id = post.MovieID });
        }

        private bool PostExists(int id)
        {
            return _context.Post.Any(e => e.Id == id);
        }
    }
}
