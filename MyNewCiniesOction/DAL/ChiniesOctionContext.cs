using Microsoft.EntityFrameworkCore;
using MyNewCiniesOction.Models;

namespace MyNewCiniesOction.DAL
{
    public class ChiniesOctionContext: DbContext
    {
        public ChiniesOctionContext(DbContextOptions<ChiniesOctionContext> options) : base(options) { }

        public DbSet<Cart> Cart { get; set; }
        public DbSet<Donor> Donor { get; set; }
        public DbSet<Gift> Gift { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Raffle> Raffle { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Donation> Donation { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Winning> Winning { get; set; }
    }
}
