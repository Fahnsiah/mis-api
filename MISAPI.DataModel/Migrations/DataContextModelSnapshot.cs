﻿// <auto-generated />
using System;
using MISAPI.DataModel.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MISAPI.DataModel.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("MISAPI.DataModel.Models.Accounts.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("AcceptTerms")
                        .HasColumnType("bit");

                    b.Property<int>("CouncilId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime?>("PasswordReset")
                        .HasColumnType("datetime2");

                    b.Property<string>("ResetToken")
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)");

                    b.Property<DateTime?>("ResetTokenExpires")
                        .HasColumnType("datetime2");

                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<long?>("UpdateLogId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<long?>("UserLogId")
                        .HasColumnType("bigint");

                    b.Property<string>("VerificationToken")
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)");

                    b.Property<DateTime?>("Verified")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CouncilId");

                    b.HasIndex("RoleId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AcceptTerms = true,
                            CouncilId = 1,
                            CreatedOn = new DateTime(2023, 1, 26, 17, 46, 55, 356, DateTimeKind.Local).AddTicks(1074),
                            Email = "info@mis.org",
                            FirstName = "The Supreme",
                            Gender = "M",
                            LastName = "Knight",
                            MiddleName = " SK",
                            PasswordHash = "$2a$11$iaVeo8lVWgA1ffeAjv2rQeOoe2nX0KwPX0wv4NGXH5OzeIbffqnfa",
                            RoleId = 1,
                            Verified = new DateTime(2023, 1, 26, 17, 46, 55, 356, DateTimeKind.Local).AddTicks(1227)
                        });
                });

            modelBuilder.Entity("MISAPI.DataModel.Models.Councils.Council", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ConsecreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("CouncilTypeId")
                        .HasColumnType("int");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("No")
                        .HasColumnType("int");

                    b.Property<long?>("UpdateLogId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<long?>("UserLogId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CouncilTypeId");

                    b.HasIndex("CountryId");

                    b.ToTable("Councils");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "SecondI, Ghana",
                            ConsecreatedOn = new DateTime(1926, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CouncilTypeId = 1,
                            CountryId = 1,
                            CreatedOn = new DateTime(2023, 1, 26, 17, 46, 55, 355, DateTimeKind.Local).AddTicks(1834),
                            No = 1
                        });
                });

            modelBuilder.Entity("MISAPI.DataModel.Models.Councils.CouncilType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("CouncilType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Councils of the order",
                            Name = "COUNCIL"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Courts of the order",
                            Name = "COURT"
                        });
                });

            modelBuilder.Entity("MISAPI.DataModel.Models.Councils.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrencySymbol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Country");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Currency = "Cedis",
                            CurrencySymbol = "C",
                            Name = "Ghana",
                            Nationality = "Ghanian"
                        });
                });

            modelBuilder.Entity("MISAPI.DataModel.Models.Roles.Menu", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long?>("UpdateLogId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<long>("UserLogId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("MISAPI.DataModel.Models.Roles.MenuOperation", b =>
                {
                    b.Property<string>("MenuId")
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("OperationId")
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<long>("UserLogId")
                        .HasColumnType("bigint");

                    b.HasKey("MenuId", "OperationId");

                    b.ToTable("MenuOperations");
                });

            modelBuilder.Entity("MISAPI.DataModel.Models.Roles.Operation", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long?>("UpdateLogId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<long>("UserLogId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Operations");
                });

            modelBuilder.Entity("MISAPI.DataModel.Models.Roles.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long?>("UpdateLogId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<long>("UserLogId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedOn = new DateTime(2023, 1, 26, 17, 46, 55, 355, DateTimeKind.Local).AddTicks(5278),
                            Description = "The super admin roles",
                            Enabled = true,
                            IsDeleted = false,
                            Name = "Super Admin",
                            UserLogId = 0L
                        });
                });

            modelBuilder.Entity("MISAPI.DataModel.Models.Roles.RolePermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("MenuId")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("OperationId")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("SubMenuId")
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<long?>("UpdateLogId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<long>("UserLogId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("OperationId");

                    b.HasIndex("RoleId");

                    b.HasIndex("SubMenuId");

                    b.HasIndex("MenuId", "SubMenuId", "OperationId", "RoleId")
                        .IsUnique()
                        .HasFilter("[SubMenuId] IS NOT NULL");

                    b.ToTable("RolePermissions");
                });

            modelBuilder.Entity("MISAPI.DataModel.Models.Roles.SubMenu", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("MenuId")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long?>("UpdateLogId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<long>("UserLogId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("Id", "MenuId", "Name")
                        .IsUnique();

                    b.ToTable("SubMenus");
                });

            modelBuilder.Entity("MISAPI.DataModel.Models.Settings.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<long?>("UpdateLogId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<long>("UserLogId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("MISAPI.DataModel.Models.Settings.ConsecrationArticle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<long?>("UpdateLogId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<long>("UserLogId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId")
                        .IsUnique();

                    b.ToTable("ConsecrationArticles");
                });

            modelBuilder.Entity("MISAPI.DataModel.Models.Settings.ConsecrationRequirement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<decimal>("Fee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MinAdultBrother")
                        .HasColumnType("int");

                    b.Property<int>("MinAdultSister")
                        .HasColumnType("int");

                    b.Property<int>("MinJrBrother")
                        .HasColumnType("int");

                    b.Property<int>("MinJrSister")
                        .HasColumnType("int");

                    b.Property<long?>("UpdateLogId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<long>("UserLogId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.ToTable("ConsecrationRequirements");
                });

            modelBuilder.Entity("MISAPI.DataModel.Models.Settings.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("RateToUSD")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<long?>("UpdateLogId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<long>("UserLogId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("MISAPI.DataModel.Models.Settings.Ritual", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long?>("UpdateLogId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<long>("UserLogId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Rituals");
                });

            modelBuilder.Entity("MISAPI.DataModel.Models.Accounts.Account", b =>
                {
                    b.HasOne("MISAPI.DataModel.Models.Councils.Council", "Council")
                        .WithMany()
                        .HasForeignKey("CouncilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MISAPI.DataModel.Models.Roles.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsMany("MISAPI.DataModel.Models.Accounts.RefreshToken", "RefreshTokens", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .UseIdentityColumn();

                            b1.Property<int>("AccountId")
                                .HasColumnType("int");

                            b1.Property<DateTime>("Created")
                                .HasColumnType("datetime2");

                            b1.Property<string>("CreatedByIp")
                                .HasMaxLength(150)
                                .HasColumnType("nvarchar(150)");

                            b1.Property<DateTime>("Expires")
                                .HasColumnType("datetime2");

                            b1.Property<string>("ReplacedByToken")
                                .HasMaxLength(150)
                                .HasColumnType("nvarchar(150)");

                            b1.Property<DateTime?>("Revoked")
                                .HasColumnType("datetime2");

                            b1.Property<string>("RevokedByIp")
                                .HasMaxLength(150)
                                .HasColumnType("nvarchar(150)");

                            b1.Property<string>("Token")
                                .IsRequired()
                                .HasMaxLength(1500)
                                .HasColumnType("nvarchar(1500)");

                            b1.HasKey("Id");

                            b1.HasIndex("AccountId");

                            b1.ToTable("RefreshToken");

                            b1.WithOwner("Account")
                                .HasForeignKey("AccountId");

                            b1.Navigation("Account");
                        });

                    b.Navigation("Council");

                    b.Navigation("RefreshTokens");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("MISAPI.DataModel.Models.Councils.Council", b =>
                {
                    b.HasOne("MISAPI.DataModel.Models.Councils.CouncilType", "CouncilType")
                        .WithMany("Councils")
                        .HasForeignKey("CouncilTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MISAPI.DataModel.Models.Councils.Country", "Country")
                        .WithMany("Councils")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CouncilType");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("MISAPI.DataModel.Models.Roles.RolePermission", b =>
                {
                    b.HasOne("MISAPI.DataModel.Models.Roles.Menu", "Menu")
                        .WithMany("RolePermissions")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MISAPI.DataModel.Models.Roles.Operation", "Operation")
                        .WithMany("RolePermissions")
                        .HasForeignKey("OperationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MISAPI.DataModel.Models.Roles.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MISAPI.DataModel.Models.Roles.SubMenu", "SubMenu")
                        .WithMany("RolePermissions")
                        .HasForeignKey("SubMenuId");

                    b.Navigation("Menu");

                    b.Navigation("Operation");

                    b.Navigation("Role");

                    b.Navigation("SubMenu");
                });

            modelBuilder.Entity("MISAPI.DataModel.Models.Settings.Article", b =>
                {
                    b.HasOne("MISAPI.DataModel.Models.Settings.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("MISAPI.DataModel.Models.Settings.ConsecrationArticle", b =>
                {
                    b.HasOne("MISAPI.DataModel.Models.Settings.Article", "Article")
                        .WithMany()
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");
                });

            modelBuilder.Entity("MISAPI.DataModel.Models.Settings.ConsecrationRequirement", b =>
                {
                    b.HasOne("MISAPI.DataModel.Models.Settings.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("MISAPI.DataModel.Models.Councils.CouncilType", b =>
                {
                    b.Navigation("Councils");
                });

            modelBuilder.Entity("MISAPI.DataModel.Models.Councils.Country", b =>
                {
                    b.Navigation("Councils");
                });

            modelBuilder.Entity("MISAPI.DataModel.Models.Roles.Menu", b =>
                {
                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("MISAPI.DataModel.Models.Roles.Operation", b =>
                {
                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("MISAPI.DataModel.Models.Roles.Role", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("MISAPI.DataModel.Models.Roles.SubMenu", b =>
                {
                    b.Navigation("RolePermissions");
                });
#pragma warning restore 612, 618
        }
    }
}
