using MyNewCiniesOction.Models;

namespace MyNewCiniesOction.DTO
{
    public class RaffleDTO
    {
        public int RaffleId { get; set; }
        public DateTime RaffleDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int GiftId { get; set; }
        public Gift Gift { get; set; }
      
    }
}
