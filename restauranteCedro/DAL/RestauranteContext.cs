using restauranteCedro.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace restauranteCedro.DAL
{
    public class RestauranteContext : DbContext
    {
        public RestauranteContext(DbContextOptions<RestauranteContext> options) : base(options)
        {}
        public DbSet<Restaurante> Restaurantes { get; set; }
        public DbSet<Prato> Pratos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //RELACIONAMENTOS
            //UM PARA MUITOS
            modelBuilder.Entity<Prato>()
            .HasOne<Restaurante>(r => r.Restaurante)
            .WithMany(p => p.Pratos)
            .HasForeignKey(r => r.IdRestaurante);
        }
    }
}