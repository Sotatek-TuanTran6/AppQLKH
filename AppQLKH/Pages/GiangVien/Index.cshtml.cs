using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppQLKH.Data;
using AppQLKH.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AppQLKH.Pages.GiangVien
{
    public class IndexModel : PageModel
    {
        private readonly AppQLKH.Data.AppQLKHContext _context;

        public IndexModel(AppQLKH.Data.AppQLKHContext context)
        {
            _context = context;
        }

        public IList<Giang_Vien> GiangVien { get; set; } = default!;
        public IList<Giang_Vien> GiangVien1 { get; set; } = default!;
        public IList<Giang_Vien> GiangVien2 { get; set; } = default!;
        public IList<Giang_Vien> GiangVien3 { get; set; } = default!;
        public IList<Giang_Vien> GiangVien4 { get; set; } = default!;

        public async Task OnGetAsync()
        {

            GiangVien = await _context.Giang_Vien.ToListAsync();

            GiangVien1 = await (from gv in _context.Giang_Vien
                                where gv.DiaChi.Contains("Hai Bà Trưng")
                                orderby gv.HoTen descending
                                select gv).ToListAsync();

            GiangVien2 = await _context.Tham_Gia
                .Where(tg => tg.MaGV != null && tg.MaDT != null)
                                .Join(_context.Giang_Vien, tg => tg.MaGV, gv => gv.MaGV, (tg, gv) => new { tg, gv })
                                .Join(_context.De_Tai,
                                tg_gv => tg_gv.tg.MaDT,
                                dt => dt.MaDT,
                                (tg_gv, dt) => new { tg_gv.gv, dt })
                                .Where(tg_gv_dt => tg_gv_dt.dt.TenDT == "Tính toán lưới")
                                .Select(tg_gv_dt => tg_gv_dt.gv)
                                .ToListAsync();




            GiangVien3 = await _context.Tham_Gia
                .Where(tg => tg.MaGV != null && tg.MaDT != null)
                                .Join(_context.Giang_Vien, tg => tg.MaGV, gv => gv.MaGV, (tg, gv) => new { tg, gv })
                                .Join(_context.De_Tai,
                                tg_gv => tg_gv.tg.MaDT,
                                dt => dt.MaDT,
                                (tg_gv, dt) => new { tg_gv.gv, dt })
                                .Where(tg_gv_dt => tg_gv_dt.dt.TenDT == "Phân loại văn bản" || tg_gv_dt.dt.TenDT == "Dịch tự động Anh Việt")
                                .Select(tg_gv_dt => tg_gv_dt.gv)
                                .ToListAsync();

            //GiangVien3.Select(x => x.HoTen);
            // select x.Hoten from Giangvien3
        }
    }
}
