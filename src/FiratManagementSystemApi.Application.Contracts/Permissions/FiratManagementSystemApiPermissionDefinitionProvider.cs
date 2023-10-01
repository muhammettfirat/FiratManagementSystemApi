using FiratManagementSystemApi.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace FiratManagementSystemApi.Permissions;

public class FiratManagementSystemApiPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(FiratManagementSystemApiPermissions.GroupName, L("Permission:FiratManagementSystemApi"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<FiratManagementSystemApiResource>(name);
    }
}
