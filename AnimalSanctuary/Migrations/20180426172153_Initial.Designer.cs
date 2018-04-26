using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AnimalSanctuary.Models;

namespace AnimalSanctuary.Migrations
{
    [DbContext(typeof(AnimalSanctuaryContext))]
    [Migration("20180426172153_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("AnimalSanctuary.Models.Animal", b =>
                {
                    b.Property<int>("AnimalId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("HabitatType");

                    b.Property<bool>("MedicalEmergency");

                    b.Property<string>("Name");

                    b.Property<string>("Sex");

                    b.Property<string>("Species");

                    b.Property<int>("VeterinarianId");

                    b.HasKey("AnimalId");

                    b.HasIndex("VeterinarianId");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("AnimalSanctuary.Models.Vet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Specialty");

                    b.HasKey("Id");

                    b.ToTable("Vets");
                });

            modelBuilder.Entity("AnimalSanctuary.Models.Animal", b =>
                {
                    b.HasOne("AnimalSanctuary.Models.Vet", "Veterinarian")
                        .WithMany()
                        .HasForeignKey("VeterinarianId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
