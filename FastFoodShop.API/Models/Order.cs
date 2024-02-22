using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FastFoodShop.API.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int Qty { get; set; }
        public int Price { get; set; }

        [Required]
        [ForeignKey("Items")]
        public int ItemId { get; set; }
        [Column(TypeName = "date")]
        public DateTime date { get; set; }
        public int isdelivered { get; set; }
        public Item? Items { get; set; }

        [Required]
        [ForeignKey("Users")]
        public int UserId { get; set; }
        public User? Users { get; set; }
    }
}
