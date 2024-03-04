using sushi_go.Models;

namespace sushi_go.Services.Interfaces
{
    public interface IMenuService
    {
        List<MenuItemModel> GetRollsMenu();
        MenuItemModel? GetMenuItemById(int id);
        List<MenuItemModel> GetSetsMenu();
    }
}
