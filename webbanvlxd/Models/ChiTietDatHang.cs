namespace webbanvlxd.Models
{
    public class ChiTietDatHang
    {
        public int ChiTietDatHangID { get; set; }

        public int DatHangID { get; set; }
        public DatHang? DatHang { get; set; }

        public int SanPhamID { get; set; }
        public SanPham? SanPham { get; set; }

        public int DonGia { get; set; }

        public int SoLuong { get; set; }

        public int ThanhTien { get; set; }
    }
}
