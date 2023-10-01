

namespace FiratManagementSystemApi.DocumentTypes
{
    public static class DocumentTypeConsts
    {
        private const string DefaultSorting = "{0}Id asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "DocumentType." : string.Empty);
        }

    }
}