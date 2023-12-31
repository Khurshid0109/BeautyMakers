﻿using BeautyMakers.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BeautyMakers.Data.Data;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>()
           .HasOne(a => a.Customer)
           .WithMany(u => u.Appointments)
           .HasForeignKey(a => a.CustomerId)
           .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.BeautyProfessional)
            .WithMany(bp => bp.Appointments)
            .HasForeignKey(a => a.BeautyProfessionalId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<AppointmentResult>()
           .HasOne(ar => ar.Appointment)
           .WithOne(a => a.AppointmentService)
           .HasForeignKey<AppointmentResult>(ar => ar.AppointmentId)
           .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<BeautyProfessionalUser>()
            .HasKey(bpu => new { bpu.BeautyProfessionalId, bpu.UserId });

        modelBuilder.Entity<BeautyProfessionalUser>()
            .HasOne(bpu => bpu.BeautyProfessional)
            .WithMany(bp => bp.BeautyProfessionalUsers)
            .HasForeignKey(bpu => bpu.BeautyProfessionalId);

        modelBuilder.Entity<BeautyProfessionalUser>()
            .HasOne(bpu => bpu.User)
            .WithMany(u => u.BeautyProfessionalUsers)
            .HasForeignKey(bpu => bpu.UserId);

        modelBuilder.Entity<PastWork>()
          .HasOne(pw => pw.BeautyProfessional)
          .WithMany(bp => bp.PastWorks)
          .HasForeignKey(pw => pw.BeautyProfessionalId);


    }

    public DbSet<User> Users { get; set; }
    public DbSet<Salon> Salons { get; set; }
    public DbSet<PastWork> PastWorks { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<BeautyProfessional> BeautyProfessionals { get; set; }
    public DbSet<AppointmentResult> AppointmentServices { get; set; }
    public DbSet<BeautyProfessionalUser> beautyProfessionalUsers { get; set; }

}
