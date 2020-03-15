namespace MTT.Application.AppService.Contracts.Responses.Muster
{
    public class DeleteMusterResponse : BaseResponse
    {
        public DeleteMusterResponse(bool success, string error = "")
        {
            Success = success;
            if (!success)
                SetError(error);
        }
    }
}
