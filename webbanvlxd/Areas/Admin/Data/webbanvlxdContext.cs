using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webbanvlxd.Models;

namespace webbanvlxd.Data
{
    public class webbanvlxdContext : DbContext
    {
        public webbanvlxdContext (DbContextOptions<webbanvlxdContext> options)
            : base(options)
        {
        }

        public DbSet<webbanvlxd.Models.Banner> Banner { get; set; } = default!;

        public DbSet<webbanvlxd.Models.QuyenHan>? QuyenHan { get; set; }

        public DbSet<webbanvlxd.Models.LoaiDanhMuc>? LoaiDanhMuc { get; set; }

        public DbSet<webbanvlxd.Models.DanhMuc>? DanhMuc { get; set; }

        public DbSet<webbanvlxd.Models.TaiKhoan>? TaiKhoan { get; set; }

        public DbSet<webbanvlxd.Models.ThuongHieu>? ThuongHieu { get; set; }

        public DbSet<webbanvlxd.Models.SanPham>? SanPham { get; set; }

        public DbSet<webbanvlxd.Models.DatHang>? DatHang { get; set; }

        public DbSet<webbanvlxd.Models.ThongSo>? ThongSo { get; set; }

        public DbSet<webbanvlxd.Models.HinhAnh>? HinhAnh { get; set; }
    }
}
