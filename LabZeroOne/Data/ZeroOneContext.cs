using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LabZeroOne.Data;

public partial class ZeroOneContext : DbContext
{
    public ZeroOneContext()
    {
    }

    public ZeroOneContext(DbContextOptions<ZeroOneContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Notion> Notions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Notion>(entity =>
        {
            entity.ToTable("Notion");

            entity.Property(e => e.Contents).HasMaxLength(500);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.DueDate).HasColumnType("datetime");
            entity.Property(e => e.IconTypeNote).HasMaxLength(50);
            entity.Property(e => e.MemberShip).HasMaxLength(200);
            entity.Property(e => e.Status).HasMaxLength(1);
            entity.Property(e => e.TimeDone).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(200);
            entity.Property(e => e.ZoneFinish).HasMaxLength(50);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.RoleName)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
