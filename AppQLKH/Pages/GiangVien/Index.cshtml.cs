using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppQLKH.Data;
using AppQLKH.Models;

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

        public async Task OnGetAsync()
        {

            GiangVien = await _context.Giang_Vien.ToListAsync();

            GiangVien1 = await _context.Giang_Vien // Lọc giảng viên có địa chỉ chứa "Hai Bà Trưng", sắp xếp tên giảm dần
        .Where(gv => gv.DiaChi.Contains("Hai Bà Trưng")) 
        .OrderByDescending(gv => gv.HoTen)              
        .ToListAsync();

            GiangVien2 = await (from tg in _context.Tham_Gia
                                           join gv in _context.Giang_Vien on tg.MaGV equals gv.MaGV
                                           join dt in _context.De_Tai on tg.MaDT equals dt.MaDT
                                           where dt.TenDT == "Tính toán lưới"
                                           select gv).ToListAsync();

            GiangVien3 = await (from tg in _context.Tham_Gia
                                join gv in _context.Giang_Vien on tg.MaGV equals gv.MaGV
                                join dt in _context.De_Tai on tg.MaDT equals dt.MaDT
                                where dt.TenDT == "Phân loại văn bản" orderby dt.TenDT == "Dịch tự động Anh Việt"
                                select gv).ToListAsync();
            GiangVien3.Select(x => x.HoTen);
            // select x.Hoten from Giangvien3
        }
    }
}
