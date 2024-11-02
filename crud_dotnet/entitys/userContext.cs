using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace crud_dotnet.entitys
{

    // TodoDbContext class inherits from DbContext
    public class UserDbContext : DbContext
    {

        // DbSettings field to store the connection string
        private readonly DbSettings _dbsettings;

        // Constructor to inject the DbSettings model
        public UserDbContext(IOptions<DbSettings> dbSettings)
        {
            _dbsettings = dbSettings.Value;

        }


        // DbSet property to represent the User table
        public DbSet<User> Users { get; set; }

        // Configuring the database provider and connection string

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("meuBancoEmMemoria");
        }

        // Configuring the model for the User entity
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("usuarios")
                .HasKey(x => x.Id);
        }
    }
}