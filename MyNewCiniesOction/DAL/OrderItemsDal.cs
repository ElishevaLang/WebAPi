using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyNewCiniesOction.DTO;
using MyNewCiniesOction.Migrations;
using MyNewCiniesOction.Models;
using System.Data;

namespace MyNewCiniesOction.DAL
{
    public class OrderItemsDal:IOrderItemsDal
    {
        private readonly ChiniesOctionContext _chiniesOctionContext;

        public OrderItemsDal(ChiniesOctionContext chiniesOctionContext)
        {
            _chiniesOctionContext = chiniesOctionContext;
        }
        public async Task<List<OrderItemsGetDTO>> GetOrderItems()
        {
            try {

                List<OrderItemsGetDTO> orderItems = await _chiniesOctionContext.OrderItems
                .Select(o => new OrderItemsGetDTO { orderItemsId = o.OrderItemsId, gift = o.Gift, user = o.Order.User, order = o.Order }).ToListAsync();
                return orderItems;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> PostOrderItems(OrderItems orderItems)
        {
            try
            {
                if (orderItems == null)
                {
                    return false;
                }

                await _chiniesOctionContext.OrderItems.AddAsync(orderItems);
                await _chiniesOctionContext.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> PostOrderItemsList(List<CartDTO> itemsList, int orderId)
        {
            try
            {
                var a = itemsList;
                foreach (var item in itemsList)
                {
                    var o = new OrderItems() { OrderId = orderId, GiftId = item.GiftId };
                    await _chiniesOctionContext.OrderItems.AddAsync(o);
   
                }
                await _chiniesOctionContext.SaveChangesAsync();
                return orderId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<OrderItems>> GetOrderItemsByUser(int userId)
        {
            try
            {
                return await _chiniesOctionContext.OrderItems
             .Where(o => o.Order.User.UserId == userId) // Added a filter to retrieve OrderItems where the associated User has the specified userId
             .Include(o => o.Order)
             .ThenInclude(order => order.User)
             .Include(o => o.Gift) // Include the associated Gift details
             .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<OrderItemsGetDTO>> GetPurchasOfGift(int giftId)
        {
            try {
             List<OrderItemsGetDTO> orderItem = await _chiniesOctionContext.OrderItems
             .Where(o => o.GiftId == giftId)
            //.Include(o => o.Gift)
            //.Include(o => o.Order)
            //.ThenInclude(order => order.User)
             .Select(o => new OrderItemsGetDTO{ orderItemsId = o.OrderItemsId, gift = o.Gift, user = o.Order.User, order = o.Order }).ToListAsync();
               
            if (orderItem.Count == 0)
            {
                return null;
            }

                return orderItem;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
