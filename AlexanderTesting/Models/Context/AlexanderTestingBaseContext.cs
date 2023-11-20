using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AlexanderTesting.Models.Context;

public partial class AlexanderTestingBaseContext : DbContext
{
    public AlexanderTestingBaseContext()
    {
    }

    public AlexanderTestingBaseContext(DbContextOptions<AlexanderTestingBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Policy> Policies { get; set; }

    public virtual DbSet<PolycyType> PolycyTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Gender>(entity =>
        {
            entity.ToTable("Gender");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.ToTable("Person");

            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Firstname).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);

            entity.HasOne(d => d.GenderNavigation).WithMany(p => p.People)
                .HasForeignKey(d => d.Gender)
                .HasConstraintName("FK_Person_Gender");
        });

        modelBuilder.Entity<Policy>(entity =>
        {
            entity.ToTable("Policy");

            entity.Property(e => e.Enp)
                .HasMaxLength(50)
                .HasColumnName("ENP");
            entity.Property(e => e.Number).HasMaxLength(50);
            entity.Property(e => e.Serial).HasMaxLength(50);

            entity.HasOne(d => d.Person).WithOne(p => p.Policy);

            entity.HasOne(d => d.TypeNavigation).WithMany(p => p.Policies)
                .HasForeignKey(d => d.Type)
                .HasConstraintName("FK_Policy_PolycyTypes");
        });

        modelBuilder.Entity<PolycyType>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
