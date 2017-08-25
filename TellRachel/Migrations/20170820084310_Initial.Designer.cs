using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TellRachel.Data;

namespace TellRachel.Migrations
{
    [DbContext(typeof(TellRachelContext))]
    [Migration("20170820084310_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TellRachel.Entities.Medicine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<Guid>("NoteId");

                    b.HasKey("Id");

                    b.HasIndex("NoteId");

                    b.ToTable("Medicines");
                });

            modelBuilder.Entity("TellRachel.Entities.MedicineDose", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<Guid>("MedicineId");

                    b.Property<Guid?>("NoteId");

                    b.Property<DateTime>("TakenDate");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasMaxLength(16);

                    b.HasKey("Id");

                    b.HasIndex("MedicineId");

                    b.HasIndex("NoteId");

                    b.ToTable("MedicineDoses");
                });

            modelBuilder.Entity("TellRachel.Entities.Note", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.HasKey("Id");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("TellRachel.Entities.Symptom", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(1024);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<Guid>("NoteId");

                    b.Property<DateTime>("TakenDate");

                    b.Property<double>("TemperatureInCelsius");

                    b.HasKey("Id");

                    b.HasIndex("NoteId");

                    b.ToTable("Symptoms");
                });

            modelBuilder.Entity("TellRachel.Entities.Medicine", b =>
                {
                    b.HasOne("TellRachel.Entities.Note", "Note")
                        .WithMany()
                        .HasForeignKey("NoteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TellRachel.Entities.MedicineDose", b =>
                {
                    b.HasOne("TellRachel.Entities.Medicine", "Medicine")
                        .WithMany()
                        .HasForeignKey("MedicineId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TellRachel.Entities.Note")
                        .WithMany("MedicineDoses")
                        .HasForeignKey("NoteId");
                });

            modelBuilder.Entity("TellRachel.Entities.Symptom", b =>
                {
                    b.HasOne("TellRachel.Entities.Note", "Note")
                        .WithMany("Symptoms")
                        .HasForeignKey("NoteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
