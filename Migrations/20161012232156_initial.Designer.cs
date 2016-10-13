using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ChatterboxApi.DAL;

namespace ChatterboxAppApi.Migrations
{
    [DbContext(typeof(ChatterboxContext))]
    [Migration("20161012232156_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("ChatterboxApi.DAL.Models.Chat", b =>
                {
                    b.Property<int>("ChatId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Name");

                    b.Property<int>("UserId");

                    b.HasKey("ChatId");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("ChatterboxApi.DAL.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ChatId");

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("MessageContent");

                    b.Property<int>("fromUserId");

                    b.HasKey("MessageId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("ChatterboxApi.DAL.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });
        }
    }
}
