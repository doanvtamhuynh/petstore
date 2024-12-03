using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace qlthucung.Models
{
    [Table("ChiTietDonHang")]
    public partial class ChiTietDonHang
    {
        [Key]
        [Column("madon")]
        public int Madon { get; set; }
        [Key]
        [Column("masp")]
        public int Masp { get; set; }
        [Column("soluong")]
        public int? Soluong { get; set; }
        [Column("gia", TypeName = "decimal(18, 0)")]
        public decimal? Gia { get; set; }
        [Column("tongsoluong")]
        public int? Tongsoluong { get; set; }
        [Column("tonggia", TypeName = "decimal(18, 0)")]
        public decimal? Tonggia { get; set; }
        [Column("status")]
        public int? Status { get; set; }

        [ForeignKey(nameof(Madon))]
        [InverseProperty(nameof(DonHang.ChiTietDonHangs))]
        public virtual DonHang MadonNavigation { get; set; }
        [ForeignKey(nameof(Masp))]
        [InverseProperty(nameof(SanPham.ChiTietDonHangs))]
        public virtual SanPham MaspNavigation { get; set; }
    }
}
