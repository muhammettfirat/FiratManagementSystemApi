

namespace FiratManagementSystemApi.CompanyInfos
{
    public static class CompanyInfoConsts
    {
        private const string DefaultSorting = "{0}Id asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "CompanyInfo." : string.Empty);
        }

    }
}