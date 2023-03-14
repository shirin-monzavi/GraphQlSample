using GraphQL.Types;

namespace GraphQlSample.Model
{
    public class Paging
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }
    }
}
