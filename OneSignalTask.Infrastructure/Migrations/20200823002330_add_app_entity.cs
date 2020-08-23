using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OneSignalTask.Infrastructure
{
    public partial class add_app_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apps",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Players = table.Column<long>(nullable: false),
                    MessagablePlayers = table.Column<long>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    GcmKey = table.Column<string>(nullable: true),
                    ChromeKey = table.Column<string>(nullable: true),
                    ChromeWebOrigin = table.Column<string>(nullable: true),
                    ChromeWebGcmSenderId = table.Column<string>(nullable: true),
                    ChromeWebDefaultNotificationIcon = table.Column<string>(nullable: true),
                    ChromeWebSubDomain = table.Column<string>(nullable: true),
                    ApnsEnv = table.Column<string>(nullable: true),
                    ApnsCertificates = table.Column<string>(nullable: true),
                    SafariApnsCertificate = table.Column<string>(nullable: true),
                    SafariSiteOrigin = table.Column<string>(nullable: true),
                    SafariPushId = table.Column<string>(nullable: true),
                    SafariIcon16 = table.Column<string>(nullable: true),
                    SafariIcon32 = table.Column<string>(nullable: true),
                    SafariIcon64 = table.Column<string>(nullable: true),
                    SafariIcon128 = table.Column<string>(nullable: true),
                    SafariIcon256 = table.Column<string>(nullable: true),
                    SiteName = table.Column<string>(nullable: true),
                    BasicAuthKey = table.Column<string>(nullable: true),
                    ApnsP12 = table.Column<string>(nullable: true),
                    ApnsP12Password = table.Column<string>(nullable: true),
                    AndroidGcmSenderId = table.Column<string>(nullable: true),
                    SafariApnsP12 = table.Column<string>(nullable: true),
                    SafariApnsP12Password = table.Column<string>(nullable: true),
                    AdditionalDataIsRootPayload = table.Column<bool>(nullable: false),
                    OrganizationId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apps", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apps");
        }
    }
}
