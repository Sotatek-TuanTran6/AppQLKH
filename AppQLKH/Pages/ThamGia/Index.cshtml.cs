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
    public class IndexModel : PageModel
    {
        private readonly AppQLKH.Data.AppQLKHContext _context;

        public IndexModel(AppQLKH.Data.AppQLKHContext context)
        {
            _context = context;
        }

        public IList<Tham_Gia> Tham_Gia { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Tham_Gia = await _context.Tham_Gia
                .Include(t => t.DeTai)
                .Include(t => t.GiangVien).ToListAsync();
        }
    }
}
