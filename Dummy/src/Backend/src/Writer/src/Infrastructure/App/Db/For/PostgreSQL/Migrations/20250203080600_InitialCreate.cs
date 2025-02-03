using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Makc2024.Dummy.Writer.Infrastructure.App.Db.For.PostgreSQL.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
  /// <inheritdoc />
  protected override void Up(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.EnsureSchema(
        name: "writer");

    migrationBuilder.CreateTable(
        name: "app_event",
        schema: "writer",
        columns: table => new
        {
          id = table.Column<long>(type: "bigint", nullable: false)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
          сoncurrency_token = table.Column<Guid>(type: "uuid", nullable: false),
          created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
          is_published = table.Column<bool>(type: "boolean", nullable: false),
          name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("pk_app_event", x => x.id);
        });

    migrationBuilder.CreateTable(
        name: "dummy_item",
        schema: "writer",
        columns: table => new
        {
          id = table.Column<long>(type: "bigint", nullable: false)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
          сoncurrency_token = table.Column<Guid>(type: "uuid", nullable: false),
          name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("pk_dummy_item", x => x.id);
        });

    migrationBuilder.CreateTable(
        name: "app_event_payload",
        schema: "writer",
        columns: table => new
        {
          Id = table.Column<long>(type: "bigint", nullable: false)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
          app_event_id = table.Column<long>(type: "bigint", nullable: false),
          сoncurrency_token = table.Column<Guid>(type: "uuid", nullable: false),
          data = table.Column<string>(type: "text", nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("pk_app_event_payload", x => x.Id);
          table.ForeignKey(
                    name: "fk_app_event_payload_app_event",
                    column: x => x.app_event_id,
                    principalSchema: "writer",
                    principalTable: "app_event",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
        });

    migrationBuilder.CreateIndex(
        name: "IX_app_event_payload_app_event_id",
        schema: "writer",
        table: "app_event_payload",
        column: "app_event_id");

    migrationBuilder.CreateIndex(
        name: "ux_dummy_item_name",
        schema: "writer",
        table: "dummy_item",
        column: "name",
        unique: true);
  }

  /// <inheritdoc />
  protected override void Down(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.DropTable(
        name: "app_event_payload",
        schema: "writer");

    migrationBuilder.DropTable(
        name: "dummy_item",
        schema: "writer");

    migrationBuilder.DropTable(
        name: "app_event",
        schema: "writer");
  }
}
