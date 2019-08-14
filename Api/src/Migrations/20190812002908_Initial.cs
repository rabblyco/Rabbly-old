using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Debates",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Topic = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedById = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Debates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Profile_UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Profile_CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Profile_Username = table.Column<string>(nullable: true),
                    Profile_Gender = table.Column<string>(nullable: true, defaultValue: "Secret"),
                    Profile_ImageUrl = table.Column<string>(nullable: true),
                    Profile_Ideology = table.Column<string>(nullable: true),
                    Profile_Country = table.Column<string>(nullable: true, defaultValue: "None"),
                    Profile_State = table.Column<string>(nullable: true, defaultValue: "None"),
                    Profile_ZipCode = table.Column<string>(nullable: true),
                    Profile_SocialCoordinate = table.Column<decimal>(nullable: false),
                    Profile_EconomicCoordinate = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Text = table.Column<string>(nullable: true),
                    DebateId = table.Column<string>(nullable: true),
                    CreatedById = table.Column<string>(nullable: true),
                    ParentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Debates_DebateId",
                        column: x => x.DebateId,
                        principalTable: "Debates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Comments_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Polls",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Topic = table.Column<string>(nullable: true),
                    CreatedById = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Polls_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScoreCards",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Opinion = table.Column<string>(nullable: false, defaultValue: "Neutral"),
                    SentimentalAppeal = table.Column<int>(nullable: false, defaultValue: 0),
                    RedHerring = table.Column<int>(nullable: false, defaultValue: 0),
                    ScareTactic = table.Column<int>(nullable: false, defaultValue: 0),
                    Bandwagon = table.Column<int>(nullable: false, defaultValue: 0),
                    SlipperySlope = table.Column<int>(nullable: false, defaultValue: 0),
                    FalseDilemma = table.Column<int>(nullable: false, defaultValue: 0),
                    FalseNeed = table.Column<int>(nullable: false, defaultValue: 0),
                    FalseAuthority = table.Column<int>(nullable: false, defaultValue: 0),
                    FalseAssociation = table.Column<int>(nullable: false, defaultValue: 0),
                    Dogmatism = table.Column<int>(nullable: false, defaultValue: 0),
                    MoralEquivalence = table.Column<int>(nullable: false, defaultValue: 0),
                    AdHominem = table.Column<int>(nullable: false, defaultValue: 0),
                    StrawPerson = table.Column<int>(nullable: false, defaultValue: 0),
                    HastyGeneralization = table.Column<int>(nullable: false, defaultValue: 0),
                    FaultyCausality = table.Column<int>(nullable: false, defaultValue: 0),
                    NonSequitor = table.Column<int>(nullable: false, defaultValue: 0),
                    Equivocation = table.Column<int>(nullable: false, defaultValue: 0),
                    BeggingTheQuestion = table.Column<int>(nullable: false, defaultValue: 0),
                    FaultyAnalogy = table.Column<int>(nullable: false, defaultValue: 0),
                    StackedEvidence = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScoreCards_Comments_Id",
                        column: x => x.Id,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScoreCards_Debates_Id",
                        column: x => x.Id,
                        principalTable: "Debates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScoreCards_Polls_Id",
                        column: x => x.Id,
                        principalTable: "Polls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScoreCards_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CreatedById",
                table: "Comments",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_DebateId",
                table: "Comments",
                column: "DebateId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParentId",
                table: "Comments",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Polls_CreatedById",
                table: "Polls",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Profile_Username",
                table: "Users",
                column: "Profile_Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScoreCards");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Polls");

            migrationBuilder.DropTable(
                name: "Debates");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
