using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace qlthucung.Models
{
    public partial class KhachHangRole
    {
        public KhachHangRole()
        {
            KhachHangs = new HashSet<KhachHang>();
        }

        [Key]
        [Column("RoleID")]
        public int RoleId { get; set; }
        [StringLength(30)]
        public string RoleName { get; set; }

        [InverseProperty(nameof(KhachHang.Role))]
        public virtual ICollection<KhachHang> KhachHangs { get; set; }
    }
}
