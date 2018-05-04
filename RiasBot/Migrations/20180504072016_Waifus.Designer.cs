﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using RiasBot.Services.Database;

namespace RiasBot.Migrations
{
    [DbContext(typeof(RiasContext))]
    [Migration("20180504072016_Waifus")]
    partial class Waifus
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-preview1-28290");

            modelBuilder.Entity("RiasBot.Services.Database.Models.GuildConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<ulong>("AutoAssignableRole");

                    b.Property<bool>("Bye");

                    b.Property<ulong>("ByeChannel");

                    b.Property<string>("ByeMessage");

                    b.Property<DateTime?>("DateAdded");

                    b.Property<bool>("Greet");

                    b.Property<ulong>("GreetChannel");

                    b.Property<string>("GreetMessage");

                    b.Property<ulong>("GuildId");

                    b.Property<ulong>("ModLogChannel");

                    b.Property<ulong>("MuteRole");

                    b.Property<string>("Prefix");

                    b.Property<string>("PunishmentMethod");

                    b.Property<int>("WarnsPunishment");

                    b.Property<bool>("XpGuildNotification");

                    b.HasKey("Id");

                    b.HasIndex("GuildId")
                        .IsUnique();

                    b.ToTable("Guilds");
                });

            modelBuilder.Entity("RiasBot.Services.Database.Models.Patreon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DateAdded");

                    b.Property<DateTime>("NextTimeReward");

                    b.Property<int>("Reward");

                    b.Property<ulong>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Patreon");
                });

            modelBuilder.Entity("RiasBot.Services.Database.Models.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BackgroundDim");

                    b.Property<string>("BackgroundUrl");

                    b.Property<string>("Bio");

                    b.Property<DateTime?>("DateAdded");

                    b.Property<ulong>("MarriedUser");

                    b.Property<ulong>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Profile");
                });

            modelBuilder.Entity("RiasBot.Services.Database.Models.SelfAssignableRoles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DateAdded");

                    b.Property<ulong>("GuildId");

                    b.Property<ulong>("RoleId");

                    b.Property<string>("RoleName");

                    b.HasKey("Id");

                    b.ToTable("SelfAssignableRoles");
                });

            modelBuilder.Entity("RiasBot.Services.Database.Models.UserConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Currency");

                    b.Property<DateTime?>("DateAdded");

                    b.Property<int>("Level");

                    b.Property<DateTime>("MessageDateTime");

                    b.Property<ulong>("UserId");

                    b.Property<int>("Xp");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RiasBot.Services.Database.Models.Waifus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BelovedWaifuPicture");

                    b.Property<DateTime?>("DateAdded");

                    b.Property<bool>("IsPrimary");

                    b.Property<ulong>("UserId");

                    b.Property<int>("WaifuId");

                    b.Property<string>("WaifuName");

                    b.Property<string>("WaifuPicture");

                    b.Property<int>("WaifuPrice");

                    b.Property<string>("WaifuUrl");

                    b.HasKey("Id");

                    b.ToTable("Waifus");
                });

            modelBuilder.Entity("RiasBot.Services.Database.Models.Warnings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DateAdded");

                    b.Property<ulong>("GuildId");

                    b.Property<ulong>("Moderator");

                    b.Property<string>("Reason");

                    b.Property<ulong>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Warnings");
                });

            modelBuilder.Entity("RiasBot.Services.Database.Models.XpRolesSystem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DateAdded");

                    b.Property<ulong>("GuildId");

                    b.Property<int>("Level");

                    b.Property<ulong>("RoleId");

                    b.HasKey("Id");

                    b.ToTable("XpRolesSystem");
                });

            modelBuilder.Entity("RiasBot.Services.Database.Models.XpSystem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DateAdded");

                    b.Property<ulong>("GuildId");

                    b.Property<int>("Level");

                    b.Property<DateTime>("MessageDateTime");

                    b.Property<ulong>("UserId");

                    b.Property<int>("Xp");

                    b.HasKey("Id");

                    b.ToTable("XpSystem");
                });
#pragma warning restore 612, 618
        }
    }
}
