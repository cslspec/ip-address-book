﻿// <auto-generated />
using IPAddressBook.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IPAddressBook.Data.Migrations
{
    [DbContext(typeof(AddressBookDbContext))]
    partial class AddressBookDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("IPAddressBook.Model.IPAddressBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("IPAddressBase");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("IPAddressBook.Model.IPv4Address", b =>
                {
                    b.HasBaseType("IPAddressBook.Model.IPAddressBase");

                    b.Property<byte>("Octet1")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("Octet2")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("Octet3")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("Octet4")
                        .HasColumnType("INTEGER");

                    b.ToTable("IPv4Addresses");
                });

            modelBuilder.Entity("IPAddressBook.Model.IPv6Address", b =>
                {
                    b.HasBaseType("IPAddressBook.Model.IPAddressBase");

                    b.Property<ushort>("Group1")
                        .HasColumnType("INTEGER");

                    b.Property<ushort>("Group2")
                        .HasColumnType("INTEGER");

                    b.Property<ushort>("Group3")
                        .HasColumnType("INTEGER");

                    b.Property<ushort>("Group4")
                        .HasColumnType("INTEGER");

                    b.Property<ushort>("Group5")
                        .HasColumnType("INTEGER");

                    b.Property<ushort>("Group6")
                        .HasColumnType("INTEGER");

                    b.Property<ushort>("Group7")
                        .HasColumnType("INTEGER");

                    b.Property<ushort>("Group8")
                        .HasColumnType("INTEGER");

                    b.ToTable("IPv6Addresses");
                });

            modelBuilder.Entity("IPAddressBook.Model.IPv4Address", b =>
                {
                    b.HasOne("IPAddressBook.Model.IPAddressBase", null)
                        .WithOne()
                        .HasForeignKey("IPAddressBook.Model.IPv4Address", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IPAddressBook.Model.IPv6Address", b =>
                {
                    b.HasOne("IPAddressBook.Model.IPAddressBase", null)
                        .WithOne()
                        .HasForeignKey("IPAddressBook.Model.IPv6Address", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
