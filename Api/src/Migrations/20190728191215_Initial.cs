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
                    Topic = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedById = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Debates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScoreCards",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Opinion = table.Column<int>(nullable: false),
                    AdHominem = table.Column<int>(nullable: false),
                    Strawman = table.Column<int>(nullable: false),
                    FalseCause = table.Column<int>(nullable: false),
                    EmotionAppeal = table.Column<int>(nullable: false),
                    FallacyFallacy = table.Column<int>(nullable: false),
                    SlipperySlope = table.Column<int>(nullable: false),
                    TuQuoque = table.Column<int>(nullable: false),
                    PersonalIncredulity = table.Column<int>(nullable: false),
                    SpecialPleading = table.Column<int>(nullable: false),
                    LoadedQuestion = table.Column<int>(nullable: false),
                    BurdenProof = table.Column<int>(nullable: false),
                    Ambiguity = table.Column<int>(nullable: false),
                    GamblerFallacy = table.Column<int>(nullable: false),
                    Bandwagon = table.Column<int>(nullable: false),
                    AuthorityAppeal = table.Column<int>(nullable: false),
                    CompositionDivision = table.Column<int>(nullable: false),
                    NoTrueScotsman = table.Column<int>(nullable: false),
                    Genetic = table.Column<int>(nullable: false),
                    FalseDilemma = table.Column<int>(nullable: false),
                    BeggingQuestion = table.Column<int>(nullable: false),
                    AppealToNature = table.Column<int>(nullable: false),
                    Anecdotal = table.Column<int>(nullable: false),
                    CherryPick = table.Column<int>(nullable: false),
                    MiddleGround = table.Column<int>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CommentId = table.Column<string>(nullable: true),
                    DebateId = table.Column<string>(nullable: true),
                    PollId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScoreCards_Debates_DebateId",
                        column: x => x.DebateId,
                        principalTable: "Debates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    DebateId = table.Column<string>(nullable: true),
                    CreatedById = table.Column<string>(nullable: true),
                    ParentId = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
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
                name: "Ranks",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    GroupId = table.Column<string>(nullable: true),
                    Permissions_CanCreateRole = table.Column<bool>(nullable: false, defaultValue: false),
                    Permissions_CanCreateDiscussion = table.Column<bool>(nullable: false, defaultValue: false),
                    Permissions_CanAddMember = table.Column<bool>(nullable: false, defaultValue: false),
                    Permissions_CanAddRank = table.Column<bool>(nullable: false, defaultValue: false),
                    Permissions_CanEditGroup = table.Column<bool>(nullable: false, defaultValue: false),
                    Permissions_CanEditRankPermissions = table.Column<bool>(nullable: false, defaultValue: false),
                    Permissions_CanEditMemberRank = table.Column<bool>(nullable: false, defaultValue: false),
                    Permissions_CanRemoveMember = table.Column<bool>(nullable: false, defaultValue: false),
                    Permissions_CanRemoveRank = table.Column<bool>(nullable: false, defaultValue: false),
                    Permissions_CanRepresentGroup = table.Column<bool>(nullable: false, defaultValue: false),
                    Permissions_CanParticipateInGroupDiscussion = table.Column<bool>(nullable: false, defaultValue: false),
                    Permissions_UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Permissions_CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    RankId = table.Column<string>(nullable: true),
                    Profile_Username = table.Column<string>(nullable: true),
                    Profile_Gender = table.Column<string>(nullable: true, defaultValue: "Secret"),
                    Profile_ImageUrl = table.Column<string>(nullable: true),
                    Profile_Ideology = table.Column<string>(nullable: true),
                    Profile_Country = table.Column<string>(nullable: true, defaultValue: "None"),
                    Profile_State = table.Column<string>(nullable: true, defaultValue: "None"),
                    Profile_ZipCode = table.Column<string>(nullable: true),
                    Profile_SocialCoordinate = table.Column<decimal>(nullable: false),
                    Profile_EconomicCoordinate = table.Column<decimal>(nullable: false),
                    GroupId = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    GroupId1 = table.Column<string>(nullable: true),
                    RankId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Ranks_RankId",
                        column: x => x.RankId,
                        principalTable: "Ranks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Ranks_RankId1",
                        column: x => x.RankId1,
                        principalTable: "Ranks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Bio = table.Column<string>(nullable: true),
                    LogoUrl = table.Column<string>(nullable: true),
                    OwnerId = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Polls",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Topic = table.Column<string>(nullable: true),
                    CreatedById = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
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
                name: "IX_Groups_Name",
                table: "Groups",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_OwnerId",
                table: "Groups",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Polls_CreatedById",
                table: "Polls",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Ranks_GroupId",
                table: "Ranks",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ScoreCards_CommentId",
                table: "ScoreCards",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_ScoreCards_DebateId",
                table: "ScoreCards",
                column: "DebateId");

            migrationBuilder.CreateIndex(
                name: "IX_ScoreCards_PollId",
                table: "ScoreCards",
                column: "PollId");

            migrationBuilder.CreateIndex(
                name: "IX_ScoreCards_UserId",
                table: "ScoreCards",
                column: "UserId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Users_GroupId",
                table: "Users",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_GroupId1",
                table: "Users",
                column: "GroupId1");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RankId",
                table: "Users",
                column: "RankId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RankId1",
                table: "Users",
                column: "RankId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ScoreCards_Users_UserId",
                table: "ScoreCards",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScoreCards_Comments_CommentId",
                table: "ScoreCards",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScoreCards_Polls_PollId",
                table: "ScoreCards",
                column: "PollId",
                principalTable: "Polls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_CreatedById",
                table: "Comments",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ranks_Groups_GroupId",
                table: "Ranks",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Groups_GroupId",
                table: "Users",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Groups_GroupId1",
                table: "Users",
                column: "GroupId1",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Users_OwnerId",
                table: "Groups");

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

            migrationBuilder.DropTable(
                name: "Ranks");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
