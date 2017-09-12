using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TellRachel.Data;

namespace TellRachel.Migrations
{
    [DbContext(typeof(TellRachelContext))]
    [Migration("20170902111934_Add_Common_Medicine")]
    partial class Add_Common_Medicine
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TellRachel.Domain.Entities.CommonMedicine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Caution");

                    b.Property<string>("Dosage");

                    b.Property<string>("Ingredients");

                    b.Property<string>("Maker");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<string>("ProductOverview");

                    b.Property<string>("ProductUrl");

                    b.Property<string>("PurchaseUrl");

                    b.Property<string>("Warning");

                    b.HasKey("Id");

                    b.ToTable("CommonMedicines");
                });

            modelBuilder.Entity("TellRachel.Domain.Entities.Medicine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Caution");

                    b.Property<string>("Dosage");

                    b.Property<string>("Ingredients");

                    b.Property<string>("Maker");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<Guid>("NoteId");

                    b.Property<string>("ProductOverview");

                    b.Property<string>("ProductUrl");

                    b.Property<string>("PurchaseUrl");

                    b.Property<string>("Warning");

                    b.HasKey("Id");

                    b.HasIndex("NoteId");

                    b.ToTable("Medicines");
                });

            modelBuilder.Entity("TellRachel.Domain.Entities.MedicineDose", b =>
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

            modelBuilder.Entity("TellRachel.Domain.Entities.Note", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDateUtc")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Email");

                    b.HasKey("Id");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("TellRachel.Domain.Entities.Symptom", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(1024);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<Guid>("NoteId");

                    b.Property<DateTime>("TakenDate");

                    b.Property<Guid?>("TemperatureId");

                    b.HasKey("Id");

                    b.HasIndex("NoteId");

                    b.HasIndex("TemperatureId");

                    b.ToTable("Symptoms");
                });

            modelBuilder.Entity("TellRachel.Domain.Entities.Temperature", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsFahrenheit");

                    b.Property<Guid>("NoteId");

                    b.Property<DateTime>("TakenDate");

                    b.Property<double>("Value");

                    b.HasKey("Id");

                    b.HasIndex("NoteId");

                    b.ToTable("Temperatures");
                });

            modelBuilder.Entity("TellRachel.Domain.Entities.Medicine", b =>
                {
                    b.HasOne("TellRachel.Domain.Entities.Note", "Note")
                        .WithMany()
                        .HasForeignKey("NoteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TellRachel.Domain.Entities.MedicineDose", b =>
                {
                    b.HasOne("TellRachel.Domain.Entities.Medicine", "Medicine")
                        .WithMany()
                        .HasForeignKey("MedicineId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TellRachel.Domain.Entities.Note")
                        .WithMany("MedicineDoses")
                        .HasForeignKey("NoteId");
                });

            modelBuilder.Entity("TellRachel.Domain.Entities.Symptom", b =>
                {
                    b.HasOne("TellRachel.Domain.Entities.Note", "Note")
                        .WithMany("Symptoms")
                        .HasForeignKey("NoteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TellRachel.Domain.Entities.Temperature", "Temperature")
                        .WithMany()
                        .HasForeignKey("TemperatureId");
                });

            modelBuilder.Entity("TellRachel.Domain.Entities.Temperature", b =>
                {
                    b.HasOne("TellRachel.Domain.Entities.Note", "Note")
                        .WithMany("Temperatures")
                        .HasForeignKey("NoteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
