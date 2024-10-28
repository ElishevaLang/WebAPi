using MyNewCiniesOction.DTO;
using MyNewCiniesOction.Models;

namespace MyNewCiniesOction.DAL
{
    public interface ICartDal
    {
        public Task<List<Cart>> GetCart();
        public Task<bool> DeleteCart(int cartId);
        public Task<bool> PostCart(Cart cart);
        public Task<bool> PutCart(Cart cart);
        public Task<List<Cart>> GetByUserId(int userId);
        public Task<bool> DeleteAllCart(int userId);
    }
}
