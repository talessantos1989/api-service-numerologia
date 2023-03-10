using Microsoft.EntityFrameworkCore;
using NumerologiaCabalistica.Models.DiasMesFavoraveis;
using NumerologiaCabalistica.Models.MapaRelatorio;
using NumerologiaCabalistica.Models.TextosNumericos;
using System.Xml.Serialization;

namespace NumerologiaCabalistica.Data
{
    public class NumerologiaCabalisticaDbContext : DbContext
    {
        public NumerologiaCabalisticaDbContext(DbContextOptions<NumerologiaCabalisticaDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TextoNumericoModel>()
                .HasOne(texto => texto.Categoria)
                .WithMany(categoria => categoria.TextoNumerico)
                .HasForeignKey(texto => texto.CategoriaId);


            builder.Entity<DiaDoMesFavoravelModel>()
                .HasOne(dia => dia.Mes)
                .WithMany(mes => mes.DiasDoMesFavoraveis)
                .HasForeignKey(dia => dia.MesId);
        }
        public DbSet<CategoriaNumeroPessoalModel> CategoriaNumero{ get; set; }

        public DbSet<TextoNumericoModel> TextoNumerico { get; set; }

        public DbSet<DiaDoMesFavoravelModel> DiasDoMesFavoraveis{ get; set; }

        public DbSet<MesModel> Mes { get; set; }
    }

}
