using Microsoft.AspNetCore.Mvc;
using sushi_go.Services.Interfaces;
using Umbraco.Cms.Web.Common.Controllers;

namespace sushi_go.Controllers
{
    [ApiController]
    [Route("api/settings")]
    public class SiteSettingsController(ISiteSettingsService _siteSettingsService) : UmbracoApiController
    {
        [HttpGet]
        public ActionResult GetSiteSettings()
        {
            var settings = _siteSettingsService.GetSiteSettings();

            return Ok(settings);
        }
    }
}
