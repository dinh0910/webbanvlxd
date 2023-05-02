using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using webbanvlxd.Data;
using webbanvlxd.Models;

namespace webbanvlxd.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SanPhamsController : Controller
    {
        private readonly webbanvlxdContext _context;

        public SanPhamsController(webbanvlxdContext context)
        {
            _context = context;
        }

        // GET: Admin/SanPhams
        public async Task<IActionResult> Index()
        {
            var webbanvlxdContext = _context.SanPham.Include(s => s.DanhMuc).Include(s => s.ThuongHieu);
            return View(await webbanvlxdContext.ToListAsync());
        }

        // GET: Admin/SanPhams/Create
        public IActionResult Create()
        {
            ViewData["DanhMucID"] = new SelectList(_context.DanhMuc, "DanhMucID", "DanhMucID");
            ViewData["ThuongHieuID"] = new SelectList(_context.ThuongHieu, "ThuongHieuID", "ThuongHieuID");
            return View();
        }

        // POST: Admin/SanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SanPhamID,DanhMucID,ThuongHieuID,TenSanPham,HinhAnh,DonGia,Sale,ThanhTien,SoLuong")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DanhMucID"] = new SelectList(_context.DanhMuc, "DanhMucID", "DanhMucID", sanPham.DanhMucID);
            ViewData["ThuongHieuID"] = new SelectList(_context.ThuongHieu, "ThuongHieuID", "ThuongHieuID", sanPham.ThuongHieuID);
            return View(sanPham);
        }

        // GET: Admin/SanPhams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SanPham == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPham.FindAsync(id);
            if (sanPham == null)
            {
                return NotFound();
            }
            ViewData["DanhMucID"] = new SelectList(_context.DanhMuc, "DanhMucID", "DanhMucID", sanPham.DanhMucID);
            ViewData["ThuongHieuID"] = new SelectList(_context.ThuongHieu, "ThuongHieuID", "ThuongHieuID", sanPham.ThuongHieuID);
            return View(sanPham);
        }

        // POST: Admin/SanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SanPhamID,DanhMucID,ThuongHieuID,TenSanPham,HinhAnh,DonGia,Sale,ThanhTien,SoLuong")] SanPham sanPham)
        {
            if (id != sanPham.SanPhamID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanPhamExists(sanPham.SanPhamID))
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
            ViewData["DanhMucID"] = new SelectList(_context.DanhMuc, "DanhMucID", "DanhMucID", sanPham.DanhMucID);
            ViewData["ThuongHieuID"] = new SelectList(_context.ThuongHieu, "ThuongHieuID", "ThuongHieuID", sanPham.ThuongHieuID);
            return View(sanPham);
        }

        // GET: Admin/SanPhams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SanPham == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPham
                .Include(s => s.DanhMuc)
                .Include(s => s.ThuongHieu)
                .FirstOrDefaultAsync(m => m.SanPhamID == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // POST: Admin/SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SanPham == null)
            {
                return Problem("Entity set 'webbanvlxdContext.SanPham'  is null.");
            }
            var sanPham = await _context.SanPham.FindAsync(id);
            if (sanPham != null)
            {
                _context.SanPham.Remove(sanPham);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanPhamExists(int id)
        {
          return (_context.SanPham?.Any(e => e.SanPhamID == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SanPham == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPham
                .Include(s => s.DanhMuc)
                .Include(s => s.ThuongHieu)
                .FirstOrDefaultAsync(m => m.SanPhamID == id);

            ViewBag.hinhanh = _context.HinhAnh;
            ViewBag.thongso = _context.ThongSo;
            ViewBag.mota = _context.MoTa;

            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(int? id, [Bind("ThongSoID,SanPhamID,NoiDung")] ThongSo thongSo,
            [Bind("HinhAnhID,SanPhamID,Anh")] HinhAnh hinhAnh, [Bind("MoTaID,SanPhamID,NoiDungMoTa")] MoTa moTa)
        {
            if(moTa.NoiDungMoTa != null)
            {
                _context.Update(moTa);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Details", "SanPhams", routeValues: new { id });
        }

        public async Task<IActionResult> DeleteMoTa(int? id)
        {
            var tt = await _context.MoTa
                    .FirstOrDefaultAsync(m => m.SanPhamID == id);

            _context.MoTa.Remove(tt);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "SanPhams", routeValues: new { id });
        }
    }
}
