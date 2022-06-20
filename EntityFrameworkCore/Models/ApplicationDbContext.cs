using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Models
{
    public class ApplicationDbContext:DbContext   // DbContext imiz tanıttıktan sonra DbSet lerimizi tanıtabiliriz
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
             :base(options)  // options ı base e gönderelim
        {

        }

        public DbSet<Product> Products { get; set; }  // Veritabanında bir tablo oluşturduk. Tabloya tamamen Products nesnesi üzerinden ulaşabiliriz.
    }
}
