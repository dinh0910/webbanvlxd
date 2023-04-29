using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webbanvlxd.Data;
using webbanvlxd.Models;

namespace webbanvlxd.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DatHangsController : Controller
    {
        private readonly webbanvlxdContext _context;

        public DatHangsController(webbanvlxdContext context)
        {
            _context = context;
        }

        // GET: Admin/DatHangs
        public async Task<IActionResult> Index()
        {
              return _context.DatHang != null ? 
                          View(await _context.DatHang.ToListAsync()) :
                          Problem("Entity set 'webbanvlxdContext.DatHang'  is null.");
        }

        // GET: Admin/DatHangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DatHang == null)
            {
                return NotFound();
            }

            var datHang = await _context.DatHang
                .FirstOrDefaultAsync(m => m.DatHangID == id);
            if (datHang == null)
            {
                return NotFound();
            }

            return View(datHang);
        }

        // GET: Admin/DatHangs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/DatHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DatHangID,NgayLap,HoTen,DiaChi,SoDienThoai,TongTien")] DatHang datHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(datHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(datHang);
        }

        // GET: Admin/DatHangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DatHang == null)
            {
                return NotFound();
            }

            var datHang = await _context.DatHang.FindAsync(id);
            if (datHang == null)
            {
                return NotFound();
            }
            return View(datHang);
        }

        // POST: Admin/DatHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DatHangID,NgayLap,HoTen,DiaChi,SoDienThoai,TongTien")] DatHang datHang)
        {
            if (id != datHang.DatHangID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(datHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DatHangExists(datHang.DatHangID))
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
            return View(datHang);
        }

        // GET: Admin/DatHangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DatHang == null)
            {
                return NotFound();
            }

            var datHang = await _context.DatHang
                .FirstOrDefaultAsync(m => m.DatHangID == id);
            if (datHang == null)
            {
                return NotFound();
            }

            return View(datHang);
        }

        // POST: Admin/DatHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DatHang == null)
            {
                return Problem("Entity set 'webbanvlxdContext.DatHang'  is null.");
            }
            var datHang = await _context.DatHang.FindAsync(id);
            if (datHang != null)
            {
                _context.DatHang.Remove(datHang);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DatHangExists(int id)
        {
          return (_context.DatHang?.Any(e => e.DatHangID == id)).GetValueOrDefault();
        }
    }
}
