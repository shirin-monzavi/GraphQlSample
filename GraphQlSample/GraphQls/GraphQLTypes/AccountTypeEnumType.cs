using GraphQL.Types;
using GraphQlSample.Entities;

namespace GraphQlSample.GraphQls.GraphQLTypes
{
    public class AccountTypeEnumType : EnumerationGraphType<TypeOfAccount>
    {
        public AccountTypeEnumType()
        {
            Name = "Type";
            Description = "Enumeration for the account type";
        }
    }
}
