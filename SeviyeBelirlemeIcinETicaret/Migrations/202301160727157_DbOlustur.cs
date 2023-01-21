namespace SeviyeBelirlemeIcinETicaret.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbOlustur : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kullanicilars",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        KullaniciAdi = c.String(nullable: false),
                        Sifre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Sepets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        KullaniciAdi = c.String(nullable: false),
                        UrunId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Urunlers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        KategoriId = c.Int(nullable: false),
                        Fiyat = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Urunlers");
            DropTable("dbo.Sepets");
            DropTable("dbo.Kullanicilars");
        }
    }
}
