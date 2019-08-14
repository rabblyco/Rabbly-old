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
    [Migration("20190812002908_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
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

            modelBuilder.Entity("RabblyApi.Polls.Models.Poll", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedById");

                    b.Property<string>("Topic");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("Polls");
                });

            modelBuilder.Entity("RabblyApi.ScoreCards.Models.ScoreCard", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AdHominem")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<int>("Bandwagon")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<int>("BeggingTheQuestion")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("Dogmatism")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<int>("Equivocation")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<int>("FalseAssociation")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<int>("FalseAuthority")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<int>("FalseDilemma")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<int>("FalseNeed")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<int>("FaultyAnalogy")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<int>("FaultyCausality")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<int>("HastyGeneralization")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<int>("MoralEquivalence")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<int>("NonSequitor")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<string>("Opinion")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("Neutral");

                    b.Property<int>("RedHerring")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<int>("ScareTactic")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<int>("SentimentalAppeal")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<int>("SlipperySlope")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<int>("StackedEvidence")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<int>("StrawPerson")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

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

                    b.Property<string>("Password");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

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

            modelBuilder.Entity("RabblyApi.Polls.Models.Poll", b =>
                {
                    b.HasOne("RabblyApi.Users.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");
                });

            modelBuilder.Entity("RabblyApi.ScoreCards.Models.ScoreCard", b =>
                {
                    b.HasOne("RabblyApi.Comments.Models.Comment", "Comment")
                        .WithMany("ScoreCards")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RabblyApi.Debates.Models.Debate", "Debate")
                        .WithMany("ScoreCards")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RabblyApi.Polls.Models.Poll", "Poll")
                        .WithMany("ScoreCards")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RabblyApi.Users.Models.User", "User")
                        .WithMany("ScoreCards")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RabblyApi.Users.Models.User", b =>
                {
                    b.OwnsOne("RabblyApi.Profiles.Models.Profile", "Profile", b1 =>
                        {
                            b1.Property<string>("Id")
                                .ValueGeneratedOnAdd();

                            b1.Property<string>("Country")
                                .ValueGeneratedOnAdd()
                                .HasDefaultValue("None");

                            b1.Property<DateTime>("CreatedAt")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("timestamp with time zone")
                                .HasDefaultValueSql("CURRENT_TIMESTAMP");

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

                            b1.Property<DateTime>("UpdatedAt")
                                .ValueGeneratedOnAddOrUpdate()
                                .HasColumnType("timestamp with time zone")
                                .HasDefaultValueSql("CURRENT_TIMESTAMP");

                            b1.Property<string>("Username");

                            b1.Property<string>("ZipCode");

                            b1.HasKey("Id");

                            b1.HasIndex("Username")
                                .IsUnique();

                            b1.ToTable("Users");

                            b1.HasOne("RabblyApi.Users.Models.User", "User")
                                .WithOne("Profile")
                                .HasForeignKey("RabblyApi.Profiles.Models.Profile", "Id")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
