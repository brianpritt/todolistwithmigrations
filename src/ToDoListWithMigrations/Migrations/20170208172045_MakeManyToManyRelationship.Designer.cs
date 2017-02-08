using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ToDoListWithMigrations.Models;

namespace ToDoListWithMigrations.Migrations
{
    [DbContext(typeof(ToDoDbContext))]
    [Migration("20170208172045_MakeManyToManyRelationship")]
    partial class MakeManyToManyRelationship
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ToDoListWithMigrations.Models.Categorization", b =>
                {
                    b.Property<int>("CategorizationId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<int>("ItemId");

                    b.HasKey("CategorizationId");

                    b.HasIndex("CategoryId")
                        .IsUnique();

                    b.HasIndex("ItemId")
                        .IsUnique();

                    b.ToTable("Categorizations");
                });

            modelBuilder.Entity("ToDoListWithMigrations.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ToDoListWithMigrations.Models.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("ItemId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("ToDoListWithMigrations.Models.Categorization", b =>
                {
                    b.HasOne("ToDoListWithMigrations.Models.Category", "Category")
                        .WithOne("Categorizations")
                        .HasForeignKey("ToDoListWithMigrations.Models.Categorization", "CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ToDoListWithMigrations.Models.Item", "Item")
                        .WithOne("Categorizations")
                        .HasForeignKey("ToDoListWithMigrations.Models.Categorization", "ItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
