using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using qlthucung.Models;

namespace qlthucung.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly AppDbContext _context;

        public SanPhamController(AppDbContext context)
        {
            _context = context;
        }

        // GET: All SanPham
        public async Task<IActionResult> Index()
        {
            var sanpham = await _context.SanPhams.Take(12).ToListAsync();

            getSPNoiBat();
            getSPChoCho3();
            getSPChoCho4();
            getSPChoCho5();

            getSPChoMeo6();
            getSPChoMeo7();
            getSPChoMeo8();

            return View(sanpham);
        }

        //cac ham lay ra san pham
        #region
        //lay san pham noi bat
        private void getSPNoiBat()
        {
            var list = (from c in _context.SanPhams select c)
                .Take(10).ToList();
            ViewBag.getSPNoiBat = list;
        }
        //lay san pham cho chó có danh mục đồ ăn 3
        private void getSPChoCho3()
        {
            var list = (from c in _context.SanPhams select c).Where(n => n.IdDanhmuc == 3)
                .Take(10).ToList();
            ViewBag.getSPChoCho3 = list;
        }
        //lay san pham cho chó có danh mục phụ kiện 4
        private void getSPChoCho4()
        {
            var list = (from c in _context.SanPhams select c).Where(n => n.IdDanhmuc == 4)
                .Take(10).ToList();
            ViewBag.getSPChoCho4 = list;
        }
        //lay san pham cho chó có danh mục vật dụng 5
        private void getSPChoCho5()
        {
            var list = (from c in _context.SanPhams select c).Where(n => n.IdDanhmuc == 5)
                .Take(10).ToList();
            ViewBag.getSPChoCho5 = list;
        }
        //lay san pham cho mèo có danh mục đồ ăn 6
        private void getSPChoMeo6()
        {
            var list = (from c in _context.SanPhams select c).Where(n => n.IdDanhmuc == 6)
                .Take(10).ToList();
            ViewBag.getSPChoMeo6 = list;
        }
        //lay san pham cho mèo có danh mục phụ kiện 7
        private void getSPChoMeo7()
        {
            var list = (from c in _context.SanPhams select c).Where(n => n.IdDanhmuc == 7)
                .Take(10).ToList();
            ViewBag.getSPChoMeo7 = list;
        }
        //lay san pham cho mèo có danh mục vật dụng 8
        private void getSPChoMeo8()
        {
            var list = (from c in _context.SanPhams select c).Where(n => n.IdDanhmuc == 8)
                .Take(10).ToList();
            ViewBag.getSPChoMeo8 = list;
        }
        #endregion

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sanpham = await _context.SanPhams.FirstOrDefaultAsync(m => m.Masp == id);
            if (sanpham == null)
            {
                return NotFound();
            }

            //random san pham
                List<SanPham> products = _context.SanPhams.OrderBy(x => Guid.NewGuid()).Take(5).ToList();
                ViewBag.getSPRanDom = products;

            getThuVienAnhList(id);

            return View(sanpham);
        }

        private void getThuVienAnhList(int? id)
        {

            //sp vs thu vien anh
            List<SanPham> sanpham = _context.SanPhams.ToList();
            List<ThuVienAnh> thuvienanh = _context.ThuVienAnhs.ToList();
            var thu = from sp in sanpham
                      join tv in thuvienanh
                              on sp.Idthuvien equals tv.Idthuvien
                      where (sp.Masp == id && sp.Idthuvien == tv.Idthuvien)
                      select new ViewModel
                      {
                          sanpham = sp,
                          thuvienanh = tv
                      };

            ViewBag.getthuvienanh = thu;

        }

        [HttpGet]
        public async Task<IActionResult> Search(string search)
        {
            var searchProduct = from m in _context.SanPhams
                         select m;

            if (!String.IsNullOrEmpty(search))
            {
                searchProduct = searchProduct.Where(s => s.Tensp.Contains(search));
                if (!searchProduct.Any())
                {
                    TempData["nameProduct"] = search;
                    return RedirectToAction("NotFoundProduct", "SanPham");
                }
            }
            else
            {
                return RedirectToAction("NotFoundProduct", "SanPham");
            }

            TempData["nameProduct"] = search;
            return View(await searchProduct.ToListAsync());
        }

        public IActionResult NotFoundProduct()
        {
            return View();
        }

        public async Task<IActionResult> TatCaSanPham(int? pageNumber)
        {
            const int pageSize = 5;

            var products = _context.SanPhams.AsNoTracking();
            var paginatedProducts = await PaginatedList<SanPham>.CreateAsync(products, pageNumber ?? 1, pageSize);

            return View(paginatedProducts);
        }


    }
}
