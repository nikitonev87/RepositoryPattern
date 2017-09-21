using RepositoryPattern.Infrastructure;
using RepositoryPattern.Models;
using RepositoryPattern.Data;

namespace RepositoryPattern.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MyDbContext context) : base(context)
        {
        }
    }
}
