using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace demo3.Models;

public partial class QLSinhVienContext : DbContext
{
    public QLSinhVienContext()
    {
    }

    public QLSinhVienContext(DbContextOptions<QLSinhVienContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Khoa> Khoas { get; set; }

    public virtual DbSet<SinhVien> SinhViens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-BHA07K98;Database=QL_SinhVien;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Khoa>(entity =>
        {
            entity.HasKey(e => e.MaKhoa).HasName("PK__Khoa__6539040565DD5D6A");

            entity.ToTable("Khoa");

            entity.Property(e => e.MaKhoa)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TenKhoa).HasMaxLength(100);
        });

        modelBuilder.Entity<SinhVien>(entity =>
        {
            entity.HasKey(e => e.MaSv).HasName("PK__SinhVien__2725081A0D289075");

            entity.ToTable("SinhVien");

            entity.Property(e => e.MaSv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaSV");
            entity.Property(e => e.DiaChi).HasMaxLength(200);
            entity.Property(e => e.GioiTinh).HasMaxLength(10);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.MaKhoa)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.MaKhoaNavigation).WithMany(p => p.SinhViens)
                .HasForeignKey(d => d.MaKhoa)
                .HasConstraintName("FK_SinhVien_Khoa");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
