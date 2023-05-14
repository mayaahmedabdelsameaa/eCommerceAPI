using System.Security;

namespace eCommerceAPI.Errors
{
    public class APIResponse
    {
        public APIResponse(int statusCode, string message = null) 
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

        public string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "You made a bad request",
                401 => "You are not authorized",
                404 => "Not Found",
                500 => "Server Error",
                _ => null
            } ;
        }
    }
}
