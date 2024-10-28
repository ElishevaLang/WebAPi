using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyNewCiniesOction.BL;
using MyNewCiniesOction.DTO;
using MyNewCiniesOction.Models;

namespace MyNewCiniesOction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IOrderItemsService _orderItemsService;
        public OrderItemsController(IOrderItemsService orderItemsService, IMapper mapper)
        {
            _orderItemsService = orderItemsService;
            _mapper = mapper;
        }
        [HttpGet("getForAdmin")]
        public async Task<List<OrderItemsGetDTO>> GetOrderItems()
        {
            try { 
            List<OrderItemsGetDTO> l = await _orderItemsService.GetOrderItems();
            List<OrderItemsGetDTO> newL = new List<OrderItemsGetDTO>();
            foreach (OrderItemsGetDTO item in l)
            {
                OrderItemsGetDTO i = _mapper.Map<OrderItemsGetDTO>(item);
                newL.Add(i);
            }
            return newL;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet("getForUser")]
        public async Task<List<OrderItems>> GetOrderItemsByUser()
        {
            try {
                User user = (User)HttpContext.Request.HttpContext.Items["User"];
                return await _orderItemsService.GetOrderItemsByUser(user.UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<bool> PostOrderItems(OrderItemsDTO o)
        {
            try
            {
                OrderItems orderId = _mapper.Map<OrderItems>(o);
                return await _orderItemsService.PostOrderItems(orderId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPost("PostOrderItemsList")]
        public async Task<int> PostOrderItemsList([FromBody] List<CartDTO> itemsList,int orderId)
        {
            try
            {
                return await _orderItemsService.PostOrderItemsList(itemsList, orderId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet("getPurchasOfGift")]
        public async Task<List<OrderItemsGetDTO>> GetPurchasOfGift(int giftId)
        {
            try { 

            List<OrderItemsGetDTO> l =  await _orderItemsService.GetPurchasOfGift(giftId);
            if (l != null) 
            {
                    List<OrderItemsGetDTO> newL = new List<OrderItemsGetDTO>();
                    foreach (OrderItemsGetDTO item in l)
                    {
                        OrderItemsGetDTO i = _mapper.Map<OrderItemsGetDTO>(item);
                        newL.Add(i);
                    }
                    return newL;
            } 
            else 
                 return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
