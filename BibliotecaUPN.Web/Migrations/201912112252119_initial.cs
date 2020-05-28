namespace BibliotecaUPN.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Autor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombres = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Biblioteca",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        LibroId = c.Int(nullable: false),
                        Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Libro", t => t.LibroId, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId)
                .Index(t => t.LibroId);
            
            CreateTable(
                "dbo.Libro",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Imagen = c.String(),
                        AutorId = c.Int(nullable: false),
                        Puntaje = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Autor", t => t.AutorId, cascadeDelete: true)
                .Index(t => t.AutorId);
            
            CreateTable(
                "dbo.Comentario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LibroId = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                        Texto = c.String(),
                        Puntaje = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId, cascadeDelete: true)
                .ForeignKey("dbo.Libro", t => t.LibroId, cascadeDelete: true)
                .Index(t => t.LibroId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Nombres = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Biblioteca", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Biblioteca", "LibroId", "dbo.Libro");
            DropForeignKey("dbo.Comentario", "LibroId", "dbo.Libro");
            DropForeignKey("dbo.Comentario", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Libro", "AutorId", "dbo.Autor");
            DropIndex("dbo.Comentario", new[] { "UsuarioId" });
            DropIndex("dbo.Comentario", new[] { "LibroId" });
            DropIndex("dbo.Libro", new[] { "AutorId" });
            DropIndex("dbo.Biblioteca", new[] { "LibroId" });
            DropIndex("dbo.Biblioteca", new[] { "UsuarioId" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Comentario");
            DropTable("dbo.Libro");
            DropTable("dbo.Biblioteca");
            DropTable("dbo.Autor");
        }
    }
}
