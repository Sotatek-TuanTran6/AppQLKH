using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppQLKH.Data;
using AppQLKH.Models;

namespace AppQLKH.Pages.GiangVien
{
    public class EditModel : PageModel
    {
        private readonly AppQLKH.Data.AppQLKHContext _context;

        public EditModel(AppQLKH.Data.AppQLKHContext context)
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

            var giangvien =  await _context.Giang_Vien.FirstOrDefaultAsync(m => m.MaGV == id);
            if (giangvien == null)
            {
                return NotFound();
            }
            GiangVien = giangvien;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(GiangVien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GiangVienExists(GiangVien.MaGV))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GiangVienExists(string id)
        {
            return _context.Giang_Vien.Any(e => e.MaGV == id);
        }
    }
}
