using WebApplicationPustok.Models;

namespace WebApplicationPustok.ViewModel.TagVM
{
    public class TagCreateVM
    {
       
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public string ProductCode { get; set; }
        public int Stock { get; set; }
        public IFormFile ImgFile { get; set; }
        public string Description { get; set; }
        public ICollection<TagProduct>? TagProducts { get; set; }
    }
}
