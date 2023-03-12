using GraphQlSample.Entities;

namespace GraphQlSample.Contract
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> GetAll();

        Owner GetById(Guid id);

        Owner CreateOwner(Owner owner);

        Owner UpdateOwner(Owner ownerDb,Owner owner);

        Owner DeleteOwner(Owner owner);
    }
}
