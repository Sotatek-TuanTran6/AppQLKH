using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AppQLKH.Data;
using AppQLKH.Models;

namespace AppQLKH.Pages.ThamGia
{
    public class CreateModel : PageModel
    {
        private readonly AppQLKH.Data.AppQLKHContext _context;

        public CreateModel(AppQLKH.Data.AppQLKHContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["MaDT"] = new SelectList(_context.De_Tai, "MaDT", "MaDT");
        ViewData["MaGV"] = new SelectList(_context.Giang_Vien, "MaGV", "MaGV");
            return Page();
        }

        [BindProperty]
        public Tham_Gia Tham_Gia { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Tham_Gia.Add(Tham_Gia);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
