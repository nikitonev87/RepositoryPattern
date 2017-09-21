using RepositoryPattern.Data;

namespace RepositoryPattern.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext context;

        public UnitOfWork(MyDbContext context)
        {
            this.context = context;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
