namespace GrupoA.Education.Student.Application.AcademicStudent.generic
{
    public class CommandResult<TResponse>
    {
        private static CommandResult<TResponse> ErrorCommand = new CommandResult<TResponse>(false);
        
        public bool IsSuccess { get; set; }
        public TResponse Result { get; set; }
        
        public CommandResult(bool isSuccess = false)
        {
            IsSuccess = isSuccess;
        }        
        
        public CommandResult(bool isSuccess, TResponse result)
        {
            IsSuccess = isSuccess;
            Result = result;
        }        
        
    }
}