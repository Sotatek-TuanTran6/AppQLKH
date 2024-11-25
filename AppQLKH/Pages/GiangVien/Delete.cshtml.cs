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
    public class DeleteModel : PageModel
    {
        private readonly AppQLKH.Data.AppQLKHContext _context;

        public DeleteModel(AppQLKH.Data.AppQLKHContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giangvien = await _context.Giang_Vien.FindAsync(id);
            if (giangvien != null)
            {
                GiangVien = giangvien;
                _context.Giang_Vien.Remove(GiangVien);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
