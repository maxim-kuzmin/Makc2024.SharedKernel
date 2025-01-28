﻿// <auto-generated />
using System;
using Makc2024.Dummy.Writer.Infrastructure.App.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Makc2024.Dummy.Writer.Infrastructure.App.Db.For.PostgreSQL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Makc2024.Dummy.Writer.DomainModel.AppEvent.AppEventEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<Guid>("ConcurrencyToken")
                        .IsConcurrencyToken()
                        .HasColumnType("uuid")
                        .HasColumnName("сoncurrency_token");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("boolean")
                        .HasColumnName("is_published");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_app_event");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("ux_app_event_name");

                    b.ToTable("app_event", "writer");
                });

            modelBuilder.Entity("Makc2024.Dummy.Writer.DomainModel.AppEventPayload.AppEventPayloadEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("AppEventId")
                        .HasColumnType("bigint")
                        .HasColumnName("app_event_id");

                    b.Property<Guid>("ConcurrencyToken")
                        .IsConcurrencyToken()
                        .HasColumnType("uuid")
                        .HasColumnName("сoncurrency_token");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("data");

                    b.HasKey("Id")
                        .HasName("pk_app_event_payload");

                    b.HasIndex("AppEventId");

                    b.ToTable("app_event_payload", "writer");
                });

            modelBuilder.Entity("Makc2024.Dummy.Writer.DomainModel.DummyItem.DummyItemEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<Guid>("ConcurrencyToken")
                        .IsConcurrencyToken()
                        .HasColumnType("uuid")
                        .HasColumnName("сoncurrency_token");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_dummy_item");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("ux_dummy_item_name");

                    b.ToTable("dummy_item", "writer");
                });

            modelBuilder.Entity("Makc2024.Dummy.Writer.DomainModel.AppEventPayload.AppEventPayloadEntity", b =>
                {
                    b.HasOne("Makc2024.Dummy.Writer.DomainModel.AppEvent.AppEventEntity", "Event")
                        .WithMany("Payloads")
                        .HasForeignKey("AppEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_app_event_payload_app_event");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Makc2024.Dummy.Writer.DomainModel.AppEvent.AppEventEntity", b =>
                {
                    b.Navigation("Payloads");
                });
#pragma warning restore 612, 618
        }
    }
}
