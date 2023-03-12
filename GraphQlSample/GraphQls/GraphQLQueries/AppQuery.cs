using GraphQL;
using GraphQL.Types;
using GraphQlSample.Contract;
using GraphQlSample.GraphQls.GraphQLTypes;

namespace GraphQlSample.GraphQls.GraphQLQueries
{
    public class AppQuery : ObjectGraphType
    {
        public AppQuery(IOwnerRepository repository)
        {
            Field<ListGraphType<OwnerType>>(
                "owners",
                resolve: context => repository.GetAll());

            
            Field<OwnerType>(
                "owner",
                arguments: 
                  new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "ownerId" }),
                resolve: context =>
                {
                    Guid id;
                    if (!Guid.TryParse(context.GetArgument<string>("ownerId"), out id))
                    {
                        context.Errors.Add(new ExecutionError("wronge value for guid"));
                        return null;
                    }

                    return repository.GetById(id);
                });
        }
    }
}
