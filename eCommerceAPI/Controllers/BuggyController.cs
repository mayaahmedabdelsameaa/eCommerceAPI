using eCommerceAPI.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyController : BaseAPIController
    {
        private readonly StoreContext _context;
        public BuggyController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet("notfound")]
        public IActionResult GetNotFoundRequest()
        {
            var thing = _context.Products.Find(50);
            if (thing == null) return NotFound(new APIResponse(404));
            return Ok();
        }

        [HttpGet("servererror")]
        public IActionResult GetSerVerError()
        {
            var thing = _context.Products.Find(50);
            var result = this.ToString();
            return Ok();
        }

        [HttpGet("badrequest")]
        public IActionResult GetBadRequest()
        {
            return BadRequest(new APIResponse(400));
        }

        [HttpGet("badrequest/id")]
        public IActionResult GetNotFoundRequest(int id)
        {
            return Ok();
        }
    }
}
