using GraphQL.Types;
using GraphQlSample.GraphQls.GraphQLQueries;

namespace GraphQlSample.GraphQls.GraphQlSchema
{
    public class AppSchema : Schema
    {
        public AppSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<AppQuery>();
            Mutation = serviceProvider.GetRequiredService<AppMutation>();

        }
    }
}
