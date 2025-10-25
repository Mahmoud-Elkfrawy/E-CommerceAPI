using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Depitest.Model
{
    public class Categoray
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        List<Product> Productss { get; set; }

    }
}
