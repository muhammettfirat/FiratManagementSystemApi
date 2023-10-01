

namespace FiratManagementSystemApi.AuditInfos
{
    public static class AuditInfoConsts
    {
        private const string DefaultSorting = "{0}Id asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "AuditInfo." : string.Empty);
        }

    }
}