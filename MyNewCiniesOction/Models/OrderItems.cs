using System.ComponentModel.DataAnnotations;

namespace MyNewCiniesOction.Models
{
    public class OrderItems
    {
        [Key]
        public int OrderItemsId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int GiftId { get; set; }
        public Gift Gift { get; set; }
        public int Amount { get; set; }
    }
}
