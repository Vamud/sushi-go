using sushi_go.Models;
using sushi_go.Services.Interfaces;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Web.Common;

namespace sushi_go.Services
{
    public class SiteSettingsService(UmbracoHelper _umbracoHelper) : ISiteSettingsService
    {
        public SiteSettingsModel GetSiteSettings()
        {
            var root = _umbracoHelper
                .ContentAtRoot()
                .FirstOrDefault();

            return new SiteSettingsModel
            {
                SiteLogo = root?.Value<MediaWithCrops>("siteLogo")?.MediaUrl() ?? ""
            };
        }
    }
}
