namespace MTT.Application.AppService.Contracts.Responses.Activity
{
    public class UpdateActivityResponse : BaseResponse
    {
        public UpdateActivityResponse(bool success, string message = "", string error = "")
        {
            Success = success;
            Message = message;
            if (!success)
                SetError(error);
        }
    }
}
