using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CRM.Models;

public partial class CrmContext : DbContext
{
    public CrmContext()
    {
    }

    public CrmContext(DbContextOptions<CrmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BackgroundInformation> BackgroundInformations { get; set; }

    public virtual DbSet<BusinessExecutionStatu> BusinessExecutionStatus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BackgroundInformation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__backgrou__3213E83F788AAEDD");

            entity.ToTable("background_information");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AreaAddress)
                .HasMaxLength(200)
                .HasColumnName("area_address");
            entity.Property(e => e.CellPhone).HasColumnName("cell_phone");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .HasColumnName("city");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(100)
                .HasColumnName("company_name");
            entity.Property(e => e.CompanyUrl)
                .HasMaxLength(200)
                .HasColumnName("company_url");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .HasColumnName("country");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .HasColumnName("email");
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(100)
                .HasColumnName("employee_name");
            entity.Property(e => e.CompantPhone)
               .HasColumnName("compant_phone");
            entity.Property(e => e.Area)
                .HasMaxLength(100)
                .HasColumnName("area");
            entity.Property(e => e.Position)
              .HasMaxLength(100)
              .HasColumnName("position");
            entity.Property(e => e.Fax).HasColumnName("fax");
            entity.Property(e => e.IndustryType)
                .HasMaxLength(200)
                .HasColumnName("industry_type");
            entity.Property(e => e.NegotiateYear)
                .HasMaxLength(100)
                .HasColumnName("negotiate_year");
            entity.Property(e => e.Remark).HasColumnName("remark");
        });

        modelBuilder.Entity<BusinessExecutionStatu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__business__3213E83FC52AAF99");

            entity.ToTable("business_execution_statu");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(100)
                .HasColumnName("company_name");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.State).HasColumnName("state");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
