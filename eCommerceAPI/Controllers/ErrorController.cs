using eCommerceAPI.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceAPI.Controllers
{
    [Route("errors/{code}")]
    [ApiController]
    public class ErrorController :  BaseAPIController
    {
        public IActionResult Error(int code)
        {
            return new ObjectResult(new APIResponse(code));
        }
    }
}
