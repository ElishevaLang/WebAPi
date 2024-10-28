using System.ComponentModel.DataAnnotations;

namespace MyNewCiniesOction.Models
{
    public enum TypeOfDonate { Money, Gift }
    public class Donor
    {
        [Key]
        public int DonorId { get; set; }
        public string DonorFirstName { get; set; }
        public string DonorLastName { get; set; }
        [EmailAddress]
        public string DonorEmail { get; set; }
        public TypeOfDonate TypeOfDonate { get; set; }
        public string Image { get; set; }
    }
}
