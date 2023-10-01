

namespace FiratManagementSystemApi.TierAuthorizations
{
    public static class TierAuthorizationConsts
    {
        private const string DefaultSorting = "{0}Id asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TierAuthorization." : string.Empty);
        }

    }
}