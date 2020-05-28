using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using BibliotecaUPN.Web.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaUPN.Web.DB.Maps
{
    public class AutorMap : EntityTypeConfiguration<Autor>
    {
        public AutorMap()
        {
            ToTable("Autor");
            HasKey(o => o.Id);

            Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}