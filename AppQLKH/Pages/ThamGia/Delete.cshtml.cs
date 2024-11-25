using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppQLKH.Data;
using AppQLKH.Models;

namespace AppQLKH.Pages.ThamGia
{
    public class DeleteModel : PageModel
    {
        private readonly AppQLKH.Data.AppQLKHContext _context;

        public DeleteModel(AppQLKH.Data.AppQLKHContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tham_Gia Tham_Gia { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tham_gia = await _context.Tham_Gia.FirstOrDefaultAsync(m => m.Id == id);

            if (tham_gia == null)
            {
                return NotFound();
            }
            else
            {
                Tham_Gia = tham_gia;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tham_gia = await _context.Tham_Gia.FindAsync(id);
            if (tham_gia != null)
            {
                Tham_Gia = tham_gia;
                _context.Tham_Gia.Remove(Tham_Gia);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
