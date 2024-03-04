using Examine;
using sushi_go.Models;
using sushi_go.Services.Interfaces;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Web.Common;

namespace sushi_go.Services
{
    public class MenuService : IMenuService
    {
        private readonly UmbracoHelper _umbracoHelper;
        private readonly ISearcher _searcher;

        public MenuService(IExamineManager examineManager, UmbracoHelper umbracoHelper)
        {
            _umbracoHelper = umbracoHelper;

            if (!examineManager.TryGetIndex(Constants.UmbracoIndexes.ExternalIndexName, out IIndex index))
            {
                throw new InvalidOperationException($"No index found by name{Constants.UmbracoIndexes.ExternalIndexName}");
            }

            _searcher = index.Searcher;
        }

        public List<MenuItemModel> GetRollsMenu()
        {
            var root = _umbracoHelper.ContentAtRoot().FirstOrDefault();

            var rollsNodeId = root?
                .DescendantsOrSelfOfType("menu")?
                .DescendantsOrSelfOfType("rolls")?
                .FirstOrDefault()?.Id;

            if (!rollsNodeId.HasValue)
                return [];

            var query = _searcher
               .CreateQuery(Constants.Applications.Content)
               .ParentId(rollsNodeId.Value)
               .And()
               .NodeTypeAlias("product");

            var searchResults = query.Execute();

            if (searchResults == null)
                return [];

            return searchResults.Select(i =>
            {
                var product = _umbracoHelper.Content(i.Id);

                if (product == null)
                    return null;

                return new MenuItemModel
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

        public MenuItemModel? GetMenuItemById(int id)
        {
            var product = _umbracoHelper.Content(id);

            if (product == null)
                return null;

            return new MenuItemModel
            {
                Id = product.Id,
                Name = product.Name,
                Image = product.Value<MediaWithCrops>("image")?.GetCropUrl(500, 500) ?? "",
                Description = product.Value<string>("description") ?? "",
                Ingredients = product.Value<string>("ingredients")?.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList() ?? [],
                Weight = product.Value<int>("weight"),
                Pieces = product.Value<int>("pieces"),
                Price = product.Value<int>("price")
            };
        }

        public List<MenuItemModel> GetSetsMenu()
        {
            var root = _umbracoHelper.ContentAtRoot().FirstOrDefault();

            var setsNodeId = root?
                .DescendantsOrSelfOfType("menu")?
                .DescendantsOrSelfOfType("sets")?
                .FirstOrDefault()?.Id;

            if (!setsNodeId.HasValue)
                return [];


            var query = _searcher
               .CreateQuery(Constants.Applications.Content)
               .ParentId(setsNodeId.Value)
               .And()
               .NodeTypeAlias("product");

            var searchResults = query.Execute();

            if (searchResults == null)
                return [];

            return searchResults.Select(i =>
            {
                var product = _umbracoHelper.Content(i.Id);

                if (product == null)
                    return null;

                return new MenuItemModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Image = product.Value<MediaWithCrops>("image")?.GetCropUrl(500, 500) ?? "",
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
    }
}
