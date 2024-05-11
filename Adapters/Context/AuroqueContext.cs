using System;
using System.Collections.Generic;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Database.Context.Entities;

public partial class AuroqueContext : DbContext
{
    public AuroqueContext()
    {
    }

    public AuroqueContext(DbContextOptions<AuroqueContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AnimalChip> AnimalChips { get; set; }

    public virtual DbSet<Cattle> Cattles { get; set; }

    public virtual DbSet<CattleAnimalChip> CattleAnimalChips { get; set; }

    public virtual DbSet<CattleBreed> CattleBreeds { get; set; }

    public virtual DbSet<CattleDestination> CattleDestinations { get; set; }

    public virtual DbSet<CattleManagement> CattleManagements { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Farm> Farms { get; set; }

    public virtual DbSet<Person> Persons { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<WeighingHistory> WeighingHistories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=mysql.auroque.kinghost.net;database=auroque;user=auroque;password=Reproduction2024", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.6.16-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("latin1_swedish_ci")
            .HasCharSet("latin1");

        modelBuilder.Entity<AnimalChip>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.Code, "Code").IsUnique();

            entity.HasIndex(e => e.CreatedBy, "CreatedBy");

            entity.HasIndex(e => e.LastUpdatedBy, "LastUpdatedBy");

            entity.HasIndex(e => e.SerialNumber, "SerialNumber").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp");
            entity.Property(e => e.CreatedBy).HasColumnType("int(11)");
            entity.Property(e => e.IsActive).HasDefaultValueSql("'1'");
            entity.Property(e => e.LastUpdatedBy).HasColumnType("int(11)");
            entity.Property(e => e.Manufacturer).HasMaxLength(255);
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.AnimalChipCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("AnimalChips_ibfk_1");

            entity.HasOne(d => d.LastUpdatedByNavigation).WithMany(p => p.AnimalChipLastUpdatedByNavigations)
                .HasForeignKey(d => d.LastUpdatedBy)
                .HasConstraintName("AnimalChips_ibfk_2");
        });

        modelBuilder.Entity<Cattle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.BreedId, "BreedId");

            entity.HasIndex(e => e.DestinationId, "DestinationId");

            entity.HasIndex(e => e.FarmId, "FarmId");

            entity.HasIndex(e => e.FatherId, "FatherId");

            entity.HasIndex(e => e.LastUpdatedBy, "LastUpdatedBy");

            entity.HasIndex(e => e.MotherId, "MotherId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.BreedId).HasColumnType("int(11)");
            entity.Property(e => e.CoatColor).HasMaxLength(100);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp");
            entity.Property(e => e.DestinationId).HasColumnType("int(11)");
            entity.Property(e => e.FarmId).HasColumnType("int(11)");
            entity.Property(e => e.FatherId).HasColumnType("int(11)");
            entity.Property(e => e.Gender).HasColumnType("enum('Male','Female')");
            entity.Property(e => e.IsActive).HasDefaultValueSql("'1'");
            entity.Property(e => e.LastUpdatedBy).HasColumnType("int(11)");
            entity.Property(e => e.MotherId).HasColumnType("int(11)");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.PropertyId).HasMaxLength(50);
            entity.Property(e => e.SisbovId).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp");

            entity.HasOne(d => d.Breed).WithMany(p => p.Cattles)
                .HasForeignKey(d => d.BreedId)
                .HasConstraintName("Cattles_ibfk_2");

            entity.HasOne(d => d.Destination).WithMany(p => p.Cattles)
                .HasForeignKey(d => d.DestinationId)
                .HasConstraintName("Cattles_ibfk_5");

            entity.HasOne(d => d.Farm).WithMany(p => p.Cattles)
                .HasForeignKey(d => d.FarmId)
                .HasConstraintName("Cattles_ibfk_1");

            entity.HasOne(d => d.Father).WithMany(p => p.InverseFather)
                .HasForeignKey(d => d.FatherId)
                .HasConstraintName("Cattles_ibfk_3");

            entity.HasOne(d => d.LastUpdatedByNavigation).WithMany(p => p.Cattles)
                .HasForeignKey(d => d.LastUpdatedBy)
                .HasConstraintName("Cattles_ibfk_6");

            entity.HasOne(d => d.Mother).WithMany(p => p.InverseMother)
                .HasForeignKey(d => d.MotherId)
                .HasConstraintName("Cattles_ibfk_4");
        });

        modelBuilder.Entity<CattleAnimalChip>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.CattleId, "CattleId");

            entity.HasIndex(e => e.ChipId, "ChipId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CattleId).HasColumnType("int(11)");
            entity.Property(e => e.ChipId).HasColumnType("int(11)");

            entity.HasOne(d => d.Cattle).WithMany(p => p.CattleAnimalChips)
                .HasForeignKey(d => d.CattleId)
                .HasConstraintName("CattleAnimalChips_ibfk_1");

            entity.HasOne(d => d.Chip).WithMany(p => p.CattleAnimalChips)
                .HasForeignKey(d => d.ChipId)
                .HasConstraintName("CattleAnimalChips_ibfk_2");
        });

        modelBuilder.Entity<CattleBreed>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.BreedName, "BreedName").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)");
        });

        modelBuilder.Entity<CattleDestination>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.LastUpdatedBy, "LastUpdatedBy");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp");
            entity.Property(e => e.DestinationName).HasMaxLength(255);
            entity.Property(e => e.IsActive).HasDefaultValueSql("'1'");
            entity.Property(e => e.LastUpdatedBy).HasColumnType("int(11)");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp");

            entity.HasOne(d => d.LastUpdatedByNavigation).WithMany(p => p.CattleDestinations)
                .HasForeignKey(d => d.LastUpdatedBy)
                .HasConstraintName("CattleDestinations_ibfk_1");
        });

        modelBuilder.Entity<CattleManagement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("CattleManagement");

            entity.HasIndex(e => e.CattleId, "CattleId");

            entity.HasIndex(e => e.CreatedBy, "CreatedBy");

            entity.HasIndex(e => e.LastUpdatedBy, "LastUpdatedBy");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.ActionType).HasColumnType("enum('Alimentação','Vacinação','Pesagem','Outro')");
            entity.Property(e => e.CattleId).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp");
            entity.Property(e => e.CreatedBy).HasColumnType("int(11)");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.IsActive).HasDefaultValueSql("'1'");
            entity.Property(e => e.LastUpdatedBy).HasColumnType("int(11)");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp");

            entity.HasOne(d => d.Cattle).WithMany(p => p.CattleManagements)
                .HasForeignKey(d => d.CattleId)
                .HasConstraintName("CattleManagement_ibfk_1");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.CattleManagementCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("CattleManagement_ibfk_2");

            entity.HasOne(d => d.LastUpdatedByNavigation).WithMany(p => p.CattleManagementLastUpdatedByNavigations)
                .HasForeignKey(d => d.LastUpdatedBy)
                .HasConstraintName("CattleManagement_ibfk_3");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.FarmId, "FarmId");

            entity.HasIndex(e => e.LastUpdatedBy, "LastUpdatedBy");

            entity.HasIndex(e => e.PersonId, "PersonId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp");
            entity.Property(e => e.FarmId).HasColumnType("int(11)");
            entity.Property(e => e.IsActive).HasDefaultValueSql("'1'");
            entity.Property(e => e.LastUpdatedBy).HasColumnType("int(11)");
            entity.Property(e => e.Observations).HasColumnType("text");
            entity.Property(e => e.PersonId).HasColumnType("int(11)");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp");

            entity.HasOne(d => d.Farm).WithMany(p => p.Employees)
                .HasForeignKey(d => d.FarmId)
                .HasConstraintName("Employees_ibfk_2");

            entity.HasOne(d => d.LastUpdatedByNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.LastUpdatedBy)
                .HasConstraintName("Employees_ibfk_3");

            entity.HasOne(d => d.Person).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("Employees_ibfk_1");
        });

        modelBuilder.Entity<Farm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.LastUpdatedBy, "LastUpdatedBy");

            entity.HasIndex(e => e.OwnerId, "OwnerId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Cnpj)
                .HasMaxLength(14)
                .HasColumnName("CNPJ");
            entity.Property(e => e.CorporateName).HasMaxLength(255);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp");
            entity.Property(e => e.IsActive).HasDefaultValueSql("'1'");
            entity.Property(e => e.LastUpdatedBy).HasColumnType("int(11)");
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.OwnerId).HasColumnType("int(11)");
            entity.Property(e => e.Size).HasColumnType("enum('Pequeno','Médio','Grande')");
            entity.Property(e => e.TradeName).HasMaxLength(255);
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp");

            entity.HasOne(d => d.LastUpdatedByNavigation).WithMany(p => p.Farms)
                .HasForeignKey(d => d.LastUpdatedBy)
                .HasConstraintName("Farms_ibfk_2");

            entity.HasOne(d => d.Owner).WithMany(p => p.Farms)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("Farms_ibfk_1");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.IsActive).HasDefaultValueSql("'1'");
            entity.Property(e => e.LastName).HasMaxLength(255);
            entity.Property(e => e.LastUpdatedBy).HasColumnType("bigint(20)");
            entity.Property(e => e.Observation).HasColumnType("text");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.LastUpdatedBy, "LastUpdatedBy");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp");
            entity.Property(e => e.IsActive).HasDefaultValueSql("'1'");
            entity.Property(e => e.LastUpdatedBy).HasColumnType("int(11)");
            entity.Property(e => e.RoleName).HasMaxLength(255);
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp");

            entity.HasOne(d => d.LastUpdatedByNavigation).WithMany(p => p.Roles)
                .HasForeignKey(d => d.LastUpdatedBy)
                .HasConstraintName("Roles_ibfk_1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.PersonId, "PersonId");

            entity.HasIndex(e => e.UserId, "UserId").IsUnique();

            entity.HasIndex(e => e.Login, "idx_login");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp");
            entity.Property(e => e.IsActive).HasDefaultValueSql("'1'");
            entity.Property(e => e.LastLogin)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp");
            entity.Property(e => e.LoginFailures)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)");
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.PersonId).HasColumnType("int(11)");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp");

            entity.HasOne(d => d.Person).WithMany(p => p.Users)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("Users_ibfk_1");
        });

        modelBuilder.Entity<WeighingHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("WeighingHistory");

            entity.HasIndex(e => e.CattleId, "CattleId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CattleId).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp");
            entity.Property(e => e.IsActive).HasDefaultValueSql("'1'");
            entity.Property(e => e.Weight).HasPrecision(10, 2);

            entity.HasOne(d => d.Cattle).WithMany(p => p.WeighingHistories)
                .HasForeignKey(d => d.CattleId)
                .HasConstraintName("WeighingHistory_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
