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

namespace AppQLKH.Pages.DeTai
{
    public class EditModel : PageModel
    {
        private readonly AppQLKH.Data.AppQLKHContext _context;

        public EditModel(AppQLKH.Data.AppQLKHContext context)
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

            var de_tai =  await _context.De_Tai.FirstOrDefaultAsync(m => m.MaDT == id);
            if (de_tai == null)
            {
                return NotFound();
            }
            De_Tai = de_tai;
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

            _context.Attach(De_Tai).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!De_TaiExists(De_Tai.MaDT))
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

        private bool De_TaiExists(string id)
        {
            return _context.De_Tai.Any(e => e.MaDT == id);
        }
    }
}
