using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class MediatorController : ControllerBase
    {
        private IMediator _mediator;

        public IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}