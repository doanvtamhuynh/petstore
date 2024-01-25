using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace qlthucung.Models
{
    public partial class DanhGium
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public double? Rating { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Ngaycapnhap { get; set; }
        [Column("trangthai")]
        public int? Trangthai { get; set; }
        [Column("id_sp")]
        public int? IdSp { get; set; }
        [Column("id_kh")]
        public int? IdKh { get; set; }

        [ForeignKey(nameof(IdKh))]
        [InverseProperty(nameof(KhachHang.DanhGia))]
        public virtual KhachHang IdKhNavigation { get; set; }
        [ForeignKey(nameof(IdSp))]
        [InverseProperty(nameof(SanPham.DanhGia))]
        public virtual SanPham IdSpNavigation { get; set; }
    }
}
