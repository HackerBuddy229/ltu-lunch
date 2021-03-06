// <auto-generated />
using LtuLunch.Server.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LtuLunch.Server.Migrations
{
    [DbContext(typeof(LunchDbContext))]
    [Migration("20211128145607_NodaTimeForRestaurant")]
    partial class NodaTimeForRestaurant
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Lunch", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("ResturantId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ResturantId1")
                        .HasColumnType("text");

                    b.Property<string>("ResturantId2")
                        .HasColumnType("text");

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<LocalDate>("When")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("ResturantId");

                    b.HasIndex("ResturantId1");

                    b.HasIndex("ResturantId2");

                    b.ToTable("Lunches");
                });

            modelBuilder.Entity("Resturant", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Period>("OpenFor")
                        .IsRequired()
                        .HasColumnType("interval");

                    b.Property<LocalTime>("OpensWhen")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("Resturants");
                });

            modelBuilder.Entity("Lunch", b =>
                {
                    b.HasOne("Resturant", "Resturant")
                        .WithMany("Menu")
                        .HasForeignKey("ResturantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Resturant", null)
                        .WithMany()
                        .HasForeignKey("ResturantId1");

                    b.HasOne("Resturant", null)
                        .WithMany()
                        .HasForeignKey("ResturantId2");

                    b.Navigation("Resturant");
                });

            modelBuilder.Entity("Resturant", b =>
                {
                    b.Navigation("Menu");
                });
#pragma warning restore 612, 618
        }
    }
}
