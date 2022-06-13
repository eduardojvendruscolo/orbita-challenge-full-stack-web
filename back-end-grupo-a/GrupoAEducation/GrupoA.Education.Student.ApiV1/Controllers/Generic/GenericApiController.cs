using GrupoA.Education.Student.Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GrupoA.Education.Student.Api.Controllers.Generic
{
    [ApiController]
    public abstract class GenericApiController : ControllerBase
    {
        protected readonly INotificationContext notificationContext;
        protected readonly IMediator mediator;

        protected GenericApiController(INotificationContext notificationContext, IMediator mediator)
        {
            this.notificationContext = notificationContext;
            this.mediator = mediator;
        }

        protected ActionResult<T> HttpResponse<T>(T result)
        {
            return Ok(result);
        }
    }
}