using MyNewCiniesOction.DAL;
using MyNewCiniesOction.DTO;
using MyNewCiniesOction.Models;
using System.Collections.Generic;

namespace MyNewCiniesOction.BL
{
    public class RaffleService : IRaffleService
    {
        private readonly IRaffleDal _raffleDal;
        private readonly IOrderItemsDal _orderItemsDal;
        private readonly IGiftDal _giftDal;
        private readonly IOrderDal _orderDal;
        private readonly IUserDal _userDal;
        private static Random rnd = new Random();
        public RaffleService(IRaffleDal raffleDal, IOrderItemsDal orderItemsDal, IGiftDal giftDal, IOrderDal orderDal, IUserDal userDal)
        {
            _raffleDal = raffleDal;
            _orderItemsDal = orderItemsDal;
            _giftDal = giftDal;
            _orderDal = orderDal;
            _userDal= userDal;
        }
        

        public async Task<bool> RaffleForEachGift()
        {
            try
            {
                List<RaffleDTO> raffleList = await _raffleDal.Winners();

                if (raffleList.Count == 0) {      
                    
                    List<OrderItemsGetDTO> orderItemsList = await _orderItemsDal.GetOrderItems();
                    List<Gift> giftList = await _giftDal.Get();
                    List<Order> orderList = await _orderDal.GetOrders();
                    List<User> userList = await _userDal.Get();

                    foreach (var gift in giftList)
                    {
                        List<OrderItemsGetDTO> orderItemsForEach = orderItemsList.FindAll(o => o.gift.GiftId == gift.GiftId);
                        if (orderItemsForEach.Count > 0) { 
                        var winnerIndex = rnd.Next(orderItemsForEach.Count);
                        OrderItemsGetDTO winnerOrder = orderItemsForEach[winnerIndex];
                        // call get items
                        Order winnerOrderForFindingUser = orderList.Find(ord => ord.OrderId == winnerOrder.order.OrderId);
                        User winnerUserFromDB = userList.Find(user => user.UserId == winnerOrderForFindingUser.UserId);
                        int winnerUser = winnerUserFromDB.UserId;
                        int winnerGift = winnerOrder.gift.GiftId;
                        await _raffleDal.InsertWinningToRaffle(winnerUser, winnerGift);
                          }
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<RaffleDTO>> Winners()
        {
            return await _raffleDal.Winners();
        }
    }
}
