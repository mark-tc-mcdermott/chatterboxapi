using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Chatterbox.DAL;

namespace ChatterboxAppApi.Migrations
{
    [DbContext(typeof(ChatterboxContext))]
    partial class ChatterboxContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("ChatterboxApi.DAL.Models.Chat", b =>
                {
                    b.Property<int>("ChatId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Name");

                    b.HasKey("ChatId");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("ChatterboxApi.DAL.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ChatId");

                    b.Property<DateTime>("CreationDate");

                    b.Property<int?>("fromUserIdUserId");

                    b.Property<string>("messageContent");

                    b.Property<int?>("toUserIdUserId");

                    b.HasKey("MessageId");

                    b.HasIndex("ChatId");

                    b.HasIndex("fromUserIdUserId");

                    b.HasIndex("toUserIdUserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("ChatterboxApi.DAL.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("password");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ChatterboxApi.DAL.Models.Message", b =>
                {
                    b.HasOne("ChatterboxApi.DAL.Models.Chat", "chatId")
                        .WithMany()
                        .HasForeignKey("ChatId");

                    b.HasOne("ChatterboxApi.DAL.Models.User", "fromUserId")
                        .WithMany()
                        .HasForeignKey("fromUserIdUserId");

                    b.HasOne("ChatterboxApi.DAL.Models.User", "toUserId")
                        .WithMany()
                        .HasForeignKey("toUserIdUserId");
                });
        }
    }
}
