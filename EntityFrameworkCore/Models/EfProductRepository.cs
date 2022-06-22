using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Models
{
    public class EfProductRepository : IProductRepository  // IProductRepository den implemente etmemiz gerekiyor.
    {
        private ApplicationDbContext _context;  
        public EfProductRepository(ApplicationDbContext context)  // Dışardan ApplicationDbContext'i alıp aşağıdaki gibi oluşturalım.
        {
            _context = context;
        }
        public IQueryable<Product> Products => _context.Products;  // Bura da Products nesnesini çağırdıkların da _context aracılğı ile Products ı geri döndüreceğim.
    }
}
