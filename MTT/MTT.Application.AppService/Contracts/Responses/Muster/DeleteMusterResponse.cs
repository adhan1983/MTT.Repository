namespace MTT.Application.AppService.Contracts.Responses.Muster
{
    public class DeleteMusterResponse : BaseResponse
    {
        public DeleteMusterResponse(bool success, string message = "", string error = "")
        {
            Success = success;
            Message = message;
            if (!success)
                SetError(error);
        }
    }
}
