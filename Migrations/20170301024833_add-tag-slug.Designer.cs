using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using MindHypertrophy.Models;

namespace MindHypertrophy.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20170301024833_add-tag-slug")]
    partial class addtagslug
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MindHypertrophy.Models.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content")
                        .HasAnnotation("Relational:ColumnType", "ntext");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Slug");

                    b.Property<string>("Summary");

                    b.Property<string>("Title");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("MindHypertrophy.Models.CardTag", b =>
                {
                    b.Property<int>("CardId");

                    b.Property<int>("TagId");

                    b.HasKey("CardId", "TagId");
                });

            modelBuilder.Entity("MindHypertrophy.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Slug");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("MindHypertrophy.Models.CardTag", b =>
                {
                    b.HasOne("MindHypertrophy.Models.Card")
                        .WithMany()
                        .HasForeignKey("CardId");

                    b.HasOne("MindHypertrophy.Models.Tag")
                        .WithMany()
                        .HasForeignKey("TagId");
                });
        }
    }
}
