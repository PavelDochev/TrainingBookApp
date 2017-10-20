using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MySql.Data.MySqlClient;

namespace TrainingBookApp.Models
{
    public partial class TrainingBookAppContext : DbContext
    {
        public virtual DbSet<GroupМember> GroupMember { get; set; }
        public virtual DbSet<SportТype> SportType { get; set; }
        public virtual DbSet<Training> Training { get; set; }
        public virtual DbSet<TrainingLikes> TrainingLikes { get; set; }
        public virtual DbSet<TrainingType> TrainingType { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserGroup> UserGroup { get; set; }

        public TrainingBookAppContext(DbContextOptions<TrainingBookAppContext> options)
            : base(options)
        { }
        //public string ConnectionString { get; set; }
        //public TrainingBookAppContext(string connString)
        //{
        //    this.ConnectionString = connString;
        //}
        //private MySqlConnection GetConnection()
        //{
        //    return new MySqlConnection(ConnectionString);
        //}
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    {
        //        if (!optionsBuilder.IsConfigured)
        //        {
        //        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //        //                optionsBuilder.UseMySql("server=localhost;port=3306;user=pdochev;password=P@rola111;database=trainingbookapp");
        //        }
        //    }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupМember>(entity =>
            {
                entity.ToTable("groupmember");

                entity.HasIndex(e => e.UserGroupId)
                    .HasName("fk_GroupMember_UserGroup1_idx");

                entity.HasIndex(e => e.UserId)
                    .HasName("fk_GroupMember_user1_idx");

                entity.Property(e => e.GroupMemberId)
                    .HasColumnName("GroupMemberID")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.UserGroupId)
                    .HasColumnName("UserGroupID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.UserGroup)
                    .WithMany(p => p.GroupMember)
                    .HasForeignKey(d => d.UserGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserGroupID_fk");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.GroupMember)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserID_fk2");
            });

            modelBuilder.Entity<SportТype>(entity =>
            {
                entity.ToTable("sporttype");

                entity.Property(e => e.SportTypeId)
                    .HasColumnName("SportTypeID")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Training>(entity =>
            {
                entity.ToTable("training");

                entity.HasIndex(e => e.SportTypeId)
                    .HasName("SportTypeID");

                entity.HasIndex(e => e.TrainingTypeId)
                    .HasName("TrainingTypeID");

                entity.HasIndex(e => e.UserId)
                    .HasName("UserID");

                entity.Property(e => e.TrainingId)
                    .HasColumnName("TrainingID")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(45);

                entity.Property(e => e.Distance).HasColumnType("decimal(10,0)");

                entity.Property(e => e.MapPath).HasMaxLength(45);

                entity.Property(e => e.Public).HasColumnType("tinyint(4)");

                entity.Property(e => e.SportTypeId)
                    .HasColumnName("SportTypeID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Title).HasMaxLength(45);

                entity.Property(e => e.TrainingTypeId)
                    .HasColumnName("TrainingTypeID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.SportType)
                    .WithMany(p => p.Training)
                    .HasForeignKey(d => d.SportTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SportTypeID");

                entity.HasOne(d => d.TrainingType)
                    .WithMany(p => p.Training)
                    .HasForeignKey(d => d.TrainingTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TrainingTypeID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Training)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserID");
            });

            modelBuilder.Entity<TrainingLikes>(entity =>
            {
                entity.ToTable("traininglikes");

                entity.HasIndex(e => e.TrainingId)
                    .HasName("TrainingID");

                entity.HasIndex(e => e.UserId)
                    .HasName("UserID");

                entity.Property(e => e.TrainingLikesId)
                    .HasColumnName("TrainingLikesID")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Action).HasColumnType("bit(1)");

                entity.Property(e => e.TrainingId)
                    .HasColumnName("TrainingID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Training)
                    .WithMany(p => p.TrainingLikes)
                    .HasForeignKey(d => d.TrainingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TrainingID_fk");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TrainingLikes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserID_fk");
            });

            modelBuilder.Entity<TrainingType>(entity =>
            {
                entity.ToTable("trainingtype");

                entity.HasIndex(e => e.TrainingTypeId)
                    .HasName("TrainingTypeID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.TrainingTypeId)
                    .HasColumnName("TrainingTypeID")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.SportTypeId)
                    .HasName("SportTypeID_fk");

                entity.HasIndex(e => e.UserId)
                    .HasName("UserID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClubName).HasMaxLength(45);

                entity.Property(e => e.Description).HasMaxLength(45);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.PicturePath).HasMaxLength(45);

                entity.Property(e => e.SportTypeId)
                    .HasColumnName("SportTypeID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.SportType)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.SportTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SportTypeID_fk");
            });

            modelBuilder.Entity<UserGroup>(entity =>
            {
                entity.ToTable("usergroup");

                entity.HasIndex(e => e.UserId)
                    .HasName("fk_UserGroup_user1_idx");

                entity.Property(e => e.UserGroupId)
                    .HasColumnName("UserGroupID")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Usergroup)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserID_fk1");
            });
        }
    }
}
