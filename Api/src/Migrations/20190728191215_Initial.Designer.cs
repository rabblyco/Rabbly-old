﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RabblyApi.Data;

namespace Api.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20190728191215_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("RabblyApi.Comments.Models.Comment", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("CreatedById");

                    b.Property<string>("DebateId");

                    b.Property<string>("ParentId");

                    b.Property<string>("Text");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DebateId");

                    b.HasIndex("ParentId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("RabblyApi.Debates.Models.Debate", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("CreatedById");

                    b.Property<string>("Description");

                    b.Property<string>("Topic");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.ToTable("Debates");
                });

            modelBuilder.Entity("RabblyApi.Groups.Models.Group", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bio");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("LogoUrl");

                    b.Property<string>("Name");

                    b.Property<string>("OwnerId");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("OwnerId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("RabblyApi.Polls.Models.Poll", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("CreatedById");

                    b.Property<string>("Topic");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("Polls");
                });

            modelBuilder.Entity("RabblyApi.Ranks.Models.Rank", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("GroupId");

                    b.Property<int>("Level");

                    b.Property<string>("Title");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Ranks");
                });

            modelBuilder.Entity("RabblyApi.ScoreCards.Models.ScoreCard", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AdHominem");

                    b.Property<int>("Ambiguity");

                    b.Property<int>("Anecdotal");

                    b.Property<int>("AppealToNature");

                    b.Property<int>("AuthorityAppeal");

                    b.Property<int>("Bandwagon");

                    b.Property<int>("BeggingQuestion");

                    b.Property<int>("BurdenProof");

                    b.Property<int>("CherryPick");

                    b.Property<string>("CommentId");

                    b.Property<int>("CompositionDivision");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("DebateId");

                    b.Property<int>("EmotionAppeal");

                    b.Property<int>("FallacyFallacy");

                    b.Property<int>("FalseCause");

                    b.Property<int>("FalseDilemma");

                    b.Property<int>("GamblerFallacy");

                    b.Property<int>("Genetic");

                    b.Property<int>("LoadedQuestion");

                    b.Property<int>("MiddleGround");

                    b.Property<int>("NoTrueScotsman");

                    b.Property<int>("Opinion");

                    b.Property<int>("PersonalIncredulity");

                    b.Property<string>("PollId");

                    b.Property<int>("SlipperySlope");

                    b.Property<int>("SpecialPleading");

                    b.Property<int>("Strawman");

                    b.Property<int>("TuQuoque");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("DebateId");

                    b.HasIndex("PollId");

                    b.HasIndex("UserId");

                    b.ToTable("ScoreCards");
                });

            modelBuilder.Entity("RabblyApi.Users.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("GroupId");

                    b.Property<string>("GroupId1");

                    b.Property<string>("Password");

                    b.Property<string>("RankId");

                    b.Property<string>("RankId1");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("GroupId");

                    b.HasIndex("GroupId1");

                    b.HasIndex("RankId");

                    b.HasIndex("RankId1");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RabblyApi.Comments.Models.Comment", b =>
                {
                    b.HasOne("RabblyApi.Users.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("RabblyApi.Debates.Models.Debate")
                        .WithMany("Comments")
                        .HasForeignKey("DebateId");

                    b.HasOne("RabblyApi.Comments.Models.Comment", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("RabblyApi.Groups.Models.Group", b =>
                {
                    b.HasOne("RabblyApi.Users.Models.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");
                });

            modelBuilder.Entity("RabblyApi.Polls.Models.Poll", b =>
                {
                    b.HasOne("RabblyApi.Users.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");
                });

            modelBuilder.Entity("RabblyApi.Ranks.Models.Rank", b =>
                {
                    b.HasOne("RabblyApi.Groups.Models.Group", "Group")
                        .WithMany("Ranks")
                        .HasForeignKey("GroupId");

                    b.OwnsOne("RabblyApi.Permissions.Models.Permission", "Permissions", b1 =>
                        {
                            b1.Property<string>("Id");

                            b1.Property<bool>("CanAddMember")
                                .ValueGeneratedOnAdd()
                                .HasDefaultValue(false);

                            b1.Property<bool>("CanAddRank")
                                .ValueGeneratedOnAdd()
                                .HasDefaultValue(false);

                            b1.Property<bool>("CanCreateDiscussion")
                                .ValueGeneratedOnAdd()
                                .HasDefaultValue(false);

                            b1.Property<bool>("CanCreateRole")
                                .ValueGeneratedOnAdd()
                                .HasDefaultValue(false);

                            b1.Property<bool>("CanEditGroup")
                                .ValueGeneratedOnAdd()
                                .HasDefaultValue(false);

                            b1.Property<bool>("CanEditMemberRank")
                                .ValueGeneratedOnAdd()
                                .HasDefaultValue(false);

                            b1.Property<bool>("CanEditRankPermissions")
                                .ValueGeneratedOnAdd()
                                .HasDefaultValue(false);

                            b1.Property<bool>("CanParticipateInGroupDiscussion")
                                .ValueGeneratedOnAdd()
                                .HasDefaultValue(false);

                            b1.Property<bool>("CanRemoveMember")
                                .ValueGeneratedOnAdd()
                                .HasDefaultValue(false);

                            b1.Property<bool>("CanRemoveRank")
                                .ValueGeneratedOnAdd()
                                .HasDefaultValue(false);

                            b1.Property<bool>("CanRepresentGroup")
                                .ValueGeneratedOnAdd()
                                .HasDefaultValue(false);

                            b1.Property<DateTime>("CreatedAt")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("timestamp with time zone")
                                .HasDefaultValueSql("CURRENT_TIMESTAMP");

                            b1.Property<DateTime>("UpdatedAt")
                                .ValueGeneratedOnAddOrUpdate()
                                .HasColumnType("timestamp with time zone")
                                .HasDefaultValueSql("CURRENT_TIMESTAMP");

                            b1.HasKey("Id");

                            b1.ToTable("Ranks");

                            b1.HasOne("RabblyApi.Ranks.Models.Rank", "Rank")
                                .WithOne("Permissions")
                                .HasForeignKey("RabblyApi.Permissions.Models.Permission", "Id")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("RabblyApi.ScoreCards.Models.ScoreCard", b =>
                {
                    b.HasOne("RabblyApi.Comments.Models.Comment")
                        .WithMany("ScoreCard")
                        .HasForeignKey("CommentId");

                    b.HasOne("RabblyApi.Debates.Models.Debate")
                        .WithMany("ScoreCards")
                        .HasForeignKey("DebateId");

                    b.HasOne("RabblyApi.Polls.Models.Poll")
                        .WithMany("ScoreCard")
                        .HasForeignKey("PollId");

                    b.HasOne("RabblyApi.Users.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("RabblyApi.Users.Models.User", b =>
                {
                    b.HasOne("RabblyApi.Groups.Models.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId");

                    b.HasOne("RabblyApi.Groups.Models.Group")
                        .WithMany("Users")
                        .HasForeignKey("GroupId1");

                    b.HasOne("RabblyApi.Ranks.Models.Rank", "Rank")
                        .WithMany()
                        .HasForeignKey("RankId");

                    b.HasOne("RabblyApi.Ranks.Models.Rank")
                        .WithMany("Users")
                        .HasForeignKey("RankId1");

                    b.OwnsOne("RabblyApi.Profiles.Models.Profile", "Profile", b1 =>
                        {
                            b1.Property<string>("UserId");

                            b1.Property<string>("Country")
                                .ValueGeneratedOnAdd()
                                .HasDefaultValue("None");

                            b1.Property<decimal>("EconomicCoordinate");

                            b1.Property<string>("Gender")
                                .ValueGeneratedOnAdd()
                                .HasDefaultValue("Secret");

                            b1.Property<string>("Ideology");

                            b1.Property<string>("ImageUrl");

                            b1.Property<decimal>("SocialCoordinate");

                            b1.Property<string>("State")
                                .ValueGeneratedOnAdd()
                                .HasDefaultValue("None");

                            b1.Property<string>("Username");

                            b1.Property<string>("ZipCode");

                            b1.HasKey("UserId");

                            b1.HasIndex("Username")
                                .IsUnique();

                            b1.ToTable("Users");

                            b1.HasOne("RabblyApi.Users.Models.User", "User")
                                .WithOne("Profile")
                                .HasForeignKey("RabblyApi.Profiles.Models.Profile", "UserId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
