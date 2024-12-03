using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace qlthucung.Models
{
    [Table("DichVu")]
    public partial class DichVu
    {
        [Key]
        [Column("iddichvu")]
        public int Iddichvu { get; set; }
        [Column("hoten")]
        [StringLength(30)]
        public string Hoten { get; set; }
        [Column("email")]
        [StringLength(30)]
        public string Email { get; set; }
        [Column("sdt")]
        [StringLength(30)]
        public string Sdt { get; set; }
        [Column("diachi")]
        [StringLength(30)]
        public string Diachi { get; set; }
        [Column("trangthai")]
        [StringLength(30)]
        public string Trangthai { get; set; }
        [Column("tendichvu")]
        [StringLength(30)]
        public string Tendichvu { get; set; }
        [Column("ngaydat", TypeName = "datetime")]
        public DateTime? Ngaydat { get; set; }
        [Column("makh")]
        public int? Makh { get; set; }

        [ForeignKey(nameof(Makh))]
        [InverseProperty(nameof(KhachHang.DichVus))]
        public virtual KhachHang MakhNavigation { get; set; }
    }
}
