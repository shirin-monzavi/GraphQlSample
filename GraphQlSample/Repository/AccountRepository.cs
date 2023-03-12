using GraphQlSample.Context;
using GraphQlSample.Contract;
using GraphQlSample.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQlSample.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationContext _context;
        public AccountRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<ILookup<Guid, Account>> GetAccountsByOwnerIds(IEnumerable<Guid> ownerIds)
        {
            var accounts = await _context.Accounts
                .Where(x => ownerIds.Contains(x.OwnerId)).ToListAsync();

            return accounts.ToLookup(x => x.OwnerId);
        }

        public IEnumerable<Account> GetAllAccountsPerOwner(Guid ownerId)
        {
            return _context.Accounts.Where(a => a.OwnerId.Equals(ownerId)).ToList();
        }
    }
}
