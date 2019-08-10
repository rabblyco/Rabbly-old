using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RabblyApi.Data.Utils;
using System;
using RabblyApi.Users.Models;
using RabblyApi.Profiles.Models;
using RabblyApi.Groups.Models;
using RabblyApi.Debates.Models;
using RabblyApi.Comments.Models;
using RabblyApi.Ranks.Models;
using RabblyApi.Permissions.Models;
using RabblyApi.Polls.Models;
using RabblyApi.ScoreCards.Models;
using Microsoft.AspNetCore.Hosting;

namespace RabblyApi.Data
{
    public class DatabaseContext : DbContext
    {
        private readonly IConfiguration _config;
        // private readonly IHostingEnvironment _env;

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DatabaseContext(DbContextOptions<DatabaseContext> options, IConfiguration config) : base(options)
        {
            _config = config;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<Debate> Debates { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<ScoreCard> ScoreCards { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Users
            builder.Entity<User>().HasKey(u => u.Id);
            builder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            builder.Entity<User>().HasOne(u => u.Rank);
            builder.Entity<User>().OwnsOne(u => u.Profile);
            builder.Entity<User>().HasOne(u => u.Group);
            builder.Entity<User>().Property(u => u.CreatedAt).ValueGeneratedOnAdd().HasColumnType("timestamp with time zone").HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Entity<User>().Property(u => u.UpdatedAt).ValueGeneratedOnAddOrUpdate().HasColumnType("timestamp with time zone").HasDefaultValueSql("CURRENT_TIMESTAMP");

            // Profile
            builder.Entity<Profile>().HasIndex(p => p.Username).IsUnique();
            builder.Entity<Profile>().Property(p => p.Country).HasConversion(c => c.ToString(), c => (Countries)Enum.Parse(typeof(Countries), c)).HasDefaultValue(Countries.None);
            builder.Entity<Profile>().Property(p => p.State).HasConversion(s => s.ToString(), s => (States)Enum.Parse(typeof(States), s)).HasDefaultValue(States.None);
            builder.Entity<Profile>().Property(p => p.Gender).HasConversion(g => g.ToString(), g => (Gender)Enum.Parse(typeof(Gender), g)).HasDefaultValue(Gender.Secret);
            builder.Entity<Profile>().Property(p => p.CreatedAt).ValueGeneratedOnAdd().HasColumnType("timestamp with time zone").HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Entity<Profile>().Property(p => p.UpdatedAt).ValueGeneratedOnAddOrUpdate().HasColumnType("timestamp with time zone").HasDefaultValueSql("CURRENT_TIMESTAMP");
            
            // Group
            builder.Entity<Group>().HasKey(g => g.Id);
            builder.Entity<Group>().HasMany(g => g.Users);
            builder.Entity<Group>().HasMany(g => g.Ranks);
            builder.Entity<Group>().HasOne(g => g.Owner);
            builder.Entity<Group>().HasIndex(g => g.Name).IsUnique();
            builder.Entity<Group>().Property(g => g.CreatedAt).ValueGeneratedOnAdd().HasColumnType("timestamp with time zone").HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Entity<Group>().Property(g => g.UpdatedAt).ValueGeneratedOnAddOrUpdate().HasColumnType("timestamp with time zone").HasDefaultValueSql("CURRENT_TIMESTAMP");

            // Ranks
            builder.Entity<Rank>().HasKey(r => r.Id);
            builder.Entity<Rank>().HasOne(r => r.Group);
            builder.Entity<Rank>().OwnsOne(r => r.Permissions);
            builder.Entity<Rank>().HasMany(r => r.Users);
            builder.Entity<Rank>().Property(r => r.CreatedAt).ValueGeneratedOnAdd().HasColumnType("timestamp with time zone").HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Entity<Rank>().Property(r => r.UpdatedAt).ValueGeneratedOnAddOrUpdate().HasColumnType("timestamp with time zone").HasDefaultValueSql("CURRENT_TIMESTAMP");

            // Comments
            builder.Entity<Comment>().HasKey(c => c.Id);
            builder.Entity<Comment>().HasOne<Debate>().WithMany(d => d.Comments).HasForeignKey(c => c.DebateId);
            builder.Entity<Comment>().HasMany(c => c.ScoreCard);
            builder.Entity<Comment>().HasMany(c => c.Children);
            builder.Entity<Comment>().HasOne(c => c.Parent);
            builder.Entity<Comment>().HasOne(c => c.CreatedBy);
            builder.Entity<Comment>().Property(c => c.CreatedAt).ValueGeneratedOnAdd().HasColumnType("timestamp with time zone").HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Entity<Comment>().Property(c => c.UpdatedAt).ValueGeneratedOnAddOrUpdate().HasColumnType("timestamp with time zone").HasDefaultValueSql("CURRENT_TIMESTAMP");

            // Debates
            builder.Entity<Debate>().HasKey(d => d.Id);
            builder.Entity<Debate>().HasMany(d => d.ScoreCards);
            builder.Entity<Debate>().HasMany(d => d.Comments);
            builder.Entity<Debate>().Property(d => d.CreatedAt).ValueGeneratedOnAdd().HasColumnType("timestamp with time zone").HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Entity<Debate>().Property(d => d.UpdatedAt).ValueGeneratedOnAddOrUpdate().HasColumnType("timestamp with time zone").HasDefaultValueSql("CURRENT_TIMESTAMP");

            // Polls
            builder.Entity<Poll>().HasKey(p => p.Id);
            builder.Entity<Poll>().HasOne(p => p.CreatedBy);
            builder.Entity<Poll>().HasMany(p => p.ScoreCard);
            builder.Entity<Poll>().Property(p => p.CreatedAt).ValueGeneratedOnAdd().HasColumnType("timestamp with time zone").HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Entity<Poll>().Property(p => p.UpdatedAt).ValueGeneratedOnAddOrUpdate().HasColumnType("timestamp with time zone").HasDefaultValueSql("CURRENT_TIMESTAMP");

            // Permissions
            builder.Entity<Permission>().HasKey(p => p.Id);
            builder.Entity<Permission>().Property(p => p.CanAddMember).HasDefaultValue(false);
            builder.Entity<Permission>().Property(p => p.CanAddRank).HasDefaultValue(false);
            builder.Entity<Permission>().Property(p => p.CanCreateDiscussion).HasDefaultValue(false);
            builder.Entity<Permission>().Property(p => p.CanEditGroup).HasDefaultValue(false);
            builder.Entity<Permission>().Property(p => p.CanCreateRole).HasDefaultValue(false);
            builder.Entity<Permission>().Property(p => p.CanEditMemberRank).HasDefaultValue(false);
            builder.Entity<Permission>().Property(p => p.CanEditRankPermissions).HasDefaultValue(false);
            builder.Entity<Permission>().Property(p => p.CanParticipateInGroupDiscussion).HasDefaultValue(false);
            builder.Entity<Permission>().Property(p => p.CanRemoveMember).HasDefaultValue(false);
            builder.Entity<Permission>().Property(p => p.CanRemoveRank).HasDefaultValue(false);
            builder.Entity<Permission>().Property(p => p.CanRepresentGroup).HasDefaultValue(false);
            builder.Entity<Permission>().Property(p => p.CreatedAt).ValueGeneratedOnAdd().HasColumnType("timestamp with time zone").HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Entity<Permission>().Property(p => p.UpdatedAt).ValueGeneratedOnAddOrUpdate().HasColumnType("timestamp with time zone").HasDefaultValueSql("CURRENT_TIMESTAMP");
        
            builder.Entity<ScoreCard>().HasKey(sc => sc.Id);
            builder.Entity<ScoreCard>().Property(sc => sc.CreatedAt).ValueGeneratedOnAdd().HasColumnType("timestamp with time zone").HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Entity<ScoreCard>().Property(sc => sc.UpdatedAt).ValueGeneratedOnAddOrUpdate().HasColumnType("timestamp with time zone").HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}