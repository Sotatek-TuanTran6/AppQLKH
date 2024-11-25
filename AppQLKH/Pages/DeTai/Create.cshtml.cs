﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AppQLKH.Data;
using AppQLKH.Models;

namespace AppQLKH.Pages.DeTai
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
            return Page();
        }

        [BindProperty]
        public De_Tai De_Tai { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.De_Tai.Add(De_Tai);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
