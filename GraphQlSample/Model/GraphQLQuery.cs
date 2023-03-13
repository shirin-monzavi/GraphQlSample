using System.Text.Json.Nodes;

namespace GraphQlSample.Model
{
    public class GraphQLQuery
    {
        public string? OperationName { get; set; }
        public string? NamedQuery { get; set; }
        public string? Query { get; set; }
        public JsonObject? Variables { get; set; }
    }

}
