using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyNewCiniesOction.BL;
using MyNewCiniesOction.DTO;
using MyNewCiniesOction.Models;
using System.Collections.Generic;

namespace MyNewCiniesOction.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RaffleController: Controller
    {
        private readonly IMapper _mapper;

        private readonly IRaffleService _raffleService;

        public RaffleController(IRaffleService raffleService, IMapper mapper)
        {
            _mapper = mapper;
            _raffleService = raffleService;
        }

        [HttpGet("raffleAndPutInDB")]
        public async Task<bool> RaffleAndPutInDB()
        {
            try
            {
                return await _raffleService.RaffleForEachGift();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("Winners")]
        public async Task<List<RaffleDTO>> Winners()
        {
            try
            {
                List<RaffleDTO> raffleList = await _raffleService.Winners();
                List<RaffleDTO> newRaffleList = new List<RaffleDTO>();
                foreach (RaffleDTO item in raffleList)
                {
                    RaffleDTO i = _mapper.Map<RaffleDTO>(item);
                    newRaffleList.Add(i);
                }
                return newRaffleList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
