using System.ComponentModel.DataAnnotations;

namespace MyNewCiniesOction.Models
{
    public class Gift
    {
        [Key]
        public int GiftId { get; set; }
        public string GiftName { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string GiftDescription { get; set; }
        public int GiftPrice { get; set; }
        public string GiftImage { get; set; }
    }
}
