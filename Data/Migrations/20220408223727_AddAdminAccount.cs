using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Text;

#nullable disable

namespace Coffee_store.Data.Migrations
{
    public partial class AddAdminAccount : Migration
    {
        const string ADMIN_USER_GUID = "62b2b8bd-8daf-40fc-afcd-4482633cdc90";
        const string ADMIN_ROLE_GUID = "b07587b9-75aa-41d2-8c7f-fbb1a2c52fba";
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            var passwordHash = hasher.HashPassword(null, "adminPassword");
            StringBuilder sb = new();
            sb.AppendLine("INSERT INTO AspNetUsers(Id,UserName,NormalizedUserName,Email,EmailConfirmed,PhoneNumberConfirmed," +
                "TwoFactorEnabled,LockoutEnabled,AccessFailedCount, NormalizedEmail, PasswordHash,SecurityStamp,FirstName,LastName)");
            sb.AppendLine(" VALUES(");
            sb.AppendLine($"'{ADMIN_USER_GUID}'");
            sb.AppendLine($", 'youlox12345@yandex.ru'");
            sb.AppendLine($", 'YOULOX12345@YANDEX.RU'");
            sb.AppendLine($", 'youlox12345@yandex.ru'");
            sb.AppendLine($", '0'");
            sb.AppendLine($", '0'");
            sb.AppendLine($", '0'");
            sb.AppendLine($", '0'");
            sb.AppendLine($", '0'");            
            sb.AppendLine($", 'YOULOX12345@YANDEX.RU'");
            sb.AppendLine($", '{passwordHash}'");
            sb.AppendLine($", ''");
            sb.AppendLine($", 'Fedor'");
            sb.AppendLine($", 'Suslov'");
            sb.AppendLine(")");

            migrationBuilder.Sql(sb.ToString());
            migrationBuilder.Sql($"INSERT INTO AspNetRoles(Id,Name,NormalizedName) VALUES('{ADMIN_ROLE_GUID}','Admin','ADMIN')");
            migrationBuilder.Sql($"INSERT INTO AspNetUserRoles(UserId,RoleId) VALUES('{ADMIN_USER_GUID}','{ADMIN_ROLE_GUID}')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DELETE FROM AspNetUserRoles WHERE UserId = '{ADMIN_USER_GUID}' AND RoleId = '{ADMIN_ROLE_GUID}'");
            migrationBuilder.Sql($"DELETE FROM AspNetUsers WHERE UserId = '{ADMIN_USER_GUID}'");
            migrationBuilder.Sql($"DELETE FROM AspNetRoles WHERE RoleId = '{ADMIN_ROLE_GUID}'");
        }
    }
}
