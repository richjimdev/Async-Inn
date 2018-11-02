﻿// <auto-generated />
using AsyncInn.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AsyncInn.Migrations
{
    [DbContext(typeof(AsyncInnDbContext))]
    [Migration("20181101195021_bugfix")]
    partial class bugfix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AsyncInn.Models.Amenities", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("ID");

                    b.ToTable("Amenities");

                    b.HasData(
                        new { ID = 1, Name = "Coffee Machine" },
                        new { ID = 2, Name = "Flat Screen TV" },
                        new { ID = 3, Name = "Hot Tub" },
                        new { ID = 4, Name = "A/C" },
                        new { ID = 5, Name = "Toaster" }
                    );
                });

            modelBuilder.Entity("AsyncInn.Models.Hotel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Phone");

                    b.HasKey("ID");

                    b.ToTable("Hotels");

                    b.HasData(
                        new { ID = 1, Address = "12 Async Way, Seattle, WA 91234", Name = "Async Seattle", Phone = "206-123-1234" },
                        new { ID = 2, Address = "12 Async Way, New York City, NY 91234", Name = "Async NYC", Phone = "555-123-1234" },
                        new { ID = 3, Address = "12 Async Way, Los Angeles, CA 91234", Name = "Async LA", Phone = "555-123-1234" },
                        new { ID = 4, Address = "12 Async Way, Portland, OR 91234", Name = "Async Portland", Phone = "555-123-1234" },
                        new { ID = 5, Address = "12 Async Way, Honolulu, HI 91234", Name = "Async Honolulu", Phone = "555-123-1234" }
                    );
                });

            modelBuilder.Entity("AsyncInn.Models.HotelRoom", b =>
                {
                    b.Property<int>("HotelID");

                    b.Property<int>("RoomNumber");

                    b.Property<bool>("PetFriendly");

                    b.Property<decimal>("Rate");

                    b.Property<int>("RoomID");

                    b.HasKey("HotelID", "RoomNumber");

                    b.HasIndex("RoomID");

                    b.ToTable("HotelRooms");
                });

            modelBuilder.Entity("AsyncInn.Models.Room", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Layout");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("ID");

                    b.ToTable("Rooms");

                    b.HasData(
                        new { ID = 1, Layout = 1, Name = "Sleeping Orca" },
                        new { ID = 2, Layout = 0, Name = "Snoring Grizzly" },
                        new { ID = 3, Layout = 2, Name = "Snozing Dolphin" },
                        new { ID = 4, Layout = 1, Name = "Lazy Sloth" },
                        new { ID = 5, Layout = 2, Name = "Sleepy Panda" },
                        new { ID = 6, Layout = 0, Name = "Yawning Peacock" }
                    );
                });

            modelBuilder.Entity("AsyncInn.Models.RoomAmenities", b =>
                {
                    b.Property<int>("AmenitiesID");

                    b.Property<int>("RoomID");

                    b.HasKey("AmenitiesID", "RoomID");

                    b.HasIndex("RoomID");

                    b.ToTable("RoomAmenities");
                });

            modelBuilder.Entity("AsyncInn.Models.HotelRoom", b =>
                {
                    b.HasOne("AsyncInn.Models.Hotel", "Hotel")
                        .WithMany("HotelRooms")
                        .HasForeignKey("HotelID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AsyncInn.Models.Room", "Room")
                        .WithMany("HotelRoom")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AsyncInn.Models.RoomAmenities", b =>
                {
                    b.HasOne("AsyncInn.Models.Amenities", "Amenity")
                        .WithMany("RoomAmenities")
                        .HasForeignKey("AmenitiesID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AsyncInn.Models.Room", "Room")
                        .WithMany("RoomAmenities")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}