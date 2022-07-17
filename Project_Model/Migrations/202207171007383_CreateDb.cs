namespace Project_Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                        DateOfVisit = c.DateTime(nullable: false),
                        NumberOfSessions = c.Int(nullable: false),
                        Payment = c.Int(nullable: false),
                        PaymentNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T_Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.T_Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.T_Group", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.DoctorId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.T_Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Phone = c.String(nullable: false, maxLength: 30),
                        Country = c.String(maxLength: 30),
                        ImageName = c.String(maxLength: 30),
                        RegisterDate = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 30),
                        TotalPayment = c.Int(nullable: false),
                        NumberOfTotalSessions = c.Int(nullable: false),
                        Credit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.T_Doctors",
                c => new
                    {
                        DoctorId = c.Int(nullable: false, identity: true),
                        Phone = c.String(nullable: false, maxLength: 30),
                        Name = c.String(nullable: false, maxLength: 30),
                        ImageName = c.String(),
                        RegisterDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Password = c.String(nullable: false, maxLength: 30),
                        CardNumber = c.String(maxLength: 30),
                        AccountNumber = c.String(maxLength: 30),
                        TotalSale = c.Int(nullable: false),
                        TotalIncome = c.Int(nullable: false),
                        CommissionPercent = c.Int(nullable: false),
                        TotalCheckedOut = c.Int(nullable: false),
                        Credit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DoctorId);
            
            CreateTable(
                "dbo.T_Group",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        GroupName = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.GroupId);
            
            CreateTable(
                "dbo.T_Payment",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        DoctorId = c.Int(nullable: false),
                        PayedMoney = c.Int(nullable: false),
                        PayedTime = c.DateTime(nullable: false),
                        PaymentNumber = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.PaymentId)
                .ForeignKey("dbo.T_Doctors", t => t.DoctorId, cascadeDelete: true)
                .Index(t => t.DoctorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T_Payment", "DoctorId", "dbo.T_Doctors");
            DropForeignKey("dbo.T_Appointments", "GroupId", "dbo.T_Group");
            DropForeignKey("dbo.T_Appointments", "DoctorId", "dbo.T_Doctors");
            DropForeignKey("dbo.T_Appointments", "CustomerId", "dbo.T_Customers");
            DropIndex("dbo.T_Payment", new[] { "DoctorId" });
            DropIndex("dbo.T_Appointments", new[] { "GroupId" });
            DropIndex("dbo.T_Appointments", new[] { "DoctorId" });
            DropIndex("dbo.T_Appointments", new[] { "CustomerId" });
            DropTable("dbo.T_Payment");
            DropTable("dbo.T_Group");
            DropTable("dbo.T_Doctors");
            DropTable("dbo.T_Customers");
            DropTable("dbo.T_Appointments");
        }
    }
}
