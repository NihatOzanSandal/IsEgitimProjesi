namespace SeviyeBelirlemeIcinETicaret.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UrunAdiEklendi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Urunlers", "UrunAdi", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Urunlers", "UrunAdi");
        }
    }
}
