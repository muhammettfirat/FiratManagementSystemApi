

namespace FiratManagementSystemApi.ApprovalTiers
{
    public static class ApprovalTierConsts
    {
        private const string DefaultSorting = "{0}Id asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "ApprovalTier." : string.Empty);
        }

    }
}