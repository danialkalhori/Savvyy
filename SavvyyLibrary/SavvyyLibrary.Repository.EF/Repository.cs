using Microsoft.EntityFrameworkCore;
using SavvyyLibrary.Model;
using SavvyyLibrary.Model.Model;

namespace SavvyyLibrary.Repository.EF
{
    public class Repository : IRepository
    {
        private LibraryContext _libraryContext;

        public Repository()
        {
            if (_libraryContext == null)
            {
                DbContextOptionsBuilder<LibraryContext> optionsBuilder = new DbContextOptionsBuilder<LibraryContext>()
                .UseInMemoryDatabase("InMemoryLibraryDB");

                ContextOptions = optionsBuilder.Options;

                _libraryContext = new LibraryContext(optionsBuilder.Options);

                Seed();
            }
        }

        protected DbContextOptions<LibraryContext> ContextOptions { get; }

        private void Seed()
        {
            using (var context = new LibraryContext(ContextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var bookOfGameOfThrone = new Book
                {
                    Title = "A Song of Ice and Fire",
                    Description = "A fantasy in imaginary world in which people act like real world.",
                    Author = "George R. R. Martin",
                    Price = 100,
                    CoverImage = new byte[] { }
                };

                var shahnameh = new Book
                {
                    Title = "Shahnameh",
                    Description = "One of the most amazing books on earth.",
                    Author = "Ferdowsi",
                    Price = 250,
                    CoverImage = new byte[] { }
                };

                context.AddRange(bookOfGameOfThrone, shahnameh);

                context.SaveChanges();
            }
        }

        public async Task<int> Save<T>(T entity) where T : Entity
        {
            var dbset = _libraryContext.Set<T>();

            if (dbset.Any(e => e.Id == entity.Id))
            {
                dbset.Update(entity);
            }
            else
            {
                dbset.Add(entity);
            }

            await _libraryContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task Delete<T>(T entity) where T : Entity
        {
            var dbset = _libraryContext.Set<T>();

            dbset.Remove(entity);

            await _libraryContext.SaveChangesAsync();
        }

        public async Task<T> Get<T>(int id) where T : Entity
        {
            var dbset = _libraryContext.Set<T>();

            return await dbset.FirstOrDefaultAsync<T>(e => e.Id == id);
        }

        public async Task<List<T>> GetList<T>( System.Linq.Expressions.Expression<Func<T,bool>> query) where T : Entity
        {
            var dbset = _libraryContext.Set<T>();

            return await dbset.Where(query).ToListAsync();
        }
    }
}
