using MyNewCiniesOction.DAL;
using MyNewCiniesOction.DTO;
using MyNewCiniesOction.Models;

namespace MyNewCiniesOction.BL
{
    public class CartService :ICartService
    {
        private readonly ICartDal _cartDal;
        public CartService(ICartDal cartDal)
        {
            _cartDal = cartDal;
        }
        public async Task<List<Cart>> GetCart()
        {
            return await _cartDal.GetCart();
        }

        public async Task<bool> PostCart(Cart cart)
        {
            List<Cart> cartListOfuser = await _cartDal.GetByUserId(cart.UserId);

            Cart currentCart = cartListOfuser.Find(c => c.GiftId==cart.GiftId);
            if (currentCart != null)
            {
                return await _cartDal.PutCart(cart);
            }
            else
            {
                return await _cartDal.PostCart(cart);
            }
        }

        public async Task<bool> DeleteCart(int cartId)
        {
            return await _cartDal.DeleteCart(cartId);
        }
        public  async Task<List<Cart>> GetByUserId(int userId)
        {
            return await _cartDal.GetByUserId(userId);
        }
        public async Task<bool> DeleteAllCart(int userId)
        {
            return await _cartDal.DeleteAllCart(userId);
        }

    }
}
