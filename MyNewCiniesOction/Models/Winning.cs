namespace MyNewCiniesOction.Models
{
    public class Winning
    {
        public int WinningId { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public int GiftId { get; set; }

        public Gift Gift { get; set; }
    }
}
