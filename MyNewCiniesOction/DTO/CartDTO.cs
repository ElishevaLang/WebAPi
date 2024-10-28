using MyNewCiniesOction.Models;

namespace MyNewCiniesOction.DTO
{
    public class CartDTO
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public int GiftId { get; set; }
        public int Quantity { get; set; }
        
    }
}
