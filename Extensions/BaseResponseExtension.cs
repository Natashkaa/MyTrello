using MyTrello.Domain.Services.Communication;
using MyTrello.Resources.Communication;
using MyTrello.Resources;

namespace MyTrello.Extensions
{
    public static class BaseResponseExtension
    {
        public static ResponseResult GetResponseResult<T>(this T response, IResource resource) where T : BaseResponse
        {
            return new ResponseResult
            {
                Data = resource,
                Message = response.Message,
                Success = response.Success
            };
        }
    }
}