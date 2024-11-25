using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppQLKH.Models;

namespace AppQLKH.Data
{
    public class AppQLKHContext : DbContext
    {
        public AppQLKHContext (DbContextOptions<AppQLKHContext> options)
            : base(options)
        {
        }

        public DbSet<AppQLKH.Models.Giang_Vien> Giang_Vien { get; set; } = default!;
        public DbSet<AppQLKH.Models.De_Tai> De_Tai { get; set; } = default!;
        public DbSet<AppQLKH.Models.Tham_Gia> Tham_Gia { get; set; } = default!;
    }
}
