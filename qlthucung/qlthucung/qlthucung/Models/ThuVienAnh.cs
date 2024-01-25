using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace qlthucung.Models
{
    [Table("ThuVienAnh")]
    public partial class ThuVienAnh
    {
        public ThuVienAnh()
        {
            SanPhams = new HashSet<SanPham>();
        }

        [Key]
        [Column("idthuvien")]
        public int Idthuvien { get; set; }
        [Column("img1")]
        [StringLength(255)]
        public string Img1 { get; set; }
        [Column("img2")]
        [StringLength(255)]
        public string Img2 { get; set; }
        [Column("img3")]
        [StringLength(255)]
        public string Img3 { get; set; }

        [InverseProperty(nameof(SanPham.IdthuvienNavigation))]
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
