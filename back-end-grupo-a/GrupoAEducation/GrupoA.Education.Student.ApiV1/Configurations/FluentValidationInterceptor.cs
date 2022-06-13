using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using GrupoA.Education.Student.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GrupoA.Education.Student.Api.Configurations
{
    public class FluentValidationInterceptor: IValidatorInterceptor
    {
        
        private readonly INotificationContext _notificationContext;

        public FluentValidationInterceptor(INotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }        
        
        public IValidationContext BeforeAspNetValidation(ActionContext actionContext, IValidationContext commonContext)
        {
            return commonContext;
        }

        public ValidationResult AfterAspNetValidation(ActionContext actionContext, IValidationContext validationContext,
            ValidationResult result)
        {
            if (!result.IsValid)
                _notificationContext.BadRequest(result);

            return result;
        }
    }
}