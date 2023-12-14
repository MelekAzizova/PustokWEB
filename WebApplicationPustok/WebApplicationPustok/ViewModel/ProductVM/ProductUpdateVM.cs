using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApplicationPustok.Models;

namespace WebApplicationPustok.ViewModel.ProductVM
{
    public class ProductUpdateVM
    {
        [MaxLength(64)]
        public string Name { get; set; }
        [MaxLength(128)]
        public string Title { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "smallmoney")]
        public decimal SellPrice { get; set; }
        [Column(TypeName = "smallmoney")]
        public decimal CostPrice { get; set; }
        [Range(0, 100)]
        public float Discount { get; set; }
        public ushort Quantity { get; set; }
       
        public string ProductCode { get; set; }

      // public IFormFile Image {  get; set; }
       // public List<ProductImages> productImages { get; set; }
        public int CategoryId { get; set; }
    }
}
