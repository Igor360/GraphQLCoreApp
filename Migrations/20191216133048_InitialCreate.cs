using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication3GraphQL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sensor_data",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    created_at = table.Column<DateTime>(nullable: true),
                    updated_at = table.Column<DateTime>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    value = table.Column<string>(nullable: true),
                    code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sensor_data", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    created_at = table.Column<DateTime>(nullable: true),
                    updated_at = table.Column<DateTime>(nullable: true),
                    username = table.Column<string>(maxLength: 60, nullable: false),
                    email = table.Column<string>(maxLength: 100, nullable: false),
                    password_hash = table.Column<byte[]>(nullable: true),
                    password_salt = table.Column<byte[]>(nullable: true),
                    email_confirmed = table.Column<short>(nullable: false),
                    first_name = table.Column<string>(maxLength: 60, nullable: true),
                    last_name = table.Column<string>(maxLength: 60, nullable: true),
                    token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sensors_groups",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    created_at = table.Column<DateTime>(nullable: true),
                    updated_at = table.Column<DateTime>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    user_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sensors_groups", x => x.id);
                    table.ForeignKey(
                        name: "FK_sensors_groups_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "group_sensors",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    created_at = table.Column<DateTime>(nullable: true),
                    updated_at = table.Column<DateTime>(nullable: true),
                    sensor_id = table.Column<int>(nullable: false),
                    group_id = table.Column<int>(nullable: false),
                    SensorsGroupsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_group_sensors", x => x.id);
                    table.ForeignKey(
                        name: "FK_group_sensors_sensor_data_sensor_id",
                        column: x => x.sensor_id,
                        principalTable: "sensor_data",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_group_sensors_sensors_groups_SensorsGroupsId",
                        column: x => x.SensorsGroupsId,
                        principalTable: "sensors_groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_group_sensors_sensor_id",
                table: "group_sensors",
                column: "sensor_id");

            migrationBuilder.CreateIndex(
                name: "IX_group_sensors_SensorsGroupsId",
                table: "group_sensors",
                column: "SensorsGroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_sensors_groups_user_id",
                table: "sensors_groups",
                column: "user_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "group_sensors");

            migrationBuilder.DropTable(
                name: "sensor_data");

            migrationBuilder.DropTable(
                name: "sensors_groups");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
