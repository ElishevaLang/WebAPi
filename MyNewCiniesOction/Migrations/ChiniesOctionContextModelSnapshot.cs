﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyNewCiniesOction.DAL;

#nullable disable

namespace MyNewCiniesOction.Migrations
{
    [DbContext(typeof(ChiniesOctionContext))]
    partial class ChiniesOctionContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MyNewCiniesOction.Models.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartId"), 1L, 1);

                    b.Property<int>("GiftId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CartId");

                    b.HasIndex("GiftId");

                    b.HasIndex("UserId");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("MyNewCiniesOction.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("MyNewCiniesOction.Models.Donation", b =>
                {
                    b.Property<int>("DonationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DonationId"), 1L, 1);

                    b.Property<int>("DonorId")
                        .HasColumnType("int");

                    b.Property<int>("GiftId")
                        .HasColumnType("int");

                    b.HasKey("DonationId");

                    b.HasIndex("DonorId");

                    b.HasIndex("GiftId");

                    b.ToTable("Donation");
                });

            modelBuilder.Entity("MyNewCiniesOction.Models.Donor", b =>
                {
                    b.Property<int>("DonorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DonorId"), 1L, 1);

                    b.Property<string>("DonorEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DonorFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DonorLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeOfDonate")
                        .HasColumnType("int");

                    b.HasKey("DonorId");

                    b.ToTable("Donor");
                });

            modelBuilder.Entity("MyNewCiniesOction.Models.Gift", b =>
                {
                    b.Property<int>("GiftId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GiftId"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("GiftDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GiftImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GiftName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GiftPrice")
                        .HasColumnType("int");

                    b.HasKey("GiftId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Gift");
                });

            modelBuilder.Entity("MyNewCiniesOction.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderSum")
                        .HasColumnType("int");

                    b.Property<int>("OrederSumItems")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("MyNewCiniesOction.Models.OrderItems", b =>
                {
                    b.Property<int>("OrderItemsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderItemsId"), 1L, 1);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("GiftId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("OrderItemsId");

                    b.HasIndex("GiftId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("MyNewCiniesOction.Models.Raffle", b =>
                {
                    b.Property<int>("RaffleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RaffleId"), 1L, 1);

                    b.Property<int>("GiftId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RaffleDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RaffleId");

                    b.HasIndex("GiftId");

                    b.HasIndex("UserId");

                    b.ToTable("Raffle");
                });

            modelBuilder.Entity("MyNewCiniesOction.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("UserIsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("UserPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("MyNewCiniesOction.Models.Winning", b =>
                {
                    b.Property<int>("WinningId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WinningId"), 1L, 1);

                    b.Property<int>("GiftId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("WinningId");

                    b.HasIndex("GiftId");

                    b.HasIndex("UserId");

                    b.ToTable("Winning");
                });

            modelBuilder.Entity("MyNewCiniesOction.Models.Cart", b =>
                {
                    b.HasOne("MyNewCiniesOction.Models.Gift", "Gift")
                        .WithMany()
                        .HasForeignKey("GiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyNewCiniesOction.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gift");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyNewCiniesOction.Models.Donation", b =>
                {
                    b.HasOne("MyNewCiniesOction.Models.Donor", "Donor")
                        .WithMany()
                        .HasForeignKey("DonorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyNewCiniesOction.Models.Gift", "Gift")
                        .WithMany()
                        .HasForeignKey("GiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Donor");

                    b.Navigation("Gift");
                });

            modelBuilder.Entity("MyNewCiniesOction.Models.Gift", b =>
                {
                    b.HasOne("MyNewCiniesOction.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("MyNewCiniesOction.Models.Order", b =>
                {
                    b.HasOne("MyNewCiniesOction.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyNewCiniesOction.Models.OrderItems", b =>
                {
                    b.HasOne("MyNewCiniesOction.Models.Gift", "Gift")
                        .WithMany()
                        .HasForeignKey("GiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyNewCiniesOction.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gift");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("MyNewCiniesOction.Models.Raffle", b =>
                {
                    b.HasOne("MyNewCiniesOction.Models.Gift", "Gift")
                        .WithMany()
                        .HasForeignKey("GiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyNewCiniesOction.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gift");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyNewCiniesOction.Models.Winning", b =>
                {
                    b.HasOne("MyNewCiniesOction.Models.Gift", "Gift")
                        .WithMany()
                        .HasForeignKey("GiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyNewCiniesOction.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gift");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
