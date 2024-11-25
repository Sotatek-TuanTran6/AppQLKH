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
    public class IndexModel : PageModel
    {
        private readonly AppQLKH.Data.AppQLKHContext _context;

        public IndexModel(AppQLKH.Data.AppQLKHContext context)
        {
            _context = context;
        }

        public IList<De_Tai> De_Tai { get;set; } = default!;

        public async Task OnGetAsync()
        {
            De_Tai = await _context.De_Tai.ToListAsync();
        }
    }
}
