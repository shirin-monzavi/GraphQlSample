using Newtonsoft.Json.Linq;

namespace GraphQlSample.Model
{
    public class GraphQLQuery
    {
        public string? Query { get; set; }

        public JObject? Variables { get; set; }
    }
}
