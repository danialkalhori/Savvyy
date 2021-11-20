using Microsoft.EntityFrameworkCore;
using SavvyyLibrary.Model;

namespace SavvyyLibrary.Repository.EF
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    
    }
}

//public class ApplicationTestBase
//{
//    protected XBankDbContext DbContext;
//    protected RequestHandlerBuilder Builder;
//    protected IMediator Mediator;

//    protected IServiceProvider ServiceProvider
//    {
//        get
//        {
//            Mock<IServiceProvider> serviceProvider = new Mock<IServiceProvider>();
//            serviceProvider.Setup(x => x.GetService(typeof(XBankDbContext))).Returns(DbContext);

//            foreach (Type entityType in GetCoreDomainTypes())
//            {
//                if (entityType.IsSubclassOf(typeof(Entity)))
//                {
//                    var repoType = typeof(IRepository<>);
//                    var genericType = repoType.MakeGenericType(entityType);

//                    Type repositoryType = Type.GetType($"{nameof(XBank)}.{nameof(Infra)}.{nameof(Infra.EF)}.{nameof(Infra.EF.Repository)}.{entityType.Name}Repository" + $", {typeof(EFAssembly).Assembly.FullName}");

//                    if (repositoryType == null)
//                        continue;

//                    object repo;

//                    repo = Activator.CreateInstance(repositoryType, GetRepoDbContext(), GetListOption(10));

//                    serviceProvider.Setup(x => x.GetService(genericType)).Returns(repo);
//                }
//            }

//            return serviceProvider.Object;
//        }
//    }

//    private Type[] GetCoreDomainTypes()
//    {
//        return
//            typeof(CoreDomainAssembly).Assembly.GetTypes()
//                .Where(t => String.Equals(t.Namespace, $"{nameof(XBank)}.{nameof(Core)}.{nameof(Core.Domain)}.{nameof(Core.Domain.Model)}", StringComparison.Ordinal))
//                .ToArray();
//    }

//    [SetUp]
//    public async Task Setup()
//    {
//        SetupDbContext();

//        Mediator = new Mock<IMediator>().Object;
//        Builder = new RequestHandlerBuilder(DbContext, ServiceProvider, Mediator);
//    }

//    private void SetupDbContext()
//    {
//        DbContextOptionsBuilder<XBankDbContext> optionsBuilder = new DbContextOptionsBuilder<XBankDbContext>()
//            .UseInMemoryDatabase(Guid.NewGuid().ToString());

//        DbContext = new XBankDbContext(optionsBuilder.Options, ServiceProvider, new TestOptionsMonitor<ConcurrencyOptions>(new ConcurrencyOptions() { EnableRowVersion = true }));

//        DbContext.Database.EnsureCreated();
//    }

//    private XBankDbContext GetRepoDbContext()
//    {
//        DbContextOptionsBuilder<XBankDbContext> optionsBuilder = new DbContextOptionsBuilder<XBankDbContext>()
//            .UseInMemoryDatabase(Guid.NewGuid().ToString());

//        var dbContext = new XBankDbContext(optionsBuilder.Options, null, new TestOptionsMonitor<ConcurrencyOptions>(new ConcurrencyOptions() { EnableRowVersion = true }));

//        dbContext.Database.EnsureCreated();

//        return dbContext;
//    }

//    protected IOptionsMonitor<ListOptions> GetListOption(int maxSize)
//    {
//        return new TestOptionsMonitor<ListOptions>(new ListOptions
//        {
//            MaxSize = maxSize
//        });
//    }

//}