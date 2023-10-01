using Volo.Abp.Bundling;

namespace FiratManagementSystemApi.Blazor.Host;

public class FiratManagementSystemApiBlazorHostBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true);
    }
}
