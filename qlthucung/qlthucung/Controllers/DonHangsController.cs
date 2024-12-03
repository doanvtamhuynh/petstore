using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using qlthucung.Models;

namespace qlthucung.Controllers
{
    public class DonHangsController : Controller
    {
        private readonly AppDbContext _context;

        public DonHangsController(AppDbContext context)
        {
            _context = context;
        }


        // GET: DonHangs/Details/5
        public IActionResult Details()
        {
            var donHang = from dh in _context.DonHangs
                          join kh in _context.KhachHangs on dh.Makh equals kh.Makh
                          where kh.Tendangnhap == HttpContext.Session.GetString("username")
                          select dh;
            return View(donHang);
        }

      public ActionResult ChiTietDonHang(int id)
        {
            var results = (from t1 in _context.ChiTietDonHangs
                           join t2 in _context.DonHangs
                           on new { t1.Madon } equals
                               new { t2.Madon }
                           where t2.Madon == id
                           select t1).ToList();

            List<KhachHang> khachhang = _context.KhachHangs.ToList();
            List<DonHang> donhang = _context.DonHangs.ToList();
            List<ChiTietDonHang> ctdh = _context.ChiTietDonHangs.ToList();
            List<SanPham> sanpham = _context.SanPhams.ToList();

            var ViewKH2 = from kh in khachhang
                          join dh in donhang on kh.Makh equals dh.Makh
                          where dh.Madon == id && kh.Makh == dh.Makh
                          select new ViewModel
                          {
                              khachhang = kh,
                              donhang = dh
                          };

            var ViewSP = from ct in ctdh
                         join sp in sanpham on ct.Masp equals sp.Masp
                         join dh in donhang on ct.Madon equals dh.Madon
                         where ct.Madon == id && sp.Masp == ct.Masp && ct.Madon == dh.Madon

                         select new ViewModel
                         {
                             sanpham = sp,
                             ctdh = ct,
                             donhang = dh
                         };

            ViewBag.ViewChiTietDH2 = ViewKH2;
            ViewBag.ViewSP = ViewSP;
            return View(results);
        }
    }
}
