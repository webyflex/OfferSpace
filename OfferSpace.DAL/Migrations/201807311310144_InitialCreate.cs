namespace OfferSpace.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Catalog",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        ParentId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Catalog", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserId = c.String(),
                        CompanyId = c.Long(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Image = c.String(),
                        MarkAsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        ParentId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Location", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.RequestCustomerDiscusion",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        RequestCustomerId = c.Long(nullable: false),
                        Comment = c.String(),
                        ChangePrice = c.Boolean(nullable: false),
                        ChangeDate = c.Boolean(nullable: false),
                        MarkAsDeleted = c.Boolean(nullable: false),
                        AgreedFromCustomer = c.Boolean(nullable: false),
                        AgreedFromExecutor = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RequestCustomer", t => t.RequestCustomerId, cascadeDelete: true)
                .Index(t => t.RequestCustomerId);
            
            CreateTable(
                "dbo.RequestCustomer",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        RequestId = c.Long(),
                        CustomerId = c.Long(),
                        ScheduleOn = c.DateTime(nullable: false),
                        MarkAsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfile", t => t.CustomerId)
                .ForeignKey("dbo.Request", t => t.RequestId)
                .Index(t => t.RequestId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Request",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        CatalogId = c.Long(),
                        LocationId = c.Long(),
                        MinPrice = c.Int(),
                        MaxPrice = c.Int(),
                        Description = c.String(),
                        CustomerId = c.Long(),
                        ScheduleFrom = c.DateTime(nullable: false),
                        ScheduleTo = c.DateTime(nullable: false),
                        RequestCustomerId = c.Long(),
                        MarkAsDeleted = c.Boolean(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Catalog", t => t.CatalogId)
                .ForeignKey("dbo.UserProfile", t => t.CustomerId)
                .ForeignKey("dbo.Location", t => t.LocationId)
                .Index(t => t.CatalogId)
                .Index(t => t.LocationId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.RequestCustomerDiscusion", "RequestCustomerId", "dbo.RequestCustomer");
            DropForeignKey("dbo.RequestCustomer", "RequestId", "dbo.Request");
            DropForeignKey("dbo.Request", "LocationId", "dbo.Location");
            DropForeignKey("dbo.Request", "CustomerId", "dbo.UserProfile");
            DropForeignKey("dbo.Request", "CatalogId", "dbo.Catalog");
            DropForeignKey("dbo.RequestCustomer", "CustomerId", "dbo.UserProfile");
            DropForeignKey("dbo.Location", "ParentId", "dbo.Location");
            DropForeignKey("dbo.UserProfile", "CompanyId", "dbo.Company");
            DropForeignKey("dbo.Catalog", "ParentId", "dbo.Catalog");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Request", new[] { "CustomerId" });
            DropIndex("dbo.Request", new[] { "LocationId" });
            DropIndex("dbo.Request", new[] { "CatalogId" });
            DropIndex("dbo.RequestCustomer", new[] { "CustomerId" });
            DropIndex("dbo.RequestCustomer", new[] { "RequestId" });
            DropIndex("dbo.RequestCustomerDiscusion", new[] { "RequestCustomerId" });
            DropIndex("dbo.Location", new[] { "ParentId" });
            DropIndex("dbo.UserProfile", new[] { "CompanyId" });
            DropIndex("dbo.Catalog", new[] { "ParentId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Request");
            DropTable("dbo.RequestCustomer");
            DropTable("dbo.RequestCustomerDiscusion");
            DropTable("dbo.Location");
            DropTable("dbo.Company");
            DropTable("dbo.UserProfile");
            DropTable("dbo.Catalog");
        }
    }
}
