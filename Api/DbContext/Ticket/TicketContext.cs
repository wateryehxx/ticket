using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DbContext.Ticket.Tables;

namespace DbContext.Ticket
{
    public partial class TicketContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public TicketContext(DbContextOptions<TicketContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Issue> Issues { get; set; } = null!;
        public virtual DbSet<IssueHistory> IssueHistories { get; set; } = null!;
        public virtual DbSet<IssueStatus> IssueStatuses { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Issue>(entity =>
            {
                entity.ToTable("Issue");

                entity.Property(e => e.IssueId).ValueGeneratedNever();

                entity.Property(e => e.Severity).HasMaxLength(10);

                entity.Property(e => e.Summary).HasMaxLength(4000);

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.IssueStatus)
                    .WithMany(p => p.Issues)
                    .HasForeignKey(d => d.IssueStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Issue_IssueStatus");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Issues)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Issue_User");
            });

            modelBuilder.Entity<IssueHistory>(entity =>
            {
                entity.ToTable("IssueHistory");

                entity.Property(e => e.IssueHistoryId).ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Issue)
                    .WithMany(p => p.IssueHistories)
                    .HasForeignKey(d => d.IssueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IssueHistory_Issue");

                entity.HasOne(d => d.IssueStatus)
                    .WithMany(p => p.IssueHistories)
                    .HasForeignKey(d => d.IssueStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IssueHistory_IssueStatus");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.IssueHistories)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IssueHistory_User");
            });

            modelBuilder.Entity<IssueStatus>(entity =>
            {
                entity.ToTable("IssueStatus");

                entity.Property(e => e.IssueStatusId).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(10);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(10);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
