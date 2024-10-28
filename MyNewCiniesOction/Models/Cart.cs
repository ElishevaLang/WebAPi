using System.ComponentModel.DataAnnotations;

namespace MyNewCiniesOction.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int GiftId { get; set; }
        public Gift Gift { get; set; }
        public int Quantity { get; set; }


    }
}
