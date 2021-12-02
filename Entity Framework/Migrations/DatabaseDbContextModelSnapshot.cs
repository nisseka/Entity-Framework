﻿// <auto-generated />
using Entity_Framework.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Entity_Framework.Migrations
{
    [DbContext(typeof(DatabaseDbContext))]
    partial class DatabaseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                            LinkURL = "/AJAX/Index",
                            Title = "AJAX Mode"
                        });
                });

            modelBuilder.Entity("Entity_Framework.Models.DBPerson", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            City = "Lidköping",
                            Name = "Niklas",
                            PhoneNumber = "0510-28826"
                        },
                        new
                        {
                            ID = 2,
                            City = "Skövde",
                            Name = "Per",
                            PhoneNumber = "0500-85855"
                        },
                        new
                        {
                            ID = 3,
                            City = "Skara",
                            Name = "Otto",
                            PhoneNumber = "0511-32448"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}