﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using WebSiteArchitect.EntityModel;

namespace WebSiteArchitect.EntityModel.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20171118102925_AddIdentityID")]
    partial class AddIdentityID
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebSiteArchitect.EntityModel.Menu", b =>
                {
                    b.Property<int>("MenuId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("SiteId");

                    b.HasKey("MenuId");

                    b.HasIndex("SiteId");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("WebSiteArchitect.EntityModel.Page", b =>
                {
                    b.Property<int>("PageId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("SiteId");

                    b.HasKey("PageId");

                    b.HasIndex("SiteId");

                    b.ToTable("Page");
                });

            modelBuilder.Entity("WebSiteArchitect.EntityModel.Site", b =>
                {
                    b.Property<int>("SiteId")
                        .ValueGeneratedOnAdd();

                    b.HasKey("SiteId");

                    b.ToTable("Site");
                });

            modelBuilder.Entity("WebSiteArchitect.EntityModel.Menu", b =>
                {
                    b.HasOne("WebSiteArchitect.EntityModel.Site", "Site")
                        .WithMany("Menus")
                        .HasForeignKey("SiteId");
                });

            modelBuilder.Entity("WebSiteArchitect.EntityModel.Page", b =>
                {
                    b.HasOne("WebSiteArchitect.EntityModel.Site", "Site")
                        .WithMany("Pages")
                        .HasForeignKey("SiteId");
                });
#pragma warning restore 612, 618
        }
    }
}
