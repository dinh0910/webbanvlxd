using System.ComponentModel.DataAnnotations;

namespace webbanvlxd.Models
{
    public class ChiTietDatHang
    {
        public int ChiTietDatHangID { get; set; }

        public int DatHangID { get; set; }
        public DatHang? DatHang { get; set; }

        public int SanPhamID { get; set; }
        public SanPham? SanPham { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0} đ")]
        public int DonGia { get; set; }

        public int SoLuong { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0} đ")]
        public int ThanhTien { get; set; }
    }
}
