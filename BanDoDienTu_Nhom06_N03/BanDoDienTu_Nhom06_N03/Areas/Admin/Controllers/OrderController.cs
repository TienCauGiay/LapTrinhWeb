using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BanDoDienTu_Nhom06_N03.Models;

namespace BanDoDienTu_Nhom06_N03.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly BanDoDienTuContext _context;

        public OrderController(BanDoDienTuContext context)
        {
            _context = context;
        }

        // GET: Admin/Order
        public async Task<IActionResult> Index()
        {
            var banDoDienTuContext = _context.ChiTietHdbs.Include(c => c.Ma).Include(c => c.MaHdbNavigation);
            return View(await banDoDienTuContext.ToListAsync());
        }

        // GET: Admin/Order/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ChiTietHdbs == null)
            {
                return NotFound();
            }

            var chiTietHdb = await _context.ChiTietHdbs
                .Include(c => c.Ma)
                .Include(c => c.MaHdbNavigation)
                .FirstOrDefaultAsync(m => m.MaHdb == id);
            if (chiTietHdb == null)
            {
                return NotFound();
            }

            return View(chiTietHdb);
        }

        // GET: Admin/Order/Create
        public IActionResult Create()
        {
            ViewData["MaSp"] = new SelectList(_context.SanPhams, "MaSp", "MaSp");
            ViewData["MaHdb"] = new SelectList(_context.HoaDonBans, "MaHdb", "MaHdb");
            return View();
        }

        // POST: Admin/Order/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHdb,MaSp,Slban,MaDm")] ChiTietHdb chiTietHdb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chiTietHdb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaSp"] = new SelectList(_context.SanPhams, "MaSp", "MaSp", chiTietHdb.MaSp);
            ViewData["MaHdb"] = new SelectList(_context.HoaDonBans, "MaHdb", "MaHdb", chiTietHdb.MaHdb);
            return View(chiTietHdb);
        }

        // GET: Admin/Order/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ChiTietHdbs == null)
            {
                return NotFound();
            }

            var chiTietHdb = await _context.ChiTietHdbs.FindAsync(id);
            if (chiTietHdb == null)
            {
                return NotFound();
            }
            ViewData["MaSp"] = new SelectList(_context.SanPhams, "MaSp", "MaSp", chiTietHdb.MaSp);
            ViewData["MaHdb"] = new SelectList(_context.HoaDonBans, "MaHdb", "MaHdb", chiTietHdb.MaHdb);
            return View(chiTietHdb);
        }

        // POST: Admin/Order/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaHdb,MaSp,Slban,MaDm")] ChiTietHdb chiTietHdb)
        {
            if (id != chiTietHdb.MaHdb)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chiTietHdb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChiTietHdbExists(chiTietHdb.MaHdb))
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
            ViewData["MaSp"] = new SelectList(_context.SanPhams, "MaSp", "MaSp", chiTietHdb.MaSp);
            ViewData["MaHdb"] = new SelectList(_context.HoaDonBans, "MaHdb", "MaHdb", chiTietHdb.MaHdb);
            return View(chiTietHdb);
        }

        // GET: Admin/Order/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ChiTietHdbs == null)
            {
                return NotFound();
            }

            var chiTietHdb = await _context.ChiTietHdbs
                .Include(c => c.Ma)
                .Include(c => c.MaHdbNavigation)
                .FirstOrDefaultAsync(m => m.MaHdb == id);
            if (chiTietHdb == null)
            {
                return NotFound();
            }

            return View(chiTietHdb);
        }

        // POST: Admin/Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ChiTietHdbs == null)
            {
                return Problem("Entity set 'BanDoDienTuContext.ChiTietHdbs'  is null.");
            }
            var chiTietHdb = await _context.ChiTietHdbs.FindAsync(id);
            if (chiTietHdb != null)
            {
                _context.ChiTietHdbs.Remove(chiTietHdb);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChiTietHdbExists(string id)
        {
            return (_context.ChiTietHdbs?.Any(e => e.MaHdb == id)).GetValueOrDefault();
        }
    }
}
