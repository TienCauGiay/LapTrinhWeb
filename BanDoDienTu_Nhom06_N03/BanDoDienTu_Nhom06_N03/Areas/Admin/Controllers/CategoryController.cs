using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BanDoDienTu_Nhom06_N03.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using AspNetCoreHero.ToastNotification.Abstractions;
using X.PagedList;

namespace BanDoDienTu_Nhom06_N03.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly BanDoDienTuContext _context;

        public INotyfService _notyfService { get; }

        public CategoryController(BanDoDienTuContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: Admin/Category
        public async Task<IActionResult> Index(int? page)
        {
            int pageSize = 4;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var listCategory = _context.DanhMucs.ToList();
            PagedList<DanhMuc> res = new PagedList<DanhMuc>(listCategory, pageNumber, pageSize);
            return View(res);
        }

        // GET: Admin/Category/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.DanhMucs == null)
            {
                return NotFound();
            }

            var danhMuc = await _context.DanhMucs
                .FirstOrDefaultAsync(m => m.MaDm == id);
            if (danhMuc == null)
            {
                return NotFound();
            }

            return View(danhMuc);
        }

        // GET: Admin/Category/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaDm,TenDm")] DanhMuc danhMuc)
        {
            if (ModelState.IsValid)
            {
                if (_context.DanhMucs.FirstOrDefault(x => x.MaDm == danhMuc.MaDm) == null)
                {
                    _context.Add(danhMuc);
                    await _context.SaveChangesAsync();
                    _notyfService.Success("Thêm mới danh mục thành công");
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("MaDm", "Mã danh mục đã tồn tại");
                }
            }
            return View(danhMuc);
        }

        // GET: Admin/Category/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.DanhMucs == null)
            {
                return NotFound();
            }

            var danhMuc = await _context.DanhMucs.FindAsync(id);
            if (danhMuc == null)
            {
                return NotFound();
            }
            return View(danhMuc);
        }

        // POST: Admin/Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaDm,TenDm")] DanhMuc danhMuc)
        {
            if (id != danhMuc.MaDm)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(danhMuc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanhMucExists(danhMuc.MaDm))
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
            return View(danhMuc);
        }

        // GET: Admin/Category/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.DanhMucs == null)
            {
                return NotFound();
            }

            var danhMuc = await _context.DanhMucs
                .FirstOrDefaultAsync(m => m.MaDm == id);
            if (danhMuc == null)
            {
                return NotFound();
            }

            return View(danhMuc);
        }

        // POST: Admin/Category/Delete/5
        // Xóa danh mục => phải xóa cthdn, dthdb, sản phẩm trước
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.DanhMucs == null)
            {
                return Problem("Entity set 'BanDoDienTuContext.DanhMucs'  is null.");
            }
            var danhMuc = await _context.DanhMucs.FindAsync(id);
            if (danhMuc != null)
            {
                _context.DanhMucs.Remove(danhMuc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanhMucExists(string id)
        {
            return (_context.DanhMucs?.Any(e => e.MaDm == id)).GetValueOrDefault();
        }
    }
}
