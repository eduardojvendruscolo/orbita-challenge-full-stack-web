using System.Text.Json;

namespace GrupoA.Education.Student.Common.Notification
{
    public class NotificationMessage
    {
        public string Field { get; set; }
        public string MessageCode { get; set; }
        public string Message { get; set; }
        public int? Status { get; set; }
        public string InnerException { get; set; }
        public string StackTrace { get; set; }

        public NotificationMessage(string field, string messageCode, string message, int? status = null, string innerException = null, string stackTrace = null)
        {
            Field = field;
            MessageCode = messageCode;
            Message = message;
            Status = status;
            InnerException = innerException;
            StackTrace = stackTrace;
        }        
        
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }        
    }
}