using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace FiratManagementSystemApi.Pages;

public class IndexModel : FiratManagementSystemApiPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
