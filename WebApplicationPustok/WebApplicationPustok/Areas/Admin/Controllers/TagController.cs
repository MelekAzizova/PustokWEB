using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationPustok.Context;
using WebApplicationPustok.Helpers;
using WebApplicationPustok.Models;
using WebApplicationPustok.ViewModel.SliderVM;
using WebApplicationPustok.ViewModel.TagVM;

namespace WebApplicationPustok.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TagController : Controller
    {
        public TagController(PustokDbContext dp)
        {
            _dp = dp;
        }

        PustokDbContext _dp {  get; set; }  

        public async  Task<IActionResult> Index()
        {
            var items = await _dp.Tags.Select(s => new TagListItem
            {
                Id = s.Id,
                Title = s.Title,
                Price = s.Price,
                Brand = s.Brand,
                ProductCode = s.ProductCode,
                Stock = s.Stock,
                ImageUrl = s.ImageUrl,
                Description = s.Description,

            }).ToListAsync();
            return View(items);
           
        }
        public IActionResult Create()
        {

            return View();

        }

        [HttpPost]

        public async Task<IActionResult> Create(TagCreateVM vm)
        {
            if (vm.ImgFile != null)
            {
                if (!vm.ImgFile.IsCorrectType())
                {
                    ModelState.AddModelError("ImageFile", "Wrong file type");
                }
                if (!vm.ImgFile.IsValidSize(20f))
                {
                    ModelState.AddModelError("ImgFile", "Wrong file size");
                }
            }

            if (!ModelState.IsValid)
            {
                return View(vm);
            }


            Tag tag = new Tag
            {
                Title = vm.Title,
                Description = vm.Description,
                ImageUrl = await vm.ImgFile.SaveAsync(PathConstants.Product),
                ProductCode =vm.ProductCode,
                Price=vm.Price,
                Stock=vm.Stock,
                Brand=vm.Brand
                


            };
            await _dp.Tags.AddAsync(tag);
            await _dp.SaveChangesAsync();
            return View();


        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id <= 0) return BadRequest();

            var data = await _dp.Tags.FindAsync(id);
            if (data == null) return NotFound();
            return View(new TagUpdateVM
            {
                Id=data.Id,
                Title = data.Title,
                Description = data.Description,
                ImageUrl = data.ImageUrl,
                Price=data.Price,
                Stock=data.Stock,
                Brand=data.Brand,
                ProductCode=data.ProductCode

            });

        }
        [HttpPost]

        public async Task<IActionResult> Update(int? id, TagUpdateVM vm)
        {
            if (id == null || id <= 0) return BadRequest();
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var data = await _dp.Tags.FindAsync(id);
            if (data == null) return NotFound();
            data.Id = vm.Id;
            data.Title = vm.Title;
            data.Description = vm.Description;
            data.ImageUrl = vm.ImageUrl;
            data.Brand=vm.Brand;
            data.Stock=vm.Stock;
            data.ProductCode=vm.ProductCode;
            data.Price=vm.Price;
            await _dp.SaveChangesAsync();
            return RedirectToAction(nameof(Index));




        }
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null) return BadRequest();

            var data = await _dp.Tags.FindAsync(id);
            if (data == null) return NotFound();
            _dp.Tags.Remove(data);
            await _dp.SaveChangesAsync();
            //TempData["Response"] = new
            //{
            //    Icon = "Success",
            //    Title = "Data deleted succesfully"

            //};
            return RedirectToAction(nameof(Index));

        }
    }
}
