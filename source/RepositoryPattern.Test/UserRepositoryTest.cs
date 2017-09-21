using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using RepositoryPattern.Data;
using RepositoryPattern.Infrastructure;
using RepositoryPattern.Models;
using RepositoryPattern.Repositories;
using System.Linq;

namespace RepositoryPattern.Test
{
    [TestFixture]
    public class UserRepositoryTest
    {
        [Test]
        public void Add()
        {
            using (var connection = new SqliteConnection("Filename=:memory:"))
            {
                connection.Open();

                var options = new DbContextOptionsBuilder<MyDbContext>()
                    .UseSqlite(connection)
                    .Options;

                using (var context = new MyDbContext(options))
                {
                    context.Database.EnsureCreated();
                }

                using (var context = new MyDbContext(options))
                {
                    var user = new User
                    {
                        FirstName = "Joe",
                        LastName = "Bloggs"
                    };

                    var repository = new UserRepository(context);
                    repository.Add(user);

                    var unitOfWork = new UnitOfWork(context);
                    unitOfWork.Save();
                }

                using (var context = new MyDbContext(options))
                {
                    var count = context.Users.Count();
                    Assert.AreEqual(1, count);
                }
            }
        }
    }
}
