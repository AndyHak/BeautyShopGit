﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(BeautyShopDbContext))]
    [Migration("20200222194705_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("MembershipId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MembershipId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Core.Membership", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("DiscountProduct")
                        .HasColumnType("float");

                    b.Property<double>("DiscountService")
                        .HasColumnType("float");

                    b.Property<string>("MembershipType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Memberships");
                });

            modelBuilder.Entity("Core.ShopItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("ShopItemType")
                        .HasColumnType("int");

                    b.Property<int>("VisitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VisitId");

                    b.ToTable("ShopItem");
                });

            modelBuilder.Entity("Core.Visit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int?>("CustomoerId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Visits");
                });

            modelBuilder.Entity("Core.Customer", b =>
                {
                    b.HasOne("Core.Membership", "Membership")
                        .WithMany()
                        .HasForeignKey("MembershipId");
                });

            modelBuilder.Entity("Core.ShopItem", b =>
                {
                    b.HasOne("Core.Visit", "Visit")
                        .WithMany("ShopItems")
                        .HasForeignKey("VisitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Visit", b =>
                {
                    b.HasOne("Core.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");
                });
#pragma warning restore 612, 618
        }
    }
}
