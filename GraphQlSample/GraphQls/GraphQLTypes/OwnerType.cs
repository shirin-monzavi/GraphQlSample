using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQlSample.Contract;
using GraphQlSample.Entities;

namespace GraphQlSample.GraphQls.GraphQLTypes
{
    public class OwnerType : ObjectGraphType<Owner>
    {
        public OwnerType(IAccountRepository repository, IDataLoaderContextAccessor dataLoader)
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id Property From the Owners object");
            Field(x => x.Name).Description("Name property from the owner object");
            Field(x => x.Address).Description("Address property from the owner");

            Field<ListGraphType<AccountType>>(
                "accounts",
                resolve: context =>
                {
                    var loader = dataLoader.Context.GetOrAddCollectionBatchLoader<Guid, Account>("GetAccountsByOwnerIds", repository.GetAccountsByOwnerIds);
                    return loader.LoadAsync(context.Source.Id);
                });

        }
    }
}
