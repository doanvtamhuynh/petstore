using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace qlthucung.Models
{
    [Table("KhachHang")]
    public partial class KhachHang
    {
        public KhachHang()
        {
            DanhGia = new HashSet<DanhGium>();
            DichVus = new HashSet<DichVu>();
            DonHangs = new HashSet<DonHang>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("makh")]
        public int Makh { get; set; }
        [Column("hoten")]
        [StringLength(50)]
        public string Hoten { get; set; }
        [Column("tendangnhap")]
        [StringLength(20)]
        public string Tendangnhap { get; set; }
        [Column("matkhau")]
        [StringLength(255)]
        public string Matkhau { get; set; }

        [Column("email")]
        [StringLength(50)]
        public string Email { get; set; }
        [Column("diachi")]
        [StringLength(100)]
        public string Diachi { get; set; }
        [Column("dienthoai")]
        [StringLength(15)]
        public string Dienthoai { get; set; }
        [Column("ngaysinh", TypeName = "date")]
        public DateTime? Ngaysinh { get; set; }
        [Column("RoleID")]
        public int? RoleId { get; set; }
        [Column("status")]
        public int? Status { get; set; }
        [Column("resetpasswordcode")]
        [StringLength(255)]
        public string Resetpasswordcode { get; set; }

        [ForeignKey(nameof(RoleId))]
        [InverseProperty(nameof(KhachHangRole.KhachHangs))]
        public virtual KhachHangRole Role { get; set; }
        [InverseProperty(nameof(DanhGium.IdKhNavigation))]
        public virtual ICollection<DanhGium> DanhGia { get; set; }
        [InverseProperty(nameof(DichVu.MakhNavigation))]
        public virtual ICollection<DichVu> DichVus { get; set; }
        [InverseProperty(nameof(DonHang.MakhNavigation))]
        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
