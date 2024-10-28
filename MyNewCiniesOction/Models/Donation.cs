using System.ComponentModel.DataAnnotations;

namespace MyNewCiniesOction.Models
{
    public class Donation
    {
        [Key]
        public int DonationId { get; set; }
        public int DonorId { get; set; }
        public Donor Donor { get; set; }
        public int GiftId { get; set; }
        public Gift Gift { get; set; }
    }
}
