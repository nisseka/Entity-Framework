﻿// <auto-generated />
using Entity_Framework.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Entity_Framework.Migrations
{
    [DbContext(typeof(DatabaseDbContext))]
    [Migration("20211206055440_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entity_Framework.Data.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            Name = "Lidköping"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 1,
                            Name = "Skövde"
                        },
                        new
                        {
                            Id = 3,
                            CountryId = 1,
                            Name = "Skara"
                        });
                });

            modelBuilder.Entity("Entity_Framework.Data.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryCode = "SE",
                            Name = "Sverige"
                        },
                        new
                        {
                            Id = 2,
                            CountryCode = "NO",
                            Name = "Norge"
                        },
                        new
                        {
                            Id = 3,
                            CountryCode = "US",
                            Name = "USA"
                        });
                });

            modelBuilder.Entity("Entity_Framework.Data.DBPerson", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CityId");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CityId = 1,
                            Name = "Niklas",
                            PhoneNumber = "0510-28826"
                        },
                        new
                        {
                            ID = 2,
                            CityId = 2,
                            Name = "Per",
                            PhoneNumber = "0500-85855"
                        },
                        new
                        {
                            ID = 3,
                            CityId = 3,
                            Name = "Otto",
                            PhoneNumber = "0511-32448"
                        });
                });

            modelBuilder.Entity("Entity_Framework.Data.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Svenska"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Norska"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Danska"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Engelska (UK)"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Engelska (US)"
                        });
                });

            modelBuilder.Entity("Entity_Framework.Data.MenuLink", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("LinkURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Name");

                    b.ToTable("MenuLinks");

                    b.HasData(
                        new
                        {
                            Name = "AJAX",
                            LinkURL = "/AJAX/",
                            Title = "AJAX Mode"
                        },
                        new
                        {
                            Name = "Cities",
                            LinkURL = "/Cities/",
                            Title = "Cities"
                        },
                        new
                        {
                            Name = "Countries",
                            LinkURL = "/Countries/",
                            Title = "Countries"
                        },
                        new
                        {
                            Name = "Languages",
                            LinkURL = "/Languages/",
                            Title = "Languages"
                        },
                        new
                        {
                            Name = "People",
                            LinkURL = "/Home/",
                            Title = "People"
                        });
                });

            modelBuilder.Entity("Entity_Framework.Data.PersonLanguage", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.HasKey("PersonId", "LanguageId");

                    b.HasIndex("LanguageId");

                    b.ToTable("PersonLanguages");

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            LanguageId = 1
                        },
                        new
                        {
                            PersonId = 2,
                            LanguageId = 1
                        },
                        new
                        {
                            PersonId = 3,
                            LanguageId = 1
                        });
                });

            modelBuilder.Entity("Entity_Framework.Data.City", b =>
                {
                    b.HasOne("Entity_Framework.Data.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entity_Framework.Data.DBPerson", b =>
                {
                    b.HasOne("Entity_Framework.Data.City", "City")
                        .WithMany("People")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entity_Framework.Data.PersonLanguage", b =>
                {
                    b.HasOne("Entity_Framework.Data.Language", "Language")
                        .WithMany("People")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity_Framework.Data.DBPerson", "Person")
                        .WithMany("Languages")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}