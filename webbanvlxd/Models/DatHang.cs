using System.ComponentModel.DataAnnotations;

namespace webbanvlxd.Models
{
    public class DatHang
    {
        public int DatHangID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgayLap { get; set; }

        public string? HoTen { get; set; }

        public string? DiaChi { get; set; }

        public string? SoDienThoai { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0} đ")]
        public int TongTien { get; set; }
    }
}
