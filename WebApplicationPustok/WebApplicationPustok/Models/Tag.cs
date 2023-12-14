using System.Data;

namespace WebApplicationPustok.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public string ProductCode { get; set; }
        public int Stock {  get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public ICollection<TagProduct>? TagProducts { get; set; }
        
    }
}
