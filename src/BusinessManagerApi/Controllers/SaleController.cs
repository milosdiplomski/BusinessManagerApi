using AutoMapper;
using BusinessManager.DataAccess.UnitOfWork.Abstractions;
using BusinessManager.Shared.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessManagerApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<SaleController> _logger;
        private readonly IMapper _mapper;
        private SaleBusinessLogic _saleBusinessLogic;

        public SaleController(IUnitOfWork unitOfWork, ILogger<SaleController> log, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = log;
            _mapper = mapper;
            _saleBusinessLogic = new SaleBusinessLogic(_unitOfWork, _logger, _mapper);
        }
    }
}
