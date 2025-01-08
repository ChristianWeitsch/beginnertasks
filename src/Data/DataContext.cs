using BeginnerTasks.Models;
using Microsoft.EntityFrameworkCore;
using Type = BeginnerTasks.Models.Type;

namespace BeginnerTasks.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
    
    public DbSet<Quote> Quotations { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<QuoteText> QuoteTexts { get; set; }
    public DbSet<Type> Types { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Quote
        modelBuilder.Entity<Quote>()
            .HasKey(x => x.Id);
        //Author
        modelBuilder.Entity<Author>()
            .HasKey(x => x.AutorId);
        //QuoteText
        modelBuilder.Entity<QuoteText>()
            .HasKey(x => x.QuoteTextId);
        
        modelBuilder.Entity<QuoteText>()
            .HasOne<Author>(x => x.Author)
            .WithMany(x=> x.Quotes)
            .HasForeignKey(x => x.AuthorId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<QuoteText>()
            .HasOne<Type>(x => x.QuoteType)
            .WithMany(x => x.Quotes)
            .HasForeignKey(x => x.TypeId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
            
        //Type
        modelBuilder.Entity<Type>()
            .HasKey(x => x.TypeId);
    }
    
}
