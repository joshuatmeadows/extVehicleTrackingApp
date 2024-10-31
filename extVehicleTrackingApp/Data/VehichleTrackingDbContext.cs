using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace extVehicleTrackingApp.Data;

public partial class VehichleTrackingDbContext : DbContext
{
    public VehichleTrackingDbContext()
    {
    }

    public VehichleTrackingDbContext(DbContextOptions<VehichleTrackingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<ExtVehicle> ExtVehicles { get; set; }

    public virtual DbSet<ExtVehicleOrg> ExtVehicleOrgs { get; set; }

    public virtual DbSet<ExtVehicleOrgPermission> ExtVehicleOrgPermissions { get; set; }

    public virtual DbSet<ExtVehiclePermission> ExtVehiclePermissions { get; set; }

    public virtual DbSet<ExtVehicleTrip> ExtVehicleTrips { get; set; }

    public virtual DbSet<ExtVehicleTripInfo> ExtVehicleTripInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<ExtVehicle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ext_vehi__3213E83FE43B7274");

            entity.ToTable("ext_vehicle");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Filepath)
                .HasMaxLength(255)
                .HasColumnName("filepath");
            entity.Property(e => e.Inspection).HasColumnName("inspection");
            entity.Property(e => e.Model)
                .HasMaxLength(255)
                .HasColumnName("model");
            entity.Property(e => e.OrgId).HasColumnName("org_id");
            entity.Property(e => e.Plate)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("plate");
            entity.Property(e => e.Surplus).HasColumnName("surplus");
            entity.Property(e => e.Vin)
                .HasMaxLength(17)
                .IsUnicode(false)
                .HasColumnName("vin");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.Org).WithMany(p => p.ExtVehicles)
                .HasForeignKey(d => d.OrgId)
                .HasConstraintName("FK__ext_vehic__org_i__412EB0B6");
        });

        modelBuilder.Entity<ExtVehicleOrg>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ext_vehi__3213E83FA379C303");

            entity.ToTable("ext_vehicle_org");

            entity.HasIndex(e => e.OrgName, "UQ__ext_vehi__4AB6EBB4C7D17930").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.OrgName)
                .HasMaxLength(255)
                .HasColumnName("org_name");
        });

        modelBuilder.Entity<ExtVehicleOrgPermission>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ext_vehicle_org_permissions");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.OrgId).HasColumnName("org_id");
            entity.Property(e => e.PermLevel).HasColumnName("perm_level");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Org).WithMany()
                .HasForeignKey(d => d.OrgId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ext_vehic__org_i__4316F928");
        });

        modelBuilder.Entity<ExtVehiclePermission>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ext_vehicle_permissions");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.PermLevel).HasColumnName("perm_level");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");

            entity.HasOne(d => d.Vehicle).WithMany()
                .HasForeignKey(d => d.VehicleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ext_vehic__vehic__4222D4EF");
        });

        modelBuilder.Entity<ExtVehicleTrip>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ext_vehi__3213E83FAF72B497");

            entity.ToTable("ext_vehicle_trip");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdditionalTravelers)
                .HasMaxLength(255)
                .HasColumnName("additional_travelers");
            entity.Property(e => e.Department)
                .HasMaxLength(255)
                .HasColumnName("department");
            entity.Property(e => e.FundingSource)
                .HasMaxLength(255)
                .HasColumnName("funding_source");
            entity.Property(e => e.TravelReason)
                .HasMaxLength(255)
                .HasColumnName("travel_reason");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");

            entity.HasOne(d => d.Vehicle).WithMany(p => p.ExtVehicleTrips)
                .HasForeignKey(d => d.VehicleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ext_vehic__vehic__440B1D61");
        });

        modelBuilder.Entity<ExtVehicleTripInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ext_vehi__3213E83F5FA81A08");

            entity.ToTable("ext_vehicle_trip_info");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Filepath)
                .HasMaxLength(255)
                .HasColumnName("filepath");
            entity.Property(e => e.FuelGallons)
                .HasColumnType("decimal(6, 3)")
                .HasColumnName("fuel_gallons");
            entity.Property(e => e.FuelTotalCost)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("fuel_total_cost");
            entity.Property(e => e.Mileage).HasColumnName("mileage");
            entity.Property(e => e.TripId).HasColumnName("trip_id");
            entity.Property(e => e.Ts)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ts");
            entity.Property(e => e.Type).HasColumnName("type");

            entity.HasOne(d => d.Trip).WithMany(p => p.ExtVehicleTripInfos)
                .HasForeignKey(d => d.TripId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ext_vehic__trip___44FF419A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
