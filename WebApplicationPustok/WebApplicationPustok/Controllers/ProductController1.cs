using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationPustok.Context;
using WebApplicationPustok.Helpers;
using WebApplicationPustok.ViewModel.ProductVM;

namespace WebApplicationPustok.Controllers
{
    public class ProductController1 : Controller
    {
        public ProductController1(PustokDbContext db)
        {
            _db = db;
        }

        PustokDbContext _db {  get;  }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Details(int? id)
        {
            return  View(await _db.Products.Select( s=> new ProductListVM
            {
                Id = s.Id,
                Name = s.Name,
                Title = s.Title,
                Description = s.Description,
                SellPrice = (s.SellPrice - (s.SellPrice * (decimal)s.Discount) / 100),
                Discount = s.Discount,
                Quantity = s.Quantity,
                ProductCode = s.ProductCode,
                IsDeleted = s.IsDeleted,
                Category = s.Category,
                ImageUrls=s.ProductImages.Select(s=>s.ImageUrl).ToList(),
                ImgFile =s.ImagrUrl

            }). ToListAsync());
            
        }
    }
}
