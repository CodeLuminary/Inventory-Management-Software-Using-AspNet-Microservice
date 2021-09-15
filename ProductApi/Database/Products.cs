using System.ComponentModel.DataAnnotations;

namespace ProductApi.Database
{
    public class Products
    {
        [Key]
        public int productId { get; set; }
    }
}
