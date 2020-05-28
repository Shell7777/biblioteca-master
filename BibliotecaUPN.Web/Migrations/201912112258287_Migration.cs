namespace BibliotecaUPN.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Autor", "Nombres", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Autor", "Nombres", c => c.Int(nullable: false));
        }
    }
}
