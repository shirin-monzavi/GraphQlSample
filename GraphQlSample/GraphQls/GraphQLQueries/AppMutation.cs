using GraphQL;
using GraphQL.Types;
using GraphQlSample.Contract;
using GraphQlSample.Entities;
using GraphQlSample.GraphQls.GraphQLTypes;

namespace GraphQlSample.GraphQls.GraphQLQueries
{
    public class AppMutation : ObjectGraphType
    {
        public AppMutation(IOwnerRepository repository)
        {
            Field<OwnerType>(
                "createOwner",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<OwnerInputType>> { Name = "owner" }),
                resolve: context =>
                {
                    var owner = context.GetArgument<Owner>("owner");
                    return repository.CreateOwner(owner);
                });

            Field<OwnerType>("updateOwner",
                arguments:
                new QueryArguments(
                new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "ownerId" },
                new QueryArgument<NonNullGraphType<OwnerInputType>> { Name = "owner" }),
                resolve: context =>
                {
                    var ownerId = context.GetArgument<Guid>("ownerId");
                    var find = repository.GetById(ownerId);

                    var owner = context.GetArgument<Owner>("owner");
                    return repository.UpdateOwner(find, owner);
                });

            Field<OwnerType>("deleteOwner",
              arguments:
              new QueryArguments(
              new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "ownerId" }),
              resolve: context =>
              {
                  var owner = context.GetArgument<Guid>("ownerId");
                  var find = repository.GetById(owner);
                  if (find == null)
                  {
                      context.Errors.Add(new ExecutionError("owner not found"));
                      return null;
                  }

                  return repository.DeleteOwner(find);
              });
        }
    }
}
