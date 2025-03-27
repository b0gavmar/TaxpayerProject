using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TaxpayerProject.Models;

public partial class TaxpayerContext : DbContext
{
    public TaxpayerContext()
    {
    }

    public TaxpayerContext(DbContextOptions<TaxpayerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Taxpayer> Taxpayers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=taxpayer.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Taxpayer>(entity =>
        {
            entity
                //.HasNoKey()
                .ToTable("taxpayer");

            entity.Property(e => e.Amount)
                .HasColumnType("INT")
                .HasColumnName("amount");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Name).HasColumnName("name");

            entity.HasKey(e => e.Email);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
