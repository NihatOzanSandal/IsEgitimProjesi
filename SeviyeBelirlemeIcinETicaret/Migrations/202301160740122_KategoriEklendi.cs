namespace SeviyeBelirlemeIcinETicaret.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KategoriEklendi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kategoris",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        KategoriAdi = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Kategoris");
        }
    }
}
