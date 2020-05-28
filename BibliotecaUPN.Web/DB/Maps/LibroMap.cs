using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using BibliotecaUPN.Web.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaUPN.Web.DB.Maps
{
    public class LibroMap : EntityTypeConfiguration<Libro>
    {
        public LibroMap()
        {
            ToTable("Libro");
            HasKey(o => o.Id);

            Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(o => o.Autor)
                .WithMany()
                .HasForeignKey(o => o.AutorId);

            HasMany(o => o.Comentarios)
                .WithRequired()
                .HasForeignKey(o => o.LibroId);
        }
    }
}