using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace my_championship.Migrations
{
    /// <inheritdoc />
    public partial class AddTeamsAndKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Team_Championships_ChampionshipId",
                schema: "public",
                table: "Team");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Team",
                schema: "public",
                table: "Team");

            migrationBuilder.RenameTable(
                name: "Team",
                schema: "public",
                newName: "Teams",
                newSchema: "public");

            migrationBuilder.RenameIndex(
                name: "IX_Team_ChampionshipId",
                schema: "public",
                table: "Teams",
                newName: "IX_Teams_ChampionshipId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                schema: "public",
                table: "Teams",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TeamKeys",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ChampionshipId = table.Column<Guid>(type: "uuid", nullable: false),
                    TeamId = table.Column<Guid>(type: "uuid", nullable: false),
                    Key = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamKeys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamKeys_Championships_ChampionshipId",
                        column: x => x.ChampionshipId,
                        principalSchema: "public",
                        principalTable: "Championships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamKeys_Teams_TeamId",
                        column: x => x.TeamId,
                        principalSchema: "public",
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamKeys_ChampionshipId",
                schema: "public",
                table: "TeamKeys",
                column: "ChampionshipId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamKeys_TeamId",
                schema: "public",
                table: "TeamKeys",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Championships_ChampionshipId",
                schema: "public",
                table: "Teams",
                column: "ChampionshipId",
                principalSchema: "public",
                principalTable: "Championships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Championships_ChampionshipId",
                schema: "public",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "TeamKeys",
                schema: "public");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams",
                schema: "public",
                table: "Teams");

            migrationBuilder.RenameTable(
                name: "Teams",
                schema: "public",
                newName: "Team",
                newSchema: "public");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_ChampionshipId",
                schema: "public",
                table: "Team",
                newName: "IX_Team_ChampionshipId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Team",
                schema: "public",
                table: "Team",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_Championships_ChampionshipId",
                schema: "public",
                table: "Team",
                column: "ChampionshipId",
                principalSchema: "public",
                principalTable: "Championships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
