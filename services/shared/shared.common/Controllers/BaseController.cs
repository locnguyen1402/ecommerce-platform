using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ECommerce.Shared.Common;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{
    protected readonly ILogger<BaseController> _logger;
    protected readonly IMapper _mapper;
    protected BaseController(ILogger<BaseController> logger, IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
    }
}