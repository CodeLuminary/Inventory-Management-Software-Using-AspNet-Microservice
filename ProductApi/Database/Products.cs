using System.ComponentModel.DataAnnotations;

namespace ProductApi.Database
{
    public class Products
    {
        [Key]
        public int productId { get; set; }
        public string productName { get; set; }
        public int productQuantity { get; set; }
        public double costPrice { get; set; }
        public double sellingPrice { get; set; }
        public string productDescription { get; set; }
    }
}
