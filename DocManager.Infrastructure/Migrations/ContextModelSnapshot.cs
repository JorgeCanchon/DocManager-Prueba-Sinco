﻿// <auto-generated />
using System;
using DocManager.InfrastructureEF.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DocManager.InfrastructureEF.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DocManager.Domain.Entities.CustomField", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("DataType")
                        .HasColumnType("int");

                    b.Property<Guid>("ExpedienteTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FieldName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRequired")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExpedienteTypeId");

                    b.ToTable("CustomField");
                });

            modelBuilder.Entity("DocManager.Domain.Entities.Document", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ExpedienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FileHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileNameOriginal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FileSize")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ExpedienteId");

                    b.ToTable("Document");
                });

            modelBuilder.Entity("DocManager.Domain.Entities.Expediente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ExpedienteTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("UniqueIdentifier")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ExpedienteTypeId");

                    b.HasIndex("UniqueIdentifier")
                        .IsUnique();

                    b.ToTable("Expediente");
                });

            modelBuilder.Entity("DocManager.Domain.Entities.ExpedienteType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("ExpedienteType");
                });

            modelBuilder.Entity("DocManager.Domain.Entities.FieldListOption", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CustomFieldId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("OptionValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomFieldId");

                    b.ToTable("FieldListOption");
                });

            modelBuilder.Entity("DocManager.Domain.Entities.FieldValue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CustomFieldId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ExpedienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomFieldId");

                    b.HasIndex("ExpedienteId");

                    b.ToTable("FieldValue");
                });

            modelBuilder.Entity("DocManager.Domain.Entities.CustomField", b =>
                {
                    b.HasOne("DocManager.Domain.Entities.ExpedienteType", "ExpedienteType")
                        .WithMany("CustomFields")
                        .HasForeignKey("ExpedienteTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExpedienteType");
                });

            modelBuilder.Entity("DocManager.Domain.Entities.Document", b =>
                {
                    b.HasOne("DocManager.Domain.Entities.Expediente", "Expediente")
                        .WithMany("Documents")
                        .HasForeignKey("ExpedienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Expediente");
                });

            modelBuilder.Entity("DocManager.Domain.Entities.Expediente", b =>
                {
                    b.HasOne("DocManager.Domain.Entities.ExpedienteType", "ExpedienteType")
                        .WithMany()
                        .HasForeignKey("ExpedienteTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ExpedienteType");
                });

            modelBuilder.Entity("DocManager.Domain.Entities.FieldListOption", b =>
                {
                    b.HasOne("DocManager.Domain.Entities.CustomField", "CustomField")
                        .WithMany("Options")
                        .HasForeignKey("CustomFieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomField");
                });

            modelBuilder.Entity("DocManager.Domain.Entities.FieldValue", b =>
                {
                    b.HasOne("DocManager.Domain.Entities.CustomField", "CustomField")
                        .WithMany()
                        .HasForeignKey("CustomFieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DocManager.Domain.Entities.Expediente", "Expediente")
                        .WithMany("FieldValues")
                        .HasForeignKey("ExpedienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomField");

                    b.Navigation("Expediente");
                });

            modelBuilder.Entity("DocManager.Domain.Entities.CustomField", b =>
                {
                    b.Navigation("Options");
                });

            modelBuilder.Entity("DocManager.Domain.Entities.Expediente", b =>
                {
                    b.Navigation("Documents");

                    b.Navigation("FieldValues");
                });

            modelBuilder.Entity("DocManager.Domain.Entities.ExpedienteType", b =>
                {
                    b.Navigation("CustomFields");
                });
#pragma warning restore 612, 618
        }
    }
}
