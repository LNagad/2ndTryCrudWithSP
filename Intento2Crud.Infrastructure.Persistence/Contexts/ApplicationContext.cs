using Intento2Crud.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Intento2Crud.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<PokemonType> PokemonTypes { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<PokemonView> PokemonView { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<Pokemon>().HasKey(p => p.Id);
            modelBuilder.Entity<PokemonType>().HasKey(p => p.Id);
            modelBuilder.Entity<Region>().HasKey(p => p.Id);

            modelBuilder.Entity<Pokemon>().ToTable("Pokemons");
            modelBuilder.Entity<PokemonType>().ToTable("PokemonTypes");
            modelBuilder.Entity<Region>().ToTable("Regions");

            modelBuilder.Entity<Pokemon>()
                .HasOne(p => p.Region)
                .WithMany(re => re.Pokemons)
                .HasForeignKey(p => p.RegionId);

            modelBuilder.Entity<Pokemon>()
                .HasOne(p => p.PrimaryType)
                .WithMany()
                .HasForeignKey(p => p.PrimaryTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Pokemon>()
                .HasOne(p => p.SecondaryType)
                .WithMany()
                .HasForeignKey(p => p.SecondaryTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            

        }
    }
}
