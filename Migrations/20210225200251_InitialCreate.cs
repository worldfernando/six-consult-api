using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SixConsultApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "profiles",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    create = table.Column<bool>(type: "boolean", nullable: false),
                    update = table.Column<bool>(type: "boolean", nullable: false),
                    delete = table.Column<bool>(type: "boolean", nullable: false),
                    is_admin = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profiles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    profile_id = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_profiles_profile_id",
                        column: x => x.profile_id,
                        principalSchema: "public",
                        principalTable: "profiles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ftni = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    name = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    trade_name = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    contact_email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    contact_phone = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    user_created_id = table.Column<long>(type: "bigint", nullable: false),
                    user_updated_id = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.id);
                    table.ForeignKey(
                        name: "FK_customers_users_user_created_id",
                        column: x => x.user_created_id,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_customers_users_user_updated_id",
                        column: x => x.user_updated_id,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "profiles",
                columns: new[] { "id", "create", "created_at", "delete", "is_admin", "name", "update", "updated_at" },
                values: new object[] { 1L, true, new DateTime(2021, 2, 25, 17, 2, 50, 196, DateTimeKind.Local).AddTicks(1460), true, true, "Administrador do Sistema", true, new DateTime(2021, 2, 25, 17, 2, 50, 197, DateTimeKind.Local).AddTicks(4675) });

            migrationBuilder.InsertData(
                schema: "public",
                table: "users",
                columns: new[] { "id", "created_at", "email", "name", "password", "profile_id", "updated_at" },
                values: new object[] { 1L, new DateTime(2021, 2, 25, 17, 2, 50, 519, DateTimeKind.Local).AddTicks(5361), "admin@admin.com.br", "Administrador", "$2a$11$/MYrqrxOvRaLHQd01i/TguHLB6cfPznT5WekJ1oLLOfAL1sQLTY0.", 1L, new DateTime(2021, 2, 25, 17, 2, 50, 519, DateTimeKind.Local).AddTicks(5386) });

            migrationBuilder.CreateIndex(
                name: "IX_customers_user_created_id",
                schema: "public",
                table: "customers",
                column: "user_created_id");

            migrationBuilder.CreateIndex(
                name: "IX_customers_user_updated_id",
                schema: "public",
                table: "customers",
                column: "user_updated_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_profile_id",
                schema: "public",
                table: "users",
                column: "profile_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customers",
                schema: "public");

            migrationBuilder.DropTable(
                name: "users",
                schema: "public");

            migrationBuilder.DropTable(
                name: "profiles",
                schema: "public");
        }
    }
}
