using Newtonsoft.Json.Linq;

namespace GraphQlSample.Model
{
    public class GraphQLQuery
    {
        public string? OperationName { get; set; }
        public string? NamedQuery { get; set; }
        public string? Query { get; set; }
    }

}
