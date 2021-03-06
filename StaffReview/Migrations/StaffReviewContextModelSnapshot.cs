﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using StaffReview.Models;

namespace StaffReview.Migrations
{
    [DbContext(typeof(StaffReviewContext))]
    partial class StaffReviewContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StaffReview.Models.Staff", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("JobTitle");

                    b.Property<string>("LastName");

                    b.Property<decimal>("Rating");

                    b.Property<string>("Review");

                    b.HasKey("ID");

                    b.ToTable("Staff");
                });
        }
    }
}
