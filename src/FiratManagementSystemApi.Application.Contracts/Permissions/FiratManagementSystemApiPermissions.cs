using Volo.Abp.Reflection;

namespace FiratManagementSystemApi.Permissions;

public class FiratManagementSystemApiPermissions
{
    public const string GroupName = "FiratManagementSystemApi";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(FiratManagementSystemApiPermissions));
    }
}
