using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BanDoDienTu_Nhom06_N03.Models;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace BanDoDienTu_Nhom06_N03.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RolesController : Controller
    {
        private readonly BanDoDienTuContext _context;

        public INotyfService _notyfService { get; }

        public RolesController(BanDoDienTuContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: Admin/Roles
        public async Task<IActionResult> Index()
        {
            return View(_context.Roles);
        }

        // GET: Admin/Roles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Roles == null)
            {
                return NotFound();
            }

            var role = await _context.Roles
                .FirstOrDefaultAsync(m => m.RoleId == id);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        // GET: Admin/Roles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Roles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoleId,RoleName,Description")] Role role)
        {
            if (ModelState.IsValid)
            {
                if (_context.Roles.FirstOrDefault(x => x.RoleId == role.RoleId) == null)
                {
                    _context.Add(role);
                    await _context.SaveChangesAsync();
                    _notyfService.Success("Thêm mới thành công");
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("RoleId", "ID đã tồn tại");
                    _notyfService.Success("Thêm mới không thành công");
                }
            }
            return View(role);
        }

        // GET: Admin/Roles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Roles == null)
            {
                return NotFound();
            }

            var role = await _context.Roles.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }

        // POST: Admin/Roles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("RoleId,RoleName,Description")] Role role)
        {
            if (id != role.RoleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(role);
                    await _context.SaveChangesAsync();
                    _notyfService.Success("Sửa thành công");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoleExists(role.RoleId))
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
            return View(role);
        }

        // GET: Admin/Roles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Roles == null)
            {
                return NotFound();
            }

            var role = await _context.Roles
                .FirstOrDefaultAsync(m => m.RoleId == id);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        // POST: Admin/Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Roles == null)
            {
                return Problem("Entity set 'BanDoDienTuContext.Roles'  is null.");
            }
            var role = await _context.Roles.FindAsync(id);
            if (role != null)
            {
                List<DangNhap> account = _context.DangNhaps.Where(x => x.RoleId == role.RoleId).ToList();
                foreach (var item in (List<DangNhap>)account)
                {
                    _context.DangNhaps.Remove(item);
                }
                _context.Roles.Remove(role);
            }

            await _context.SaveChangesAsync();
            _notyfService.Success("Xóa thành công");
            return RedirectToAction(nameof(Index));
        }

        private bool RoleExists(string id)
        {
            return (_context.Roles?.Any(e => e.RoleId == id)).GetValueOrDefault();
        }
    }
}
