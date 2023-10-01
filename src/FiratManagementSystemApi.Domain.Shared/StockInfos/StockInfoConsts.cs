

namespace FiratManagementSystemApi.StockInfos
{
    public static class StockInfoConsts
    {
        private const string DefaultSorting = "{0}Id asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "StockInfo." : string.Empty);
        }

    }
}