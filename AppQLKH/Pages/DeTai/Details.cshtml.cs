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
    public class DetailsModel : PageModel
    {
        private readonly AppQLKH.Data.AppQLKHContext _context;

        public DetailsModel(AppQLKH.Data.AppQLKHContext context)
        {
            _context = context;
        }

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
    }
}
