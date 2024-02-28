using Microsoft.AspNetCore.Mvc;
using sushi_go.Services.Interfaces;
using Umbraco.Cms.Web.Common.Controllers;

namespace sushi_go.Controllers
{
    [ApiController]
    [Route("api/menu")]
    public class RollsMenuController(IRollsMenuService _rollsMenuService) : UmbracoApiController
    {
        [HttpGet("rolls")]
        public ActionResult GetRolls()
        {
            var rolls = _rollsMenuService.GetRollsMenu();

            return Ok(rolls);
        }
    }
}
