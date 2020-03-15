namespace MTT.Application.AppService.Contracts.Responses.Activity
{
    public class DeleteActivityResponse : BaseResponse
    {
        public DeleteActivityResponse(bool success, string message = "",  string error = "")
        {
            Success = success;
            Message = message;
            if (!success)
                SetError(error);
        }
    }
}
