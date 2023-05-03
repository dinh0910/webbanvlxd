using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;
using webbanvlxd.Data;
using webbanvlxd.Models;

namespace webbanvlxd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly webbanvlxdContext _context;

        public HomeController(ILogger<HomeController> logger, webbanvlxdContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var sp = _context.SanPham.Include(s => s.DanhMuc).Include(s => s.ThuongHieu);
            ViewBag.loaidanhmuc = _context.LoaiDanhMuc;
            ViewBag.danhmuc = _context.DanhMuc.Include(d => d.LoaiDanhMuc);
            return View(sp.ToList());
        }

        public async Task<IActionResult> Details(int? id)
        {
            var sp = _context.SanPham.Include(s => s.DanhMuc).Include(s => s.ThuongHieu).FirstOrDefaultAsync(s => s.SanPhamID == id);
            ViewBag.loaidanhmuc = _context.LoaiDanhMuc;
            ViewBag.danhmuc = _context.DanhMuc.Include(d => d.LoaiDanhMuc);
            ViewBag.thongso = _context.ThongSo;
            ViewBag.hinhanh = _context.HinhAnh;
            ViewBag.mota = _context.MoTa;
            return View(await sp);
        }

        public async Task<IActionResult> Category(int? id)
        {
            var sp = _context.SanPham.Include(s => s.DanhMuc).Include(s => s.ThuongHieu).Where(s => s.SanPhamID == id);
            ViewBag.loaidanhmuc = _context.LoaiDanhMuc;
            ViewBag.danhmuc = _context.DanhMuc.Include(d => d.LoaiDanhMuc);
            ViewBag.dm = _context.DanhMuc.FirstOrDefault(d => d.DanhMucID == id);
            return View(await sp.ToListAsync());
        }

        public const string CARTKEY = "shopcart";

        List<CartItem> GetCartItems()
        {
            var session = HttpContext.Session;
            string jsoncart = session.GetString(CARTKEY);
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<List<CartItem>>(jsoncart);
            }
            return new List<CartItem>();
        }

        void SaveCartSession(List<CartItem> list)
        {
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(list);
            session.SetString(CARTKEY, jsoncart);
        }

        // Xóa session giỏ hàng
        void ClearCart()
        {
            var session = HttpContext.Session;
            session.Remove(CARTKEY);
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            ViewBag.danhmuc = _context.DanhMuc;
            var product = await _context.SanPham
                .FirstOrDefaultAsync(m => m.SanPhamID == id);

            var cart = GetCartItems();
            var item = cart.Find(p => p.SanPham.SanPhamID == id);
            if (item != null)
            {
                item.SoLuong++;
            }
            else
            {
                cart.Add(new CartItem() { SanPham = product, SoLuong = 1 });
            }
            SaveCartSession(cart);
            return RedirectToAction(nameof(ViewCart));
        }

        public async Task<IActionResult> UpdateItem(int id, int quantity)
        {
            var cart = GetCartItems();
            var item = cart.Find(p => p.SanPham.SanPhamID == id);
            if (quantity == 0)
            {
                cart.Remove(item);
            }

            item.SoLuong = quantity;
            SaveCartSession(cart);
            return RedirectToAction(nameof(ViewCart));
        }

        public IActionResult ViewCart()
        {
            ViewBag.loaidanhmuc = _context.LoaiDanhMuc;
            ViewBag.danhmuc = _context.DanhMuc.Include(d => d.LoaiDanhMuc);
            return View(GetCartItems());
        }

        public IActionResult CheckOut()
        {
            ViewBag.loaidanhmuc = _context.LoaiDanhMuc;
            ViewBag.danhmuc = _context.DanhMuc.Include(d => d.LoaiDanhMuc);
            return View(GetCartItems());
        }

        public async Task<IActionResult> CreateBill(string HoTen, string Sdt, string DiaChi)
        {
            // lưu hóa đơn
            var bill = new DatHang();
            bill.NgayLap = DateTime.Now;
            bill.HoTen = HoTen;
            bill.SoDienThoai = Sdt;
            bill.DiaChi = DiaChi;

            _context.Add(bill);
            await _context.SaveChangesAsync();

            var cart = GetCartItems();
            int amount = 0;
            int soLuong = 0;

            //chi tiết hóa đơn
            foreach (var i in cart)
            {
                var b = new ChiTietDatHang();
                b.DatHangID = bill.DatHangID;
                b.SanPhamID = i.SanPham.SanPhamID;
                b.DonGia = i.SanPham.ThanhTien;
                b.SoLuong = i.SoLuong;
                amount = i.SanPham.ThanhTien * i.SoLuong;
                b.ThanhTien = amount;

                var sp = _context.SanPham.FirstOrDefault(s => s.SanPhamID == b.SanPhamID);
                sp.SoLuong -= i.SoLuong;
                bill.TongTien += amount;
                _context.Add(b);
            }
            await _context.SaveChangesAsync();
            ClearCart();
            return RedirectToAction(nameof(Success));
        }

        public IActionResult Success()
        {
            ViewBag.loaidanhmuc = _context.LoaiDanhMuc;
            ViewBag.danhmuc = _context.DanhMuc.Include(d => d.LoaiDanhMuc);
            return View();
        }

        public IActionResult Search(string? search)
        {
            var s = _context.SanPham.Where(s => s.TenSanPham.Contains(search));
            ViewBag.loaidanhmuc = _context.LoaiDanhMuc;
            ViewBag.danhmuc = _context.DanhMuc.Include(d => d.LoaiDanhMuc);
            return View(s);
        }
    }
}