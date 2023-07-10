using System;
using System.Collections.Generic;
using Interview.Models;
using Microsoft.EntityFrameworkCore;

namespace Interview.Data;

public partial class TaskManagerContext : DbContext
{
    public TaskManagerContext()
    {
    }

    public TaskManagerContext(DbContextOptions<TaskManagerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Server=rezayari.ir;Database=TaskManager;User Id=InterviewAccess;Password=InterviewAccess@InterviewAccess;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Persian_100_CI_AS_KS_WS_SC_UTF8");

        modelBuilder.Entity<Person>(entity =>
        {
            entity.ToTable("Person", "Base");

            entity.Property(e => e.Email)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.InsDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.NationalCode)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role", "Base");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Caption)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.Description).HasMaxLength(1024);
            entity.Property(e => e.InsDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User", "Base");

            entity.Property(e => e.InsDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Password)
                .HasMaxLength(1024)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(1024)
                .IsUnicode(false);

            entity.HasOne(d => d.Person).WithMany(p => p.Users)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Person");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
