﻿// <auto-generated />
using System;
using BankAccountUR.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BankAccountUR.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20200421173702_second")]
    partial class second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BankAccountUR.Models.BankAccount", b =>
                {
                    b.Property<int>("BAccountId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("TAmount");

                    b.Property<DateTime>("TDate");

                    b.Property<int>("UserId");

                    b.HasKey("BAccountId");

                    b.HasIndex("UserId");

                    b.ToTable("BankAccounts");
                });

            modelBuilder.Entity("BankAccountUR.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BAccountId");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BankAccountUR.Models.BankAccount", b =>
                {
                    b.HasOne("BankAccountUR.Models.User", "AccountCreator")
                        .WithMany("BankAccounts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
