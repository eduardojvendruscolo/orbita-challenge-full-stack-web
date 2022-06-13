using System.Linq;
using GrupoA.Education.Student.Common.Interfaces;
using GrupoA.Education.Student.Common.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GrupoA.Education.Student.Api.Configurations
{
    public class FluentValidationFilters: IActionFilter
    {
        private readonly INotificationContext _notificationContext;

        public FluentValidationFilters(INotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }


        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (_notificationContext.ExistsNotifications())
            {
                var exceptionObjectResponse = new ExceptionViewModel(_notificationContext.GetAllNotifications());

                if (_notificationContext.ExistsNotFound())
                {
                    context.Result = new NotFoundObjectResult(exceptionObjectResponse)
                    {
                        ContentTypes = {"application/problem+json"}
                    };
                }
                else
                {
                    context.Result = new BadRequestObjectResult(exceptionObjectResponse)
                    {
                        ContentTypes = { "application/problem+json" }
                    };                    
                }
                return;
            }
            
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.SelectMany(v => v.Errors);
                context.Result = new BadRequestObjectResult(context.ModelState.Values.SelectMany(v => v.Errors))
                {
                    ContentTypes = { "application/problem+json" }
                };
            } 
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (_notificationContext.ExistsNotifications())
            {
                var exceptionObjectResponse = new ExceptionViewModel(_notificationContext.GetAllNotifications());

                if (_notificationContext.ExistsNotFound())
                {
                    context.Result = new NotFoundObjectResult(exceptionObjectResponse)
                    {
                        ContentTypes = {"application/problem+json"}
                    };
                }
                else
                {
                    context.Result = new BadRequestObjectResult(exceptionObjectResponse)
                    {
                        ContentTypes = { "application/problem+json" }
                    };                    
                }
                return;
            }
            
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.SelectMany(v => v.Errors);
                context.Result = new BadRequestObjectResult(context.ModelState.Values.SelectMany(v => v.Errors))
                {
                    ContentTypes = { "application/problem+json" }
                };
            }    
        }
    }
}