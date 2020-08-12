using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Webzine.Entity;

namespace Webzine.EntitiesContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DbSet<Titre> Titres { get; set; }

        public DbSet<Artiste> Artistes { get; set; }

        public DbSet<Style> Styles { get; set; }

        public DbSet<Commentaire> Commentaires { get; set; }

        public DbSet<LienTitreStyle> TitreStyles { get; set; }

        /// <summary>
        /// Configuration of the connection with SQLServer for the database.
        /// Here the name of the database is WebzineDbContext
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // New file for SQLite database
            //optionsBuilder.UseSqlite("Data Source=Webzine.db");

            // Connect to an SQLServer database
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=WebzineDbContext;Trusted_Connection=True;MultipleActiveResultSets=true;");
        }

        /// <summary>
        /// On creation of the model, tables are created.
        /// TitreStyle table contain 2 primary keys, id of title and style
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Titre>().ToTable("Titre").HasMany<LienTitreStyle>(t=>t.TitresStyles);
            modelBuilder.Entity<Artiste>().ToTable("Artiste").HasMany<Titre>(a => a.Titres).WithOne(t => t.Artiste).HasForeignKey(t=>t.IdArtiste); 
            modelBuilder.Entity<Style>().ToTable("Style").HasMany<LienTitreStyle>(s=>s.TitresStyles);
            modelBuilder.Entity<Commentaire>().ToTable("Commentaire").HasOne<Titre>(c=>c.Musique).WithMany(t=>t.Commentaires).HasForeignKey(c=>c.IdCommentaire);
            modelBuilder.Entity<LienTitreStyle>().ToTable("TitreStyle").HasKey(o => new { o.IdStyle, o.IdTitre });
            
            modelBuilder.Entity<LienTitreStyle>()
                .HasOne<Titre>(lts => lts.Titre)
                .WithMany(t => t.TitresStyles)
                .HasForeignKey(lts => lts.IdTitre);

            modelBuilder.Entity<LienTitreStyle>()
                .HasOne<Style>(lts => lts.Style)
                .WithMany(s => s.TitresStyles)
                .HasForeignKey(lts => lts.IdStyle);
        }
    }
}
