namespace MTT.Application.AppService.Contracts.Responses
{
    public class DeleteUserResponse : BaseResponse
    {
        public DeleteUserResponse(bool success, string error = "")
        {
            
            Success = success;
            if (!success)
                SetError(error);
        }        
    }
}
