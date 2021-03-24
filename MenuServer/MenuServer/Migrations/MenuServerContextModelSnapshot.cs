﻿// <auto-generated />
using MenuServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MenuServer.Migrations
{
    [DbContext(typeof(MenuServerContext))]
    partial class MenuServerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MenuServer.Models.DayOfWeek", b =>
                {
                    b.Property<int>("DayOfWeekId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DayOfWeekName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DayOfWeekId");

                    b.ToTable("DayOfWeek");
                });

            modelBuilder.Entity("MenuServer.Models.Dish", b =>
                {
                    b.Property<int>("DishId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DishName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DishId");

                    b.ToTable("Dish");
                });

            modelBuilder.Entity("MenuServer.Models.Dish_Ingredient", b =>
                {
                    b.Property<int>("DishId")
                        .HasColumnType("int");

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.Property<int>("AmountOfIngredient")
                        .HasColumnType("int");

                    b.HasKey("DishId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("Dish_Ingredient");
                });

            modelBuilder.Entity("MenuServer.Models.Ingredient", b =>
                {
                    b.Property<int>("IngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IngredientCode")
                        .HasColumnType("int");

                    b.Property<string>("IngredientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IngredientId");

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("MenuServer.Models.Menu", b =>
                {
                    b.Property<int>("MenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DayOfWeekId")
                        .HasColumnType("int");

                    b.Property<int>("DishId")
                        .HasColumnType("int");

                    b.Property<int>("TimeOfDayId")
                        .HasColumnType("int");

                    b.HasKey("MenuId");

                    b.HasAlternateKey("DayOfWeekId", "TimeOfDayId");

                    b.HasIndex("DishId");

                    b.HasIndex("TimeOfDayId");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("MenuServer.Models.TimeOfDay", b =>
                {
                    b.Property<int>("TimeOfDayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TimeOfDayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TimeOfDayId");

                    b.ToTable("TimeOfDay");
                });

            modelBuilder.Entity("MenuServer.Models.Dish_Ingredient", b =>
                {
                    b.HasOne("MenuServer.Models.Dish", "Dish")
                        .WithMany("DishIngredients")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MenuServer.Models.Ingredient", "Ingredient")
                        .WithMany("IngredientDish")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("MenuServer.Models.Menu", b =>
                {
                    b.HasOne("MenuServer.Models.DayOfWeek", "DayOfWeek")
                        .WithMany("Menu")
                        .HasForeignKey("DayOfWeekId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MenuServer.Models.Dish", "Dish")
                        .WithMany("Menus")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MenuServer.Models.TimeOfDay", "TimeOfDay")
                        .WithMany("Menu")
                        .HasForeignKey("TimeOfDayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
