﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PatientInfo_API.Data;

#nullable disable

namespace PatientInfo_API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240519035650_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PatientInfo_API.Models.Allergy", b =>
                {
                    b.Property<int>("AllergyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AllergyId"));

                    b.Property<string>("AllergyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AllergyId");

                    b.ToTable("Allergies");
                });

            modelBuilder.Entity("PatientInfo_API.Models.Allergy_Detail", b =>
                {
                    b.Property<int>("Allergy_DetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Allergy_DetailId"));

                    b.Property<int?>("AllergyId")
                        .HasColumnType("int");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("Allergy_DetailId");

                    b.HasIndex("AllergyId");

                    b.HasIndex("PatientId");

                    b.ToTable("Allergy_Details");
                });

            modelBuilder.Entity("PatientInfo_API.Models.DiseaseInfo", b =>
                {
                    b.Property<int>("DiseaseInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiseaseInfoId"));

                    b.Property<string>("DiseaseName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DiseaseInfoId");

                    b.ToTable("Diseases");
                });

            modelBuilder.Entity("PatientInfo_API.Models.NDC", b =>
                {
                    b.Property<int>("NDCId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NDCId"));

                    b.Property<string>("NDCName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NDCId");

                    b.ToTable("NCDs");
                });

            modelBuilder.Entity("PatientInfo_API.Models.NDC_Detail", b =>
                {
                    b.Property<int>("NDC_DetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NDC_DetailId"));

                    b.Property<int?>("NDCId")
                        .HasColumnType("int");

                    b.Property<int?>("NDC_Id")
                        .HasColumnType("int");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("NDC_DetailId");

                    b.HasIndex("NDCId");

                    b.HasIndex("PatientId");

                    b.ToTable("NCD_Details");
                });

            modelBuilder.Entity("PatientInfo_API.Models.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientId"));

                    b.Property<int>("Epilepsy")
                        .HasColumnType("int");

                    b.Property<string>("PatientName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("PatientInfo_API.Models.Allergy_Detail", b =>
                {
                    b.HasOne("PatientInfo_API.Models.Allergy", "Allergy")
                        .WithMany()
                        .HasForeignKey("AllergyId");

                    b.HasOne("PatientInfo_API.Models.Patient", "Patient")
                        .WithMany("Allergy_Details")
                        .HasForeignKey("PatientId");

                    b.Navigation("Allergy");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("PatientInfo_API.Models.NDC_Detail", b =>
                {
                    b.HasOne("PatientInfo_API.Models.NDC", "NDC")
                        .WithMany()
                        .HasForeignKey("NDCId");

                    b.HasOne("PatientInfo_API.Models.Patient", "Patient")
                        .WithMany("NDC_Details")
                        .HasForeignKey("PatientId");

                    b.Navigation("NDC");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("PatientInfo_API.Models.Patient", b =>
                {
                    b.Navigation("Allergy_Details");

                    b.Navigation("NDC_Details");
                });
#pragma warning restore 612, 618
        }
    }
}