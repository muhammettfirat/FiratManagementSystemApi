using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace FiratManagementSystemApi.Blazor.Menus;

public class FiratManagementSystemApiMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        //Add main menu items.
        context.Menu.AddItem(new ApplicationMenuItem(FiratManagementSystemApiMenus.Prefix, displayName: "FiratManagementSystemApi", "/FiratManagementSystemApi", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
