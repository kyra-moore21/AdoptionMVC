using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AdoptionMVC.Models;

public partial class AdoptiondbContext : DbContext
{
    public AdoptiondbContext()
    {
    }

    public AdoptiondbContext(DbContextOptions<AdoptiondbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Animal> Animals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=ADOPTIONDB; Integrated Security=SSPI;Encrypt=false;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Animal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Animals__3214EC07D221C38F");

            entity.Property(e => e.Breed).HasMaxLength(255);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Img).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
