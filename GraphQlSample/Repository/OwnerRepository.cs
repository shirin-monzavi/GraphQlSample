using GraphQlSample.Context;
using GraphQlSample.Contract;
using GraphQlSample.Entities;

namespace GraphQlSample.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly ApplicationContext _context;
        public OwnerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Owner CreateOwner(Owner owner)
        {
            owner.Id = new Guid();
            _context.Owners.Add(owner);
            _context.SaveChanges();
            return owner;
        }

        public Owner DeleteOwner(Owner owner)
        {
            _context.Remove(owner);
            _context.SaveChanges();

            return owner;
        }

        public IEnumerable<Owner> GetAll()
        {
            return _context.Owners.ToList();
        }

        public Owner GetById(Guid id)
            => _context.Owners.SingleOrDefault(o => o.Id.Equals(id));

        public Owner UpdateOwner(Owner ownerDb, Owner owner)
        {
            var findedOwner = _context.Owners.Find(ownerDb.Id);

            findedOwner.Address = owner.Address;
            findedOwner.Name = owner.Name;

            _context.SaveChanges();

            return owner;
        }
    }
}
