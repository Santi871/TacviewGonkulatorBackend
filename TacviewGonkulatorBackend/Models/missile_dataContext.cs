using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TacviewGonkulatorBackend
{
    public partial class missile_dataContext : DbContext
    {
        public missile_dataContext(DbContextOptions<missile_dataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aircraftmodel> Aircraftmodels { get; set; }
        public virtual DbSet<Altitudemodel> Altitudemodels { get; set; }
        public virtual DbSet<Aspectmodel> Aspectmodels { get; set; }
        public virtual DbSet<Blacklistedmissilemodel> Blacklistedmissilemodels { get; set; }
        public virtual DbSet<Closureratemodel> Closureratemodels { get; set; }
        public virtual DbSet<Defeattypemodel> Defeattypemodels { get; set; }
        public virtual DbSet<Defensivemaneuvermodel> Defensivemaneuvermodels { get; set; }
        public virtual DbSet<Hitmodel> Hitmodels { get; set; }
        public virtual DbSet<Machmodel> Machmodels { get; set; }
        public virtual DbSet<Missilemodel> Missilemodels { get; set; }
        public virtual DbSet<Missileshotmodel> Missileshotmodels { get; set; }
        public virtual DbSet<Playermodel> Playermodels { get; set; }
        public virtual DbSet<Processedtacviewmodel> Processedtacviewmodels { get; set; }
        public virtual DbSet<Rangemodel> Rangemodels { get; set; }
        public virtual DbSet<Relativetimemodel> Relativetimemodels { get; set; }
        public virtual DbSet<Tacviewmodel> Tacviewmodels { get; set; }
        public virtual DbSet<Timeofflightmodel> Timeofflightmodels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.UTF-8");

            modelBuilder.Entity<Aircraftmodel>(entity =>
            {
                entity.ToTable("aircraftmodel");

                entity.HasIndex(e => e.AircraftType, "aircraftmodel_aircraft_type")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AircraftType)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("aircraft_type");
            });

            modelBuilder.Entity<Altitudemodel>(entity =>
            {
                entity.ToTable("altitudemodel");

                entity.HasIndex(e => e.Altitude, "altitudemodel_altitude")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Altitude).HasColumnName("altitude");
            });

            modelBuilder.Entity<Aspectmodel>(entity =>
            {
                entity.ToTable("aspectmodel");

                entity.HasIndex(e => e.Aspect, "aspectmodel_aspect")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Aspect)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("aspect");
            });

            modelBuilder.Entity<Blacklistedmissilemodel>(entity =>
            {
                entity.ToTable("blacklistedmissilemodel");

                entity.HasIndex(e => e.MissileName, "blacklistedmissilemodel_missile_name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MissileName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("missile_name");
            });

            modelBuilder.Entity<Closureratemodel>(entity =>
            {
                entity.ToTable("closureratemodel");

                entity.HasIndex(e => e.ClosureRate, "closureratemodel_closure_rate")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClosureRate).HasColumnName("closure_rate");
            });

            modelBuilder.Entity<Defeattypemodel>(entity =>
            {
                entity.ToTable("defeattypemodel");

                entity.HasIndex(e => e.DefeatType, "defeattypemodel_defeat_type")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DefeatType)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("defeat_type");
            });

            modelBuilder.Entity<Defensivemaneuvermodel>(entity =>
            {
                entity.ToTable("defensivemaneuvermodel");

                entity.HasIndex(e => e.DefensiveManeuver, "defensivemaneuvermodel_defensive_maneuver")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DefensiveManeuver)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("defensive_maneuver");
            });

            modelBuilder.Entity<Hitmodel>(entity =>
            {
                entity.ToTable("hitmodel");

                entity.HasIndex(e => e.Hit, "hitmodel_hit")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Hit).HasColumnName("hit");
            });

            modelBuilder.Entity<Machmodel>(entity =>
            {
                entity.ToTable("machmodel");

                entity.HasIndex(e => e.Mach, "machmodel_mach")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Mach).HasColumnName("mach");
            });

            modelBuilder.Entity<Missilemodel>(entity =>
            {
                entity.ToTable("missilemodel");

                entity.HasIndex(e => e.MissileName, "missilemodel_missile_name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MissileAliases)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("missile_aliases");

                entity.Property(e => e.MissileName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("missile_name");
            });

            modelBuilder.Entity<Missileshotmodel>(entity =>
            {
                entity.ToTable("missileshotmodel");

                entity.HasIndex(e => e.AspectId, "missileshotmodel_aspect_id");

                entity.HasIndex(e => e.ClosureId, "missileshotmodel_closure_id");

                entity.HasIndex(e => e.DefeatTypeId, "missileshotmodel_defeat_type_id");

                entity.HasIndex(e => e.DefensiveManeuverId, "missileshotmodel_defensive_maneuver_id");

                entity.HasIndex(e => e.HitId, "missileshotmodel_hit_id");

                entity.HasIndex(e => e.MissileId, "missileshotmodel_missile_id");

                entity.HasIndex(e => e.RangeId, "missileshotmodel_range_id");

                entity.HasIndex(e => e.ShooterAltitudeId, "missileshotmodel_shooter_altitude_id");

                entity.HasIndex(e => e.ShooterMachId, "missileshotmodel_shooter_mach_id");

                entity.HasIndex(e => e.ShooterPlayerId, "missileshotmodel_shooter_player_id");

                entity.HasIndex(e => e.ShooterTypeId, "missileshotmodel_shooter_type_id");

                entity.HasIndex(e => e.TacviewId, "missileshotmodel_tacview_id");

                entity.HasIndex(e => e.TimeId, "missileshotmodel_time_id");

                entity.HasIndex(e => e.TofId, "missileshotmodel_tof_id");

                entity.HasIndex(e => e.VictimAltitudeId, "missileshotmodel_victim_altitude_id");

                entity.HasIndex(e => e.VictimPlayerId, "missileshotmodel_victim_player_id");

                entity.HasIndex(e => e.VictimTypeId, "missileshotmodel_victim_type_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AspectId).HasColumnName("aspect_id");

                entity.Property(e => e.ClosureId).HasColumnName("closure_id");

                entity.Property(e => e.DefeatTypeId).HasColumnName("defeat_type_id");

                entity.Property(e => e.DefensiveManeuverId).HasColumnName("defensive_maneuver_id");

                entity.Property(e => e.HitId).HasColumnName("hit_id");

                entity.Property(e => e.MissileId).HasColumnName("missile_id");

                entity.Property(e => e.RangeId).HasColumnName("range_id");

                entity.Property(e => e.ShooterAltitudeId).HasColumnName("shooter_altitude_id");

                entity.Property(e => e.ShooterMachId).HasColumnName("shooter_mach_id");

                entity.Property(e => e.ShooterPlayerId).HasColumnName("shooter_player_id");

                entity.Property(e => e.ShooterTypeId).HasColumnName("shooter_type_id");

                entity.Property(e => e.TacviewId).HasColumnName("tacview_id");

                entity.Property(e => e.TimeId).HasColumnName("time_id");

                entity.Property(e => e.TofId).HasColumnName("tof_id");

                entity.Property(e => e.VictimAltitudeId).HasColumnName("victim_altitude_id");

                entity.Property(e => e.VictimPlayerId).HasColumnName("victim_player_id");

                entity.Property(e => e.VictimTypeId).HasColumnName("victim_type_id");

                entity.HasOne(d => d.Aspect)
                    .WithMany(p => p.Missileshotmodels)
                    .HasForeignKey(d => d.AspectId)
                    .HasConstraintName("missileshotmodel_aspect_id_fkey");

                entity.HasOne(d => d.Closure)
                    .WithMany(p => p.Missileshotmodels)
                    .HasForeignKey(d => d.ClosureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("missileshotmodel_closure_id_fkey");

                entity.HasOne(d => d.DefeatType)
                    .WithMany(p => p.Missileshotmodels)
                    .HasForeignKey(d => d.DefeatTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("missileshotmodel_defeat_type_id_fkey");

                entity.HasOne(d => d.DefensiveManeuver)
                    .WithMany(p => p.Missileshotmodels)
                    .HasForeignKey(d => d.DefensiveManeuverId)
                    .HasConstraintName("missileshotmodel_defensive_maneuver_id_fkey");

                entity.HasOne(d => d.Hit)
                    .WithMany(p => p.Missileshotmodels)
                    .HasForeignKey(d => d.HitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("missileshotmodel_hit_id_fkey");

                entity.HasOne(d => d.Missile)
                    .WithMany(p => p.Missileshotmodels)
                    .HasForeignKey(d => d.MissileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("missileshotmodel_missile_id_fkey");

                entity.HasOne(d => d.Range)
                    .WithMany(p => p.Missileshotmodels)
                    .HasForeignKey(d => d.RangeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("missileshotmodel_range_id_fkey");

                entity.HasOne(d => d.ShooterAltitude)
                    .WithMany(p => p.MissileshotmodelShooterAltitudes)
                    .HasForeignKey(d => d.ShooterAltitudeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("missileshotmodel_shooter_altitude_id_fkey");

                entity.HasOne(d => d.ShooterMach)
                    .WithMany(p => p.Missileshotmodels)
                    .HasForeignKey(d => d.ShooterMachId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("missileshotmodel_shooter_mach_id_fkey");

                entity.HasOne(d => d.ShooterPlayer)
                    .WithMany(p => p.MissileshotmodelShooterPlayers)
                    .HasForeignKey(d => d.ShooterPlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("missileshotmodel_shooter_player_id_fkey");

                entity.HasOne(d => d.ShooterType)
                    .WithMany(p => p.MissileshotmodelShooterTypes)
                    .HasForeignKey(d => d.ShooterTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("missileshotmodel_shooter_type_id_fkey");

                entity.HasOne(d => d.Tacview)
                    .WithMany(p => p.Missileshotmodels)
                    .HasForeignKey(d => d.TacviewId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("missileshotmodel_tacview_id_fkey");

                entity.HasOne(d => d.Time)
                    .WithMany(p => p.Missileshotmodels)
                    .HasForeignKey(d => d.TimeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("missileshotmodel_time_id_fkey");

                entity.HasOne(d => d.Tof)
                    .WithMany(p => p.Missileshotmodels)
                    .HasForeignKey(d => d.TofId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("missileshotmodel_tof_id_fkey");

                entity.HasOne(d => d.VictimAltitude)
                    .WithMany(p => p.MissileshotmodelVictimAltitudes)
                    .HasForeignKey(d => d.VictimAltitudeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("missileshotmodel_victim_altitude_id_fkey");

                entity.HasOne(d => d.VictimPlayer)
                    .WithMany(p => p.MissileshotmodelVictimPlayers)
                    .HasForeignKey(d => d.VictimPlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("missileshotmodel_victim_player_id_fkey");

                entity.HasOne(d => d.VictimType)
                    .WithMany(p => p.MissileshotmodelVictimTypes)
                    .HasForeignKey(d => d.VictimTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("missileshotmodel_victim_type_id_fkey");
            });

            modelBuilder.Entity<Playermodel>(entity =>
            {
                entity.ToTable("playermodel");

                entity.HasIndex(e => e.Username, "playermodel_username")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Processedtacviewmodel>(entity =>
            {
                entity.ToTable("processedtacviewmodel");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AnalyzedDate).HasColumnName("analyzed_date");
                
                entity.Property(e => e.UploadedDate).HasColumnName("uploaded_date");

                entity.Property(e => e.Completed).HasColumnName("completed");
                
                entity.Property(e => e.TacviewGuid).HasColumnName("tacviewguid");
                
                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Exception)
                    .HasMaxLength(255)
                    .HasColumnName("exception");

                entity.Property(e => e.Filehash)
                    .HasMaxLength(255)
                    .HasColumnName("filehash");

                entity.Property(e => e.Filename)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("filename");
            });

            modelBuilder.Entity<Rangemodel>(entity =>
            {
                entity.ToTable("rangemodel");

                entity.HasIndex(e => e.Range, "rangemodel_range")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Range).HasColumnName("range");
            });

            modelBuilder.Entity<Relativetimemodel>(entity =>
            {
                entity.ToTable("relativetimemodel");

                entity.HasIndex(e => e.RelativeTime, "relativetimemodel_relative_time")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.RelativeTime).HasColumnName("relative_time");
            });

            modelBuilder.Entity<Tacviewmodel>(entity =>
            {
                entity.ToTable("tacviewmodel");

                entity.HasIndex(e => e.Filename, "tacviewmodel_filename")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Filename)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("filename");
            });

            modelBuilder.Entity<Timeofflightmodel>(entity =>
            {
                entity.ToTable("timeofflightmodel");

                entity.HasIndex(e => e.TimeOfFlight, "timeofflightmodel_time_of_flight")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TimeOfFlight).HasColumnName("time_of_flight");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
