using MyNewCiniesOction.Models;
using System.ComponentModel.DataAnnotations;

namespace MyNewCiniesOction.DTO
{
    public class DonorDTO
    {
        public int DonorId { get; set; }
        public string DonorFirstName { get; set; }
        public string DonorLastName { get; set; }
        [EmailAddress]
        public string DonorEmail { get; set; }
        public string Image { get; set; }
    }
}
