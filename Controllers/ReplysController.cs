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
    public class ReplysController : Controller
    {
        private readonly MvcMovieContext _context;

        public ReplysController(MvcMovieContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create()
        {
    
                Reply obj = new Reply();
                obj.Contents = HttpContext.Request.Form["replymsg"];
                int x = Convert.ToInt32(HttpContext.Request.Form["postid"]);
                obj.PostID = x;
                _context.Reply.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Details", "Posts", new { id = HttpContext.Request.Form["postid"] });
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed()
        {
            int id = Convert.ToInt32(HttpContext.Request.Form["replyid"]);
            var reply = await _context.Reply.FindAsync(id);
            _context.Reply.Remove(reply);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Posts", new { id = reply.PostID});
        }

        private bool ReplyExists(int id)
        {
            return _context.Reply.Any(e => e.Id == id);
        }
    }
}
