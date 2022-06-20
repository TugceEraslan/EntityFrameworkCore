using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Models
{
    public class FakeProductRepository : IProductRepository   // IProductRepository den bunu implemente etmemiz gerekiyor.
    {
        public IQueryable<Product> Products => new List<Product>
        {   // Buraya oluşturduğu metod aracılığı ile kullanıcıya veri göndereceğiz.
            new Product(){ProductId=1,Name="Körlük",Price=50,Category="Roman"},
            new Product(){ProductId=1,Name="İnci",Price=18,Category="Roman"},
            new Product(){ProductId=1,Name="Şekr Portakalı",Price=30.94M,Category="Hikaye"},
            new Product(){ProductId=1,Name="Şiir Mevsimi",Price=14.06M,Category="Şiir"}

        }.AsQueryable(); // Geriye .AsQueryable() tipinde bir veri gönderilecek.
    }
}
