using Microsoft.EntityFrameworkCore;

namespace SimpleImdbEfc;

public class ImdbContext : DbContext
{
    public DbSet<Show> Shows => Set<Show>();
    public DbSet<Review> Reviews => Set<Review>();
    public DbSet<Person> People => Set<Person>();
    public DbSet<Genre> Genres => Set<Genre>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = Imdb.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasKey(g => new { g.ShowId, g.Name });

        modelBuilder.Entity<Review>(builder =>
        {
            builder.HasKey(r => r.ShowId);
            builder.HasOne<Show>(r => r.Show)
                .WithOne(show => show.Review)
                .HasForeignKey<Review>(r => r.ShowId);
        });

        modelBuilder.Entity<Show>(builder =>
        {
            builder.HasMany<Person>(s => s.Stars)
                .WithMany(p => p.StarsIn)
                .UsingEntity(join => join.ToTable("Stars"));

            builder.HasMany<Person>(s => s.Writers)
                .WithMany(person => person.Writes)
                .UsingEntity(join => join.ToTable("Writers"));
        });
    }
}