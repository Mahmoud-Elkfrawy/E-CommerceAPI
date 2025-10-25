using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Depitest.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public string Description { get; set; }
        public int quantity { get; set; }
        public string ImageAddress { get; set; }

        [ForeignKey("Categoray")]
        public int CategoryId { get; set; }
        public Categoray Categoray { get; set; }
    }
}
