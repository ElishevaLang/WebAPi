using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyNewCiniesOction.BL;

namespace MyNewCiniesOction.Controllers
{
    public class WinningController:Controller
    {
        private readonly IMapper _mapper;
        private readonly IWinningService _winningService;
        public WinningController(IWinningService winningService, IMapper mapper)
        {
            _mapper = mapper;
            winningService = _winningService;
        }

    }
}
