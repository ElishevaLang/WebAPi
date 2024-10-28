using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyNewCiniesOction.BL;
using MyNewCiniesOction.DTO;
using MyNewCiniesOction.Models;

namespace MyNewCiniesOction.Controllers
{
   
        [Route("api/[controller]")]
        [ApiController]

        public class CartController : Controller
        {
            private readonly IMapper _mapper;
            private readonly ICartService _cartService;
            public CartController(ICartService cartService, IMapper mapper)
            {
            _mapper = mapper;
            _cartService = cartService;
            }

        [HttpGet("/allCart")]
        [Authorize(Roles = "admin")]
        public async Task<List<Cart>> GetCart()
        {
            try 
            { 
                return await _cartService.GetCart();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    

        [HttpGet("getUsersCart")]
        public async Task<List<Cart>> GetByUserId()
        {

            try
            {
                User user = (User)HttpContext.Request.HttpContext.Items["User"];

                if (user == null)
                {
                    return null;
                }
                int userId = user.UserId;

                return await _cartService.GetByUserId(userId);
            }


            catch (Exception ex)
            {
                throw ex;
            }

        }
        [HttpPost]
        public async Task<bool> PostCart(CartDTO c)
        {
            try
            {
                User user = (User)HttpContext.Request.HttpContext.Items["User"];

                if (user == null)
                {
                    return false;
                }
                int userId = user.UserId;
                c.UserId = userId;
                Cart cart = _mapper.Map<Cart>(c);
                return await _cartService.PostCart(cart);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [HttpDelete("DeleteItemInCart")]
        public async Task<bool> DeleteItemInCart(int cartId)
        {
            try
            {
                return await _cartService.DeleteCart(cartId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [HttpDelete("deleteAllCart")]
        public async Task<bool> DeleteAllCart()
        {
            try
            {
                User user = (User)HttpContext.Request.HttpContext.Items["User"];
                return await _cartService.DeleteAllCart(user.UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        }
    }


