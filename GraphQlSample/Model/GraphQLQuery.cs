using System.Text.Json.Nodes;

namespace GraphQlSample.Model
{
    public class GraphQLQuery
    {
        public string? Query { get; set; }
        public JsonObject? Variables { get; set; }
    }

}
