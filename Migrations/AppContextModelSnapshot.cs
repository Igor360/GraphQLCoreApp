﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication3GraphQL.Contexts;
using AppContext = WebApplication3GraphQL.Contexts.AppContext;

namespace WebApplication3GraphQL.Migrations
{
    [DbContext(typeof(AppContext))]
    partial class AppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("WebApplication3GraphQL.Models.GroupSensors", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnName("created_at");

                    b.Property<int>("GroupId")
                        .HasColumnName("group_id");

                    b.Property<int>("SensorId")
                        .HasColumnName("sensor_id");

                    b.Property<int?>("SensorsGroupsId");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("SensorId");

                    b.HasIndex("SensorsGroupsId");

                    b.ToTable("group_sensors");
                });

            modelBuilder.Entity("WebApplication3GraphQL.Models.SensorDatas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Code")
                        .HasColumnName("code");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .HasColumnName("name");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnName("updated_at");

                    b.Property<string>("Value")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.ToTable("sensor_data");
                });

            modelBuilder.Entity("WebApplication3GraphQL.Models.SensorsGroups", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .HasColumnName("name");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnName("updated_at");

                    b.Property<int>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("sensors_groups");
                });

            modelBuilder.Entity("WebApplication3GraphQL.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasMaxLength(100);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnName("email_confirmed");

                    b.Property<string>("FirstName")
                        .HasColumnName("first_name")
                        .HasMaxLength(60);

                    b.Property<string>("LastName")
                        .HasColumnName("last_name")
                        .HasMaxLength(60);

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnName("password_hash");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnName("password_salt");

                    b.Property<string>("Token")
                        .HasColumnName("token");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnName("updated_at");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnName("username")
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("WebApplication3GraphQL.Models.GroupSensors", b =>
                {
                    b.HasOne("WebApplication3GraphQL.Models.SensorDatas", "Sensor")
                        .WithMany("GroupSensorses")
                        .HasForeignKey("SensorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication3GraphQL.Models.SensorsGroups", "SensorsGroups")
                        .WithMany("SensorDatases")
                        .HasForeignKey("SensorsGroupsId");
                });

            modelBuilder.Entity("WebApplication3GraphQL.Models.SensorsGroups", b =>
                {
                    b.HasOne("WebApplication3GraphQL.Models.Users", "User")
                        .WithOne("SensorsGroups")
                        .HasForeignKey("WebApplication3GraphQL.Models.SensorsGroups", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
