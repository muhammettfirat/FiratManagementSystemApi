

namespace FiratManagementSystemApi.Groups
{
    public static class GroupConsts
    {
        private const string DefaultSorting = "{0}Id asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Group." : string.Empty);
        }

    }
}