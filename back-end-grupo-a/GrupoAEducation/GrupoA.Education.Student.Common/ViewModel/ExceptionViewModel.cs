using System.Collections.Generic;
using GrupoA.Education.Student.Common.Notification;

namespace GrupoA.Education.Student.Common.ViewModel
{
    public class ExceptionViewModel
    {
        public List<NotificationMessage> Exceptions { get; set; }

        public ExceptionViewModel(List<NotificationMessage> exceptions)
        {
            Exceptions = exceptions;
        }

        public ExceptionViewModel(NotificationMessage exception)
        {
            Exceptions = new List<NotificationMessage>{exception};
        }
    }
}