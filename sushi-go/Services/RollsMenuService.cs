using Examine;
using sushi_go.Models;
using sushi_go.Services.Interfaces;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Web.Common;

namespace sushi_go.Services
{
    public class RollsMenuService : IRollsMenuService
    {
        private readonly UmbracoHelper _umbracoHelper;
        private readonly ISearcher _searcher;

        public RollsMenuService(IExamineManager examineManager, UmbracoHelper umbracoHelper)
        {
            _umbracoHelper = umbracoHelper;

            if (!examineManager.TryGetIndex(Constants.UmbracoIndexes.ExternalIndexName, out IIndex index))
            {
                throw new InvalidOperationException($"No index found by name{Constants.UmbracoIndexes.ExternalIndexName}");
            }

            _searcher = index.Searcher;
        }

        public List<RollProductModel> GetRollsMenu()
        {
            var query = _searcher
               .CreateQuery(Constants.Applications.Content)
               .NodeTypeAlias("product");

            var searchResults = query.Execute();

            if (searchResults is null)
                return [];

            return searchResults.Select(i =>
            {
                var product = _umbracoHelper.Content(i.Id);

                if (product == null)
                    return null;

                return new RollProductModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Image = product.Value<MediaWithCrops>("image")?.MediaUrl() ?? "",
                    Description = product.Value<string>("description") ?? "",
                    Ingredients = product.Value<string>("ingredients")?.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList() ?? [],
                    Weight = product.Value<int>("weight"),
                    Pieces = product.Value<int>("pieces"),
                    Price = product.Value<int>("price")
                };
            })
            .WhereNotNull()
            .ToList();
        }

        public RollProductModel? GetRollById(int id)
        {
            var product = _umbracoHelper.Content(id);

            if (product == null)
                return null;

            return new RollProductModel
            {
                Id = product.Id,
                Name = product.Name,
                Image = product.Value<MediaWithCrops>("image")?.MediaUrl() ?? "",
                Description = product.Value<string>("description") ?? "",
                Ingredients = product.Value<string>("ingredients")?.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList() ?? [],
                Weight = product.Value<int>("weight"),
                Pieces = product.Value<int>("pieces"),
                Price = product.Value<int>("price")
            };
        }
    }
}
