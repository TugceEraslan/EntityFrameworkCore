using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Models
{
    public interface IProductRepository
    {        
        IQueryable<Product> Products  { get; }  // Veri tipi IQueryable ve tipi Product olsun. {set;} kısmını kaldırdım. İnterface olduğu için bşında erişim belirteci yok.
                                                // Sadece okunabilir olsun.
    // Interface i sadece şema olarak ayarladık.
    // Product isimli bir sınıfım olacak ve bu sınıf bu yapıyı kullanarak verileri veritabanından getirecek.
    // Interface i bu amaçla kullanıyoruz.
    }
}
