﻿namespace webbanvlxd.Models
{
    public class DanhMuc
    {
        public int DanhMucID { get; set; }

        public int LoaiDanhMucID { get; set; }
        public LoaiDanhMuc? LoaiDanhMuc { get; set; }

        public string? Ten { get; set; }
    }
}
