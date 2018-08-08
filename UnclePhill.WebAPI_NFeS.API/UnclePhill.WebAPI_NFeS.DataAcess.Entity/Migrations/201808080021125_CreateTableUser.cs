namespace UnclePhill.WebAPI_NFeS.DataAcess.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        CPF = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
