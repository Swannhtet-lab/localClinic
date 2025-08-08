using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using localClinic.Models;

namespace localClinic.Data;

public partial class PjContext : DbContext
{
    public PjContext()
    {
    }

    public PjContext(DbContextOptions<PjContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Receipt> Receipts { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Time> Times { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-7R5BI2H\\INSTANCE2022;Initial Catalog=pj;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.ToTable("Admin");

            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.ToTable("Booking");

            entity.Property(e => e.BookingDate).HasColumnType("datetime");
            entity.Property(e => e.BookingStatus).HasMaxLength(50);
            entity.Property(e => e.Remark).HasMaxLength(50);

            entity.HasOne(d => d.Doctor).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.DoctorId)
                .HasConstraintName("FK_Booking_Doctor");

            entity.HasOne(d => d.Patient).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_Booking_PatientInfo");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.ToTable("Doctor");

            entity.Property(e => e.DoctorAddress).HasMaxLength(50);
            entity.Property(e => e.DoctorDescription).HasMaxLength(50);
            entity.Property(e => e.DoctorGender).HasMaxLength(50);
            entity.Property(e => e.DoctorName).HasMaxLength(50);
            entity.Property(e => e.DoctorPhone).HasMaxLength(50);
            entity.Property(e => e.DoctorSpecialty).HasMaxLength(50);
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK_PatientInfo");

            entity.ToTable("Patient");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.PatientAddress).HasMaxLength(50);
            entity.Property(e => e.PatientGender).HasMaxLength(50);
            entity.Property(e => e.PatientName).HasMaxLength(50);
            entity.Property(e => e.PatientType).HasMaxLength(50);
        });

        modelBuilder.Entity<Receipt>(entity =>
        {
            entity.ToTable("Receipt");

            entity.Property(e => e.LastUpdated).HasColumnType("datetime");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Receipts)
                .HasForeignKey(d => d.DoctorId)
                .HasConstraintName("FK_Receipt_Doctor");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.ToTable("Schedule");

            entity.Property(e => e.DayOfWeek).HasMaxLength(50);

            entity.HasOne(d => d.Doctor).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.DoctorId)
                .HasConstraintName("FK_Schedule_Doctor");
        });

        modelBuilder.Entity<Time>(entity =>
        {
            entity.ToTable("Time");

            entity.Property(e => e.TimeType).HasColumnName("timeType");

            entity.HasOne(d => d.Schedule).WithMany(p => p.Times)
                .HasForeignKey(d => d.ScheduleId)
                .HasConstraintName("FK_Time_Schedule");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
