namespace MTT.Application.AppService.Contracts.Responses.Activity
{
    public class ConcludedActivityResponse : BaseResponse
    {
        public ConcludedActivityResponse(bool success, string message = "", string error = "") 
        {
            Message = message;
            Success = success;
            if (!success)
                SetError(error);
        }
    }
}
