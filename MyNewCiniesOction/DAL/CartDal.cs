using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyNewCiniesOction.BL;
using MyNewCiniesOction.DAL;
using MyNewCiniesOction.DTO;
using MyNewCiniesOction.Migrations;
using MyNewCiniesOction.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace MyNewCiniesOction.DAL
{
    public class CartDal:ICartDal
    {
        private readonly IMapper _mapper;
     
        private readonly ChiniesOctionContext _chiniesOctionContext;
        public CartDal(ChiniesOctionContext chiniesOctionContext, IMapper mapper)
        {
            _mapper = mapper;
            this._chiniesOctionContext = chiniesOctionContext ?? throw new ArgumentNullException(nameof(chiniesOctionContext));
        }
        public async Task<bool> DeleteCart(int cartId)
        {
            try {
            var cart = await _chiniesOctionContext.Cart.FindAsync(cartId);
                if (cart.Quantity > 1)
                {
                    cart.Quantity--;
                    _chiniesOctionContext.Cart.Update(cart);
                    await _chiniesOctionContext.SaveChangesAsync();
                    return true;
                }
                else
                {               
                    _chiniesOctionContext.Cart.Remove(cart);
                    await _chiniesOctionContext.SaveChangesAsync();
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteAllCart(int userId)
        {
            try
            {
               await _chiniesOctionContext.Cart.ForEachAsync( async e =>
                {
                    if (e.UserId == userId)
                         _chiniesOctionContext.Cart.Remove(e);
                });
                await _chiniesOctionContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Cart>> GetCart()
        {
            try {
            return await _chiniesOctionContext.Cart.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> PostCart(Cart cart)
        {
            try
            {
                if (cart == null)
                {
                    return false;
                }
                cart.Quantity = 1;
                await _chiniesOctionContext.Cart.AddAsync(cart);
                await _chiniesOctionContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> PutCart(Cart cart)
        {
            try{
                List<Cart> cartListOfuser = await GetByUserId(cart.UserId);
                Cart currentCart = cartListOfuser.Find(c => c.GiftId == cart.GiftId);
                currentCart.GiftId = cart.GiftId;
                currentCart.UserId = cart.UserId;
                currentCart.Quantity = currentCart.Quantity+1;
                
                Cart c = _mapper.Map<Cart>(currentCart);
                _chiniesOctionContext.Cart.Update(c);
                await _chiniesOctionContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Cart>> GetByUserId(int userId)
        {
            try { 
                List<Cart> listCart = await _chiniesOctionContext.Cart
                    .Where(c => c.UserId == userId)
                    .Select(c=> new Cart { Gift = c.Gift,GiftId=c.GiftId,Quantity=c.Quantity,UserId=c.UserId,CartId=c.CartId })
                    .ToListAsync();
                //List<CartDTO> cart = _mapper.Map<List<CartDTO>>(listCart);
                return listCart;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
