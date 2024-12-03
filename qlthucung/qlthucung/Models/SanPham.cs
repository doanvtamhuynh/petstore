using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace qlthucung.Models
{
    [Table("SanPham")]
    public partial class SanPham
    {
        public SanPham()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
            DanhGia = new HashSet<DanhGium>();
        }
        
        [Key]
        [Column("masp")]
        //[Required(ErrorMessage = "Mã SP phải được khai báo")]
        public int Masp { get; set; }

        [Column("idDanhmuc")]
        //[Required(ErrorMessage = "Chưa chọn danh mục")]
        public int? IdDanhmuc { get; set; }

        [Column("idthuvien")]
        public int? Idthuvien { get; set; }

        [Column("tensp")]
        public string Tensp { get; set; }

        [Column("hinh")]
        [StringLength(255)]
        public string Hinh { get; set; }

        [Column("giaban", TypeName = "decimal(18, 0)")]
        public decimal? Giaban { get; set; }

        [Column("ngaycapnhat", TypeName = "smalldatetime")]
        //[Required(ErrorMessage = "Ngày cập nhập không được để trống")]
        public DateTime? Ngaycapnhat { get; set; }

        [Column("soluongton")]
        public int? Soluongton { get; set; }

        [Column("mota")]
        [StringLength(500, ErrorMessage = "Mô tả ko hơn 500 kí tự")]
        public string Mota { get; set; }

        [Column("giamgia")]
        public int? Giamgia { get; set; }

        [Column("giakhuyenmai", TypeName = "decimal(18, 0)")]
        public decimal? Giakhuyenmai { get; set; }

        [ForeignKey(nameof(IdDanhmuc))]
        [InverseProperty(nameof(DanhMuc.SanPhams))]
        public virtual DanhMuc IdDanhmucNavigation { get; set; }
        [ForeignKey(nameof(Idthuvien))]
        [InverseProperty(nameof(ThuVienAnh.SanPhams))]
        public virtual ThuVienAnh IdthuvienNavigation { get; set; }
        [InverseProperty(nameof(ChiTietDonHang.MaspNavigation))]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
        [InverseProperty(nameof(DanhGium.IdSpNavigation))]
        public virtual ICollection<DanhGium> DanhGia { get; set; }
    }
}
