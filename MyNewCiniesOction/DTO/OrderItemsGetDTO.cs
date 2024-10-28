using MyNewCiniesOction.Models;

namespace MyNewCiniesOction.DTO
{
    public class OrderItemsGetDTO
    {
        public int orderItemsId { get; set; }
        public Order order { get; set; }
        public User user { get; set; }
        public Gift gift { get; set; }

    }
}
