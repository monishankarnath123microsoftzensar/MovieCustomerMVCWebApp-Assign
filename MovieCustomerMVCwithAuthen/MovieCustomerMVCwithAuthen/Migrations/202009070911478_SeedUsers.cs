namespace MovieCustomerMVCwithAuthen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2c6f32de-d913-4b2c-87b5-3c3270f96ac7', N'moni@gmail.com', 0, N'AGq962wBfO2FvfdbZXE7eDi40lkTbPXzwKkSkD7xeY//UGyzfhtnKhfBwWEQReDB0w==', N'0bb0235c-ebf9-4e32-9d2c-2b630ea1a1ab', NULL, 0, 0, NULL, 1, 0, N'moni@gmail.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'be718e2a-66ea-42c4-be72-df14cf2a55a9', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2c6f32de-d913-4b2c-87b5-3c3270f96ac7', N'be718e2a-66ea-42c4-be72-df14cf2a55a9')

");
        }
        
        public override void Down()
        {
        }
    }
}
