namespace SeviyeBelirlemeIcinETicaret.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KullaniciIdSepet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sepets", "KullaniciId", c => c.Int(nullable: false));
            DropColumn("dbo.Sepets", "KullaniciAdi");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sepets", "KullaniciAdi", c => c.String(nullable: false));
            DropColumn("dbo.Sepets", "KullaniciId");
        }
    }
}
