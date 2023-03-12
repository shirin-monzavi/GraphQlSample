using Newtonsoft.Json.Linq;

namespace GraphQlSample.Model
{
    public class GraphQLQueryWithVariable: GraphQLQuery
    {
        public JObject? Variables { get; set; }
    }
}
