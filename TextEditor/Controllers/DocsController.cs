using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TextEditor.Data;
using TextEditor.Models;

namespace TextEditor.Controllers
{
    [Authorize]
    public class DocsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DocsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Docs
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userDocs = await _context.Docs
                .Where(d => d.UserId == userId)
                .ToListAsync();
            return View(userDocs);
        }

        // GET: Docs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Docs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Content")] Doc doc)
        {
            if (ModelState.IsValid)
            {
                doc.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (doc.UserId == null)
                {
                    return Unauthorized("You must be logged in to create a document.");
                }
                _context.Add(doc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doc);
        }

        // GET: Docs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound("Document ID cannot be null.");
            }

            var doc = await _context.Docs.FindAsync(id);
            if (doc == null || doc.UserId != User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                return NotFound("Document not found or you do not have permission to edit it.");
            }

            return View(doc);
        }

        // POST: Docs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Content")] Doc doc)
        {
            if (id != doc.Id)
            {
                return NotFound("Document ID mismatch.");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (doc.UserId != userId)
            {
                return Unauthorized("You cannot edit another user's document.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocExists(doc.Id))
                    {
                        return NotFound("Document no longer exists.");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(doc);
        }

        // GET: Docs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound("Document ID cannot be null.");
            }

            var doc = await _context.Docs
                .FirstOrDefaultAsync(d => d.Id == id && d.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (doc == null)
            {
                return NotFound("Document not found or you do not have permission to delete it.");
            }

            return View(doc);
        }

        // POST: Docs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var doc = await _context.Docs
                .FirstOrDefaultAsync(d => d.Id == id && d.UserId == userId);

            if (doc == null)
            {
                return NotFound("Document not found or you do not have permission to delete it.");
            }

            _context.Docs.Remove(doc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocExists(int id)
        {
            return _context.Docs.Any(e => e.Id == id);
        }
    }
}
