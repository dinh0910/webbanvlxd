﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webbanvlxd.Data;

#nullable disable

namespace webbanvlxd.Migrations
{
    [DbContext(typeof(webbanvlxdContext))]
    [Migration("20230502073823_Init1")]
    partial class Init1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("webbanvlxd.Models.Banner", b =>
                {
                    b.Property<int>("BannerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BannerID"), 1L, 1);

                    b.Property<string>("Anh")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BannerID");

                    b.ToTable("Banner");
                });

            modelBuilder.Entity("webbanvlxd.Models.DanhMuc", b =>
                {
                    b.Property<int>("DanhMucID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DanhMucID"), 1L, 1);

                    b.Property<int>("LoaiDanhMucID")
                        .HasColumnType("int");

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DanhMucID");

                    b.ToTable("DanhMuc");
                });

            modelBuilder.Entity("webbanvlxd.Models.DatHang", b =>
                {
                    b.Property<int>("DatHangID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DatHangID"), 1L, 1);

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoTen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayLap")
                        .HasColumnType("datetime2");

                    b.Property<string>("SoDienThoai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TongTien")
                        .HasColumnType("int");

                    b.HasKey("DatHangID");

                    b.ToTable("DatHang");
                });

            modelBuilder.Entity("webbanvlxd.Models.HinhAnh", b =>
                {
                    b.Property<int>("HinhAnhID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HinhAnhID"), 1L, 1);

                    b.Property<string>("Anh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SanPhamID")
                        .HasColumnType("int");

                    b.HasKey("HinhAnhID");

                    b.HasIndex("SanPhamID");

                    b.ToTable("HinhAnh");
                });

            modelBuilder.Entity("webbanvlxd.Models.LoaiDanhMuc", b =>
                {
                    b.Property<int>("LoaiDanhMucID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoaiDanhMucID"), 1L, 1);

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LoaiDanhMucID");

                    b.ToTable("LoaiDanhMuc");
                });

            modelBuilder.Entity("webbanvlxd.Models.MoTa", b =>
                {
                    b.Property<int>("MoTaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MoTaID"), 1L, 1);

                    b.Property<string>("NoiDungMoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SanPhamID")
                        .HasColumnType("int");

                    b.HasKey("MoTaID");

                    b.ToTable("MoTa");
                });

            modelBuilder.Entity("webbanvlxd.Models.QuyenHan", b =>
                {
                    b.Property<int>("QuyenHanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuyenHanID"), 1L, 1);

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuyenHanID");

                    b.ToTable("QuyenHan");
                });

            modelBuilder.Entity("webbanvlxd.Models.SanPham", b =>
                {
                    b.Property<int>("SanPhamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SanPhamID"), 1L, 1);

                    b.Property<int>("DanhMucID")
                        .HasColumnType("int");

                    b.Property<int>("DonGia")
                        .HasColumnType("int");

                    b.Property<string>("HinhAnh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sale")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<string>("TenSanPham")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ThanhTien")
                        .HasColumnType("int");

                    b.Property<int>("ThuongHieuID")
                        .HasColumnType("int");

                    b.HasKey("SanPhamID");

                    b.HasIndex("DanhMucID");

                    b.HasIndex("ThuongHieuID");

                    b.ToTable("SanPham");
                });

            modelBuilder.Entity("webbanvlxd.Models.TaiKhoan", b =>
                {
                    b.Property<int>("TaiKhoanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaiKhoanID"), 1L, 1);

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoTen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MatKhau")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuyenHanID")
                        .HasColumnType("int");

                    b.Property<string>("SoDienThoai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenTaiKhoan")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaiKhoanID");

                    b.HasIndex("QuyenHanID");

                    b.ToTable("TaiKhoan");
                });

            modelBuilder.Entity("webbanvlxd.Models.ThongSo", b =>
                {
                    b.Property<int>("ThongSoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ThongSoID"), 1L, 1);

                    b.Property<string>("NoiDung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SanPhamID")
                        .HasColumnType("int");

                    b.Property<string>("TenThongSo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ThongSoID");

                    b.ToTable("ThongSo");
                });

            modelBuilder.Entity("webbanvlxd.Models.ThuongHieu", b =>
                {
                    b.Property<int>("ThuongHieuID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ThuongHieuID"), 1L, 1);

                    b.Property<string>("TenThuongHieu")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ThuongHieuID");

                    b.ToTable("ThuongHieu");
                });

            modelBuilder.Entity("webbanvlxd.Models.HinhAnh", b =>
                {
                    b.HasOne("webbanvlxd.Models.SanPham", "SanPham")
                        .WithMany()
                        .HasForeignKey("SanPhamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("webbanvlxd.Models.SanPham", b =>
                {
                    b.HasOne("webbanvlxd.Models.DanhMuc", "DanhMuc")
                        .WithMany()
                        .HasForeignKey("DanhMucID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webbanvlxd.Models.ThuongHieu", "ThuongHieu")
                        .WithMany()
                        .HasForeignKey("ThuongHieuID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DanhMuc");

                    b.Navigation("ThuongHieu");
                });

            modelBuilder.Entity("webbanvlxd.Models.TaiKhoan", b =>
                {
                    b.HasOne("webbanvlxd.Models.QuyenHan", "QuyenHan")
                        .WithMany()
                        .HasForeignKey("QuyenHanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuyenHan");
                });
#pragma warning restore 612, 618
        }
    }
}
