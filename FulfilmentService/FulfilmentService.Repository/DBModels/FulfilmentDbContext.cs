using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FulfilmentService.Repository.DBModels;

public partial class FulfilmentDbContext : DbContext
{
    public FulfilmentDbContext()
    {
    }

    public FulfilmentDbContext(DbContextOptions<FulfilmentDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Fulfillment> Fulfillments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\MSSQLSERVER01;Database=Fulfilment;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Fulfillment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Fulfillm__3214EC0793B01BCD");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TrackingNumber).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
