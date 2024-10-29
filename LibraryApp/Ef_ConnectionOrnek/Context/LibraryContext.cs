using Ef_ConnectionOrnek.Entity;
using Microsoft.EntityFrameworkCore;
namespace Ef_ConnectionOrnek.Context
{
    public class LibraryContext : DbContext

    {
      
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {

        }
        
        protected LibraryContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OperationEntity>().Ignore("Id");
            
            modelBuilder.Entity<OperationEntity>().HasKey("BooksId", "StudentId"); 

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<AuthorEntity> Authors =>Set<AuthorEntity>();

        public DbSet<BookEntity> Books =>Set<BookEntity>();

        public DbSet<BookTypeEntity> BookTypes =>Set<BookTypeEntity>();
        public DbSet<OperationEntity> Operations => Set<OperationEntity>();
        public DbSet<StudentEntity> Students =>Set<StudentEntity>();

        
       

    }
}
