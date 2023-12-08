namespace E_Commerce.Common
{
    public static class APIGetReturn
    {
        public static PaginatedDataDTO<T> Paginate<T>(List<T> data, int pageNumber, int pageSize, int totalCount, string requestUrl)
        {
            var paginatedData = new PaginatedDataDTO<T>
            {
                TotalCount = totalCount,
                Data = data
            };

            pageNumber.ToString();

            var previousPageNumber = pageNumber > 1 ? pageNumber - 1 : 0;
            var nextPageNumber = pageNumber * pageSize < totalCount ? pageNumber + 1 : 0;

            var uriBuilder = new UriBuilder(requestUrl);
            var queryParams = System.Web.HttpUtility.ParseQueryString(uriBuilder.Query);

            if (pageNumber > 0)
            {
                queryParams.Set(nameof(pageNumber), pageNumber.ToString());
            }

            if (pageSize > 0)
            {
                queryParams.Set(nameof(pageSize), pageSize.ToString());
            }

            paginatedData.PreviousPage = BuildPageLink(uriBuilder.Uri, previousPageNumber);
            paginatedData.NextPage = BuildPageLink(uriBuilder.Uri, nextPageNumber);

            return paginatedData;
        }

        private static string? BuildPageLink(Uri uri, int pageNumber)
        {
            if (pageNumber > 0)
            {
                var uriBuilder = new UriBuilder(uri);
                var queryParams = System.Web.HttpUtility.ParseQueryString(uriBuilder.Query);

                if (queryParams.AllKeys.Contains(nameof(pageNumber)))
                {
                    queryParams.Set(nameof(pageNumber), pageNumber.ToString());
                }
                else
                {
                    queryParams.Add(nameof(pageNumber), pageNumber.ToString());
                }

                uriBuilder.Query = queryParams.ToString();
                return uriBuilder.Uri.ToString();
            }

            return null;
        }
    }

    public class FilterQuery
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? SortOrder { get; set; }
        public string? SortColumn { get; set; }
        public string? Search { get; set; }
    }

    public class PaginatedDataDTO<T>
    {
        public string? PreviousPage { get; set; }
        public string? NextPage { get; set; }
        public int? TotalCount { get; set; }
        public List<T>? Data { get; set; }
    }
}
