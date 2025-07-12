using Microsoft.AspNetCore.Mvc;
using Motor.Transport.Adapter.Utility;
using Motor.Transport.Adapter.Utility.Constants;

namespace Motor.Transport.Adapter.Api.Controllers.BaseController
{
    [ApiController]
    //[Authorize]
    [Route($"{ApiInformation.BasePath}/{ApiInfoConstant.SubBasePath}/{ApiInfoConstant.Adapter}")]
    [Produces("application/json")]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    public class BaseApiController : ControllerBase
    {
    }
}
