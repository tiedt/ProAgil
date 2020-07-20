using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain;
using ProAgil.Domain.Identity;

namespace ProAgil.Repository
{
    public class ProAgilContext : IdentityDbContext<Usuario,Papeis,int,
                                  IdentityUserClaim<int>,PapeisUsuario,
                                  IdentityUserLogin<int>,IdentityRoleClaim<int>,IdentityUserToken<int>>
    {
        public ProAgilContext(DbContextOptions<ProAgilContext> options) : base(options) { }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<PalestranteEvento> PalestranteEventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<RedeSocial> RedeSociais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PapeisUsuario>(papeisUsuario =>
             {
                 papeisUsuario.HasKey(pu => new {pu.UserId, pu.RoleId});
                 papeisUsuario.HasOne(pu => pu.Papeis)
                 .WithMany(p => p.PapeisUsuario)
                 .HasForeignKey(papeisUsuario => papeisUsuario.RoleId).IsRequired();

                 papeisUsuario.HasOne(pu => pu.Usuario)
                 .WithMany(p => p.PapeisUsuario)
                 .HasForeignKey(papeisUsuario => papeisUsuario.UserId).IsRequired();
             });
            modelBuilder.Entity<PalestranteEvento>()
            .HasKey(PE => new {PE.EventoId, PE.PalestranteId});
        }
    }
}