using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace qlthucung.Models
{
    [Table("DonHang")]
    public partial class DonHang
    {
        public DonHang()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
        }

        [Key]
        [Column("madon")]
        public int Madon { get; set; }
        [Column("thanhtoan")]
        [StringLength(50)]
        public string Thanhtoan { get; set; }
        [Column("giaohang")]
        [StringLength(255)]
        public string Giaohang { get; set; }
        [Column("ngaydat", TypeName = "date")]
        public DateTime? Ngaydat { get; set; }
        [Column("ngaygiao", TypeName = "date")]
        public DateTime? Ngaygiao { get; set; }
        [Column("makh")]
        public int? Makh { get; set; }

        [ForeignKey(nameof(Makh))]
        [InverseProperty(nameof(KhachHang.DonHangs))]
        public virtual KhachHang MakhNavigation { get; set; }
        [InverseProperty(nameof(ChiTietDonHang.MadonNavigation))]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
    }
}
