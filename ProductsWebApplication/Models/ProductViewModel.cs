using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductsWebApplication.Models
{
    public class ProductViewModel
    {

        public int Id { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
        [DisplayName("Price")]
        public decimal Price { get; set; }
    }
}
