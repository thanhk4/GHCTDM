using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GHCTDM.Models;

public partial class GhctdmSd18302Context : DbContext
{
    public GhctdmSd18302Context()
    {
    }

    public GhctdmSd18302Context(DbContextOptions<GhctdmSd18302Context> options)
        : base(options)
    {
    }
    public DbSet<GioHang> GioHangs { get; set; }
    public DbSet<GioHangCT> GioHangCts { get; set; }    
    public DbSet<User> users { get; set; }
    public DbSet<SanPham> SanPhams { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=THANHCONGTU\\SQLEXPRESS01;Database=GHCTDM_SD18302;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
