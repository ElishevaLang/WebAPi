using System.ComponentModel.DataAnnotations;

namespace MyNewCiniesOction.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderSum { get; set; }
        public int OrederSumItems { get; set; }
    }
}
