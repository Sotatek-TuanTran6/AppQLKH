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
    public class DetailsModel : PageModel
    {
        private readonly AppQLKH.Data.AppQLKHContext _context;

        public DetailsModel(AppQLKH.Data.AppQLKHContext context)
        {
            _context = context;
        }

        public Giang_Vien GiangVien { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giangvien = await _context.Giang_Vien.FirstOrDefaultAsync(m => m.MaGV == id);
            if (giangvien == null)
            {
                return NotFound();
            }
            else
            {
                GiangVien = giangvien;
            }
            return Page();
        }
    }
}
