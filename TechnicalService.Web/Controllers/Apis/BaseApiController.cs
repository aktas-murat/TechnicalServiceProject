using Microsoft.AspNetCore.Mvc;

namespace TechnicalService.Web.Controllers.Apis
{
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]

    public class BaseApiController : ControllerBase
    {
       
    }
}