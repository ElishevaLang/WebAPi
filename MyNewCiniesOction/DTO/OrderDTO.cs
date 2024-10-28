using System.ComponentModel.DataAnnotations;

namespace MyNewCiniesOction.DTO
{
    public class OrderDTO
    {
        public int UserId { get; set; }
        public int OrderSum { get; set; }
        public int OrederSumItems { get; set; }

    }
}
