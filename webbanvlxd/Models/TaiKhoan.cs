namespace webbanvlxd.Models
{
    public class TaiKhoan
    {
        public int TaiKhoanID { get; set; }

        public string? TenTaiKhoan { get; set; }

        public string? HoTen { get; set; }

        public string? SoDienThoai { get;set; }

        public string? Email { get; set; }

        public string? DiaChi { get; set; }

        public int QuyenHanID { get; set; }
        public QuyenHan? QuyenHan { get; set; }
    }
}
