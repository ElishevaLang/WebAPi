using System.ComponentModel.DataAnnotations;

namespace MyNewCiniesOction.Models
{
    public class Raffle
    {
        [Key]
        public int RaffleId { get; set; }
        public DateTime RaffleDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int GiftId { get; set; }
        public Gift Gift { get; set; }

        public Raffle(int userId, int giftId)
        {
            this.RaffleDate = DateTime.Now;
            this.UserId = userId;
            this.GiftId = giftId;
        }
        
      
    }
}
