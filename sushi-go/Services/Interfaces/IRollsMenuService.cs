using sushi_go.Models;

namespace sushi_go.Services.Interfaces
{
    public interface IRollsMenuService
    {
        List<RollProductModel> GetRollsMenu();
    }
}
