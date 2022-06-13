using System;
using System.Collections.Generic;
using FluentValidation.Results;
using System.Linq;
using System.Net;
using GrupoA.Education.Student.Common.Interfaces;

namespace GrupoA.Education.Student.Common.Notification
{
    public class NotificationContext : INotificationContext
    {
        private readonly List<NotificationMessage> _notificationMessages;

        public NotificationContext()
        {
            _notificationMessages = new List<NotificationMessage>();
        }
        
        public void BadRequest(string messageCode, string message, string field = "")
            => AddNotification(messageCode, message, Convert.ToInt32(HttpStatusCode.BadRequest), field);    
        
        public void BadRequest(ValidationResult validationResult)
            => AddNotification(validationResult);        
        
        public void Forbidden(string messageCode, string message)
            => AddNotification(messageCode, message, Convert.ToInt32(HttpStatusCode.Forbidden), "");    
        
        public void NotFound(string messageCode, string message)
            => AddNotification(messageCode, message, Convert.ToInt32(HttpStatusCode.NotFound), "");

        private void AddNotification(string messageCode, string message, int statusCode = 0, string field = "")
            => _notificationMessages.Add(new NotificationMessage(field, messageCode, message, statusCode));      
        
        private void AddNotification(ValidationResult validationResult)
        {
            var errors = validationResult.Errors.ToList();
            foreach (var error in errors)
            {
                AddNotification(error.ErrorCode, error.ErrorMessage, Convert.ToInt32(HttpStatusCode.BadRequest));
            }
        }
        public bool ExistsNotifications() => _notificationMessages.Any();
        public bool ExistsNotFound() => _notificationMessages.Any(p => p.Status.Equals(Convert.ToInt32(HttpStatusCode.NotFound)));
        public List<NotificationMessage> GetAllNotifications() => _notificationMessages;
        
    }
}