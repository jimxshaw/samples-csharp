﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using FoodiesCore.Entities;

namespace FoodiesCore.Migrations
{
    [DbContext(typeof(FoodiesCoreDbContext))]
    [Migration("20161125171039_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FoodiesCore.Entities.Restaurant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Cuisine");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.HasKey("Id");

                    b.ToTable("Restaurants");
                });
        }
    }
}
