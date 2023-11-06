using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using web_1.Context;
using web_1.Models;

namespace web_1.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly ApplicationDBContext _context;

        public KullaniciController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Kullanici
        public async Task<IActionResult> Index()
        {
            return _context.kullanici != null ?
                        View(await _context.kullanici.ToListAsync()) :
                        Problem("Entity set 'ApplicationDBContext.kullanici'  is null.");
        }

        // GET: Kullanici/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.kullanici == null)
            {
                return NotFound();
            }

            var kullanici = await _context.kullanici
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kullanici == null)
            {
                return NotFound();
            }

            return View(kullanici);
        }

        // GET: Kullanici/Create
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult UyeOl()
        {
            return View();
        }

        // POST: Kullanici/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,PasswordHash")] Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kullanici);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kullanici);
        }

        // GET: Kullanici/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.kullanici == null)
            {
                return NotFound();
            }

            var kullanici = await _context.kullanici.FindAsync(id);
            if (kullanici == null)
            {
                return NotFound();
            }
            return View(kullanici);
        }

        // POST: Kullanici/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Email,PasswordHash")] Kullanici kullanici)
        {
            if (id != kullanici.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kullanici);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KullaniciExists(kullanici.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(kullanici);
        }

        // GET: Kullanici/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.kullanici == null)
            {
                return NotFound();
            }

            var kullanici = await _context.kullanici
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kullanici == null)
            {
                return NotFound();
            }

            return View(kullanici);
        }

        // POST: Kullanici/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.kullanici == null)
            {
                return Problem("Entity set 'ApplicationDBContext.kullanici'  is null.");
            }
            var kullanici = await _context.kullanici.FindAsync(id);
            if (kullanici != null)
            {
                _context.kullanici.Remove(kullanici);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KullaniciExists(int id)
        {
            return (_context.kullanici?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
