﻿// <auto-generated />
using Logging.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Logging.Data.Migrations
{
    [DbContext(typeof(LoggingDbContext))]
    [Migration("20190107000330_Initialize")]
    partial class Initialize
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ChangeDetector.SkipDetectChanges", "true")
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");
#pragma warning restore 612, 618
        }
    }
}
