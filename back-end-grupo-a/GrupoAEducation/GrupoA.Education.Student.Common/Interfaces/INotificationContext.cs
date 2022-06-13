using System.Collections.Generic;
using FluentValidation.Results;
using GrupoA.Education.Student.Common.Notification;

namespace GrupoA.Education.Student.Common.Interfaces
{
    public interface INotificationContext
    {
        void BadRequest(string messageCode, string message, string field = "");
        void BadRequest(ValidationResult validationResult);
        void NotFound(string messageCode, string message);
        public bool ExistsNotifications();
        public bool ExistsNotFound();
        public List<NotificationMessage> GetAllNotifications();
    }
}