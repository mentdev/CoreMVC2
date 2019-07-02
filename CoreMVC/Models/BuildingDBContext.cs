using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoreMVC.Models
{
    public partial class BuildingDBContext : DbContext
    {
        public BuildingDBContext()
        {
        }

        public BuildingDBContext(DbContextOptions<BuildingDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Asset> Asset { get; set; }
        public virtual DbSet<AssetInRoom> AssetInRoom { get; set; }
        public virtual DbSet<AssetType> AssetType { get; set; }
        public virtual DbSet<Building> Building { get; set; }
        public virtual DbSet<Floor> Floor { get; set; }
        public virtual DbSet<Room> Room { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\;Database=BuildingDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Asset>(entity =>
            {
                entity.Property(e => e.AssetId).HasColumnName("assetID");

                entity.Property(e => e.AssetCode)
                    .HasColumnName("assetCode")
                    .HasMaxLength(50);

                entity.Property(e => e.AssetName)
                    .HasColumnName("assetName")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<AssetInRoom>(entity =>
            {
                entity.Property(e => e.AssetInRoomId).HasColumnName("assetInRoomID");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.AssetId).HasColumnName("assetID");

                entity.Property(e => e.AssetTypeId).HasColumnName("assetTypeID");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("createDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Detail)
                    .HasColumnName("detail")
                    .HasMaxLength(250);

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("lastUpdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecSt).HasColumnName("recST");

                entity.Property(e => e.RoomId).HasColumnName("roomID");

                entity.Property(e => e.UserCreate)
                    .HasColumnName("userCreate")
                    .HasMaxLength(50);

                entity.Property(e => e.UserUpdate)
                    .HasColumnName("userUpdate")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.AssetInRoom)
                    .HasForeignKey(d => d.AssetId)
                    .HasConstraintName("FK_AssetInRoom_Asset");

                entity.HasOne(d => d.AssetType)
                    .WithMany(p => p.AssetInRoom)
                    .HasForeignKey(d => d.AssetTypeId)
                    .HasConstraintName("FK_AssetInRoom_AssetType");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.AssetInRoom)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK_AssetInRoom_Room");
            });

            modelBuilder.Entity<AssetType>(entity =>
            {
                entity.Property(e => e.AssetTypeId).HasColumnName("assetTypeID");

                entity.Property(e => e.AssetTypeName)
                    .HasColumnName("assetTypeName")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Building>(entity =>
            {
                entity.Property(e => e.BuildingId).HasColumnName("buildingID");

                entity.Property(e => e.BuildingCode)
                    .HasColumnName("buildingCode")
                    .HasMaxLength(250);

                entity.Property(e => e.BuildingName)
                    .HasColumnName("buildingName")
                    .HasMaxLength(250);

                entity.Property(e => e.Detail)
                    .HasColumnName("detail")
                    .HasMaxLength(50);

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Floor>(entity =>
            {
                entity.Property(e => e.FloorId).HasColumnName("floorID");

                entity.Property(e => e.BuildingId).HasColumnName("buildingID");

                entity.Property(e => e.Detail)
                    .HasColumnName("detail")
                    .HasMaxLength(250);

                entity.Property(e => e.FloorName)
                    .HasColumnName("floorName")
                    .HasMaxLength(250);

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.Floor)
                    .HasForeignKey(d => d.BuildingId)
                    .HasConstraintName("FK_Floor_Building");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.RoomId).HasColumnName("roomID");

                entity.Property(e => e.Detail)
                    .HasColumnName("detail")
                    .HasMaxLength(250);

                entity.Property(e => e.FloorId).HasColumnName("floorID");

                entity.Property(e => e.RoomName)
                    .HasColumnName("roomName")
                    .HasMaxLength(250);

                entity.HasOne(d => d.Floor)
                    .WithMany(p => p.Room)
                    .HasForeignKey(d => d.FloorId)
                    .HasConstraintName("FK_Room_Floor");
            });
        }
    }
}
