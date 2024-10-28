using MyNewCiniesOction.Models;
using System.ComponentModel.DataAnnotations;

namespace MyNewCiniesOction.DTO
{
    public class GiftDTO
    {
        public int GiftId { get; set; }
        public string GiftName { get; set; }
        public int CategoryId { get; set; }
        public string GiftDescription { get; set; }
        public int GiftPrice { get; set; }
        public string GiftImage { get; set; }

    }
}
