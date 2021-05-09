﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using easydd.infrastructure.context;

namespace easydd.infrastructure.Migrations
{
    [DbContext(typeof(EasyContext))]
    partial class EasyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("easydd.core.model.Coin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BaseValue")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CoinLootId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Denomination")
                        .HasColumnType("TEXT");

                    b.Property<double>("Probability")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("CoinLootId");

                    b.ToTable("Coins");
                });

            modelBuilder.Entity("easydd.core.model.CoinLoot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("LootName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CoinLoot");
                });

            modelBuilder.Entity("easydd.core.model.EasyRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("easydd.core.model.EasyUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("easydd.core.model.Loot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Value")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Loot");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2021, 5, 9, 19, 4, 41, 970, DateTimeKind.Local).AddTicks(640),
                            Name = "Copper",
                            Value = 1
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2021, 5, 9, 19, 4, 41, 970, DateTimeKind.Local).AddTicks(1085),
                            Name = "Silver",
                            Value = 10
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2021, 5, 9, 19, 4, 41, 970, DateTimeKind.Local).AddTicks(1094),
                            Name = "Electrum",
                            Value = 50
                        },
                        new
                        {
                            Id = 4,
                            Created = new DateTime(2021, 5, 9, 19, 4, 41, 970, DateTimeKind.Local).AddTicks(1096),
                            Name = "Gold",
                            Value = 100
                        },
                        new
                        {
                            Id = 5,
                            Created = new DateTime(2021, 5, 9, 19, 4, 41, 970, DateTimeKind.Local).AddTicks(1098),
                            Name = "Platinum",
                            Value = 100
                        });
                });

            modelBuilder.Entity("easydd.core.model.LootChance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<bool>("GuaranteedFind")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LootId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LootTableId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaxOccurrence")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WeightedOccurrence")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("LootId");

                    b.HasIndex("LootTableId");

                    b.ToTable("LootChances");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2021, 5, 9, 19, 4, 41, 970, DateTimeKind.Local).AddTicks(2219),
                            GuaranteedFind = false,
                            LootId = 1,
                            LootTableId = 1,
                            MaxOccurrence = 0,
                            WeightedOccurrence = 20
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2021, 5, 9, 19, 4, 41, 970, DateTimeKind.Local).AddTicks(2674),
                            GuaranteedFind = false,
                            LootId = 2,
                            LootTableId = 1,
                            MaxOccurrence = 0,
                            WeightedOccurrence = 10
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2021, 5, 9, 19, 4, 41, 970, DateTimeKind.Local).AddTicks(2682),
                            GuaranteedFind = false,
                            LootId = 4,
                            LootTableId = 1,
                            MaxOccurrence = 2,
                            WeightedOccurrence = 1
                        });
                });

            modelBuilder.Entity("easydd.core.model.LootTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Note")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("LootTables");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2021, 5, 9, 19, 4, 41, 970, DateTimeKind.Local).AddTicks(1457),
                            Name = "Simple Coins",
                            Note = "A mix of silver and copper with a low chance of golden coins appearing (max 2)"
                        });
                });

            modelBuilder.Entity("easydd.core.model.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Label")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2021, 5, 9, 19, 4, 41, 967, DateTimeKind.Local).AddTicks(3111),
                            Label = "Sticker"
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2021, 5, 9, 19, 4, 41, 969, DateTimeKind.Local).AddTicks(3756),
                            Label = "Background"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("easydd.core.model.EasyRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("easydd.core.model.EasyUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("easydd.core.model.EasyUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("easydd.core.model.EasyRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("easydd.core.model.EasyUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("easydd.core.model.EasyUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("easydd.core.model.Coin", b =>
                {
                    b.HasOne("easydd.core.model.CoinLoot", "CoinLoot")
                        .WithMany("Coins")
                        .HasForeignKey("CoinLootId");

                    b.Navigation("CoinLoot");
                });

            modelBuilder.Entity("easydd.core.model.LootChance", b =>
                {
                    b.HasOne("easydd.core.model.Loot", "Loot")
                        .WithMany("Chances")
                        .HasForeignKey("LootId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("easydd.core.model.LootTable", "LootTable")
                        .WithMany("LootChances")
                        .HasForeignKey("LootTableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Loot");

                    b.Navigation("LootTable");
                });

            modelBuilder.Entity("easydd.core.model.CoinLoot", b =>
                {
                    b.Navigation("Coins");
                });

            modelBuilder.Entity("easydd.core.model.Loot", b =>
                {
                    b.Navigation("Chances");
                });

            modelBuilder.Entity("easydd.core.model.LootTable", b =>
                {
                    b.Navigation("LootChances");
                });
#pragma warning restore 612, 618
        }
    }
}
