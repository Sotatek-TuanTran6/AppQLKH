using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppQLKH.Data;
using AppQLKH.Models;

namespace AppQLKH.Pages.DeTai
{
    public class DeleteModel : PageModel
    {
        private readonly AppQLKH.Data.AppQLKHContext _context;

        public DeleteModel(AppQLKH.Data.AppQLKHContext context)
        {
            _context = context;
        }

        [BindProperty]
        public De_Tai De_Tai { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var de_tai = await _context.De_Tai.FirstOrDefaultAsync(m => m.MaDT == id);

            if (de_tai == null)
            {
                return NotFound();
            }
            else
            {
                De_Tai = de_tai;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var de_tai = await _context.De_Tai.FindAsync(id);
            if (de_tai != null)
            {
                De_Tai = de_tai;
                _context.De_Tai.Remove(De_Tai);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
