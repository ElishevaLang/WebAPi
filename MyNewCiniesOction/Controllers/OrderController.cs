using AutoMapper;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using MyNewCiniesOction.BL;
using MyNewCiniesOction.DTO;
using MyNewCiniesOction.Models;

namespace MyNewCiniesOction.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class OrderController : Controller
        {
            private readonly IMapper _mapper;
            private readonly IOrderService _orderService;
            public OrderController(IOrderService orderService, IMapper mapper)
            {
             _mapper= mapper;
            _orderService = orderService;
            }

            [HttpGet]
            public async Task<List<Order>> GetOrder()
            {
            try
            {
                return await _orderService.GetOrder();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


            [HttpGet("getUsers")]
            public async Task<List<User>> GetUsers()
            {
            try
            {
                return await _orderService.GetUsers();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


            [HttpGet("getDetailsByUserId")]
            public async Task<User> GetDetailsByUserId(int userId)
            {
            try
            {
                return await _orderService.GetDetailsByUserId(userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


            [HttpGet("ById")]
            public async Task<Order> GetOrderById(int orderId)
            {
            try
            {
                return await _orderService.GetOrderById(orderId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


            [HttpGet("ByUserId")]
            public async Task<List<Order>> GetOrderByUserId(int userId)
            {
            try
            {
                return await _orderService.GetOrderByUserId(userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

            [HttpPost("createOrder")]
            public async Task<int> Post(OrderDTO o)
            {
            try
            {
                User user = (User)HttpContext.Request.HttpContext.Items["User"];
                int userId = user.UserId;
                o.UserId = userId;
                Order order = _mapper.Map<Order>(o);
                return await _orderService.Post(order);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
            [HttpGet("GetIncomes")]
            public async Task<int> GetIncomes()
            {
                try
                {
                    return await _orderService.GetIncomes();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        
        }
}
