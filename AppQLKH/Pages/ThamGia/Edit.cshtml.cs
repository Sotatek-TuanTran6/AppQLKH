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

namespace AppQLKH.Pages.ThamGia
{
    public class EditModel : PageModel
    {
        private readonly AppQLKH.Data.AppQLKHContext _context;

        public EditModel(AppQLKH.Data.AppQLKHContext context)
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

            var tham_gia =  await _context.Tham_Gia.FirstOrDefaultAsync(m => m.Id == id);
            if (tham_gia == null)
            {
                return NotFound();
            }
            Tham_Gia = tham_gia;
           ViewData["MaDT"] = new SelectList(_context.De_Tai, "MaDT", "MaDT");
           ViewData["MaGV"] = new SelectList(_context.Giang_Vien, "MaGV", "MaGV");
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

            _context.Attach(Tham_Gia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tham_GiaExists(Tham_Gia.Id))
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

        private bool Tham_GiaExists(int id)
        {
            return _context.Tham_Gia.Any(e => e.Id == id);
        }
    }
}
