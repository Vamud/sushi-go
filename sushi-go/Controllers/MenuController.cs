using Microsoft.AspNetCore.Mvc;
using sushi_go.Services.Interfaces;
using Umbraco.Cms.Web.Common.Controllers;

namespace sushi_go.Controllers
{
    [ApiController]
    [Route("api/menu")]
    public class MenuController(IMenuService _rollsMenuService) : UmbracoApiController
    {
        [HttpGet("rolls")]
        public ActionResult GetRolls()
        {
            var rolls = _rollsMenuService.GetRollsMenu();

            return Ok(rolls);
        }

        [HttpGet("rolls/{id}")]
        public ActionResult GetRollById(int id)
        {
            var roll = _rollsMenuService.GetMenuItemById(id);

            return Ok(roll);
        }

        [HttpGet("sets")]
        public ActionResult GetSetsMenu()
        {
            var sets = _rollsMenuService.GetSetsMenu();

            return Ok(sets);
        }
    }
}
