using EntityFrameworkCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;

        public ProductController(IProductRepository repo)   // repository içerisine ; private satırındaki IProductRepository den dışardan bir repo alacak.
                                                            //  ctor daki mantık ProductController dan bir nesne üretildiği anda çalışacak olan yapı.
        {
            repository = repo;  // repository nin içerisine dışardan gönderilen repo gelecek.
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List() => View(repository.Products);  // repository gelip view in içerisine repository.Products kullanılacak yapı bu.
                                                                   // Sanal sınıf içerisinden bütün productları aldık.
    }
}
