

namespace FiratManagementSystemApi.ApprovalTierLogs
{
    public static class ApprovalTierLogConsts
    {
        private const string DefaultSorting = "{0}Id asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "ApprovalTierLog." : string.Empty);
        }

    }
}