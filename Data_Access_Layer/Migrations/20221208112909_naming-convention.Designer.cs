﻿// <auto-generated />
using System;
using Data_Access_Layer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Api.Migrations
{
	[DbContext(typeof(DBContext))]
	[Migration("20221208112909_naming-convention")]
	partial class namingconvention
	{
		/// <inheritdoc />
		protected override void BuildTargetModel(ModelBuilder modelBuilder)
		{
#pragma warning disable 612, 618
			modelBuilder
				.HasAnnotation("ProductVersion", "7.0.0")
				.HasAnnotation("Relational:MaxIdentifierLength", 128);

			SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

			modelBuilder.Entity("InCompanyAPI.Context.Models.ChoiceModel", b =>
				{
					b.Property<int>("Id")
						.ValueGeneratedOnAdd()
						.HasColumnType("int");

					SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

					b.Property<string>("Choice")
						.IsRequired()
						.HasMaxLength(128)
						.HasColumnType("nvarchar(128)");

					b.Property<int>("Index")
						.HasColumnType("int");

					b.Property<int?>("QuestionModelId")
						.HasColumnType("int");

					b.HasKey("Id");

					b.HasIndex("QuestionModelId");

					b.ToTable("ChoiceModel");
				});

			modelBuilder.Entity("InCompanyAPI.Context.Models.QuestionModel", b =>
				{
					b.Property<int>("Id")
						.ValueGeneratedOnAdd()
						.HasColumnType("int");

					SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

					b.Property<int>("Index")
						.HasColumnType("int");

					b.Property<string>("QuestionText")
						.IsRequired()
						.HasMaxLength(128)
						.HasColumnType("nvarchar(128)");

					b.Property<string>("QuestionType")
						.IsRequired()
						.HasMaxLength(32)
						.HasColumnType("nvarchar(32)");

					b.Property<bool>("Required")
						.HasColumnType("bit");

					b.Property<Guid?>("SurveyModelId")
						.HasColumnType("uniqueidentifier");

					b.HasKey("Id");

					b.HasIndex("Index");

					b.HasIndex("SurveyModelId");

					b.ToTable("QuestionModel");
				});

			modelBuilder.Entity("InCompanyAPI.Questions.Models.SurveyModel", b =>
				{
					b.Property<Guid>("Id")
						.ValueGeneratedOnAdd()
						.HasColumnType("uniqueidentifier");

					b.Property<bool>("Active")
						.HasColumnType("bit");

					b.Property<DateTime>("CreateDate")
						.HasColumnType("datetime2");

					b.Property<string>("Description")
						.HasMaxLength(512)
						.HasColumnType("nvarchar(512)");

					b.Property<string>("Owner")
						.IsRequired()
						.HasMaxLength(64)
						.HasColumnType("nvarchar(64)");

					b.Property<string>("Title")
						.IsRequired()
						.HasMaxLength(128)
						.HasColumnType("nvarchar(128)");

					b.HasKey("Id");

					b.ToTable("Survey");
				});

			modelBuilder.Entity("InCompanyAPI.Context.Models.ChoiceModel", b =>
				{
					b.HasOne("InCompanyAPI.Context.Models.QuestionModel", null)
						.WithMany("Choices")
						.HasForeignKey("QuestionModelId");
				});

			modelBuilder.Entity("InCompanyAPI.Context.Models.QuestionModel", b =>
				{
					b.HasOne("InCompanyAPI.Questions.Models.SurveyModel", null)
						.WithMany("Questions")
						.HasForeignKey("SurveyModelId");
				});

			modelBuilder.Entity("InCompanyAPI.Context.Models.QuestionModel", b =>
				{
					b.Navigation("Choices");
				});

			modelBuilder.Entity("InCompanyAPI.Questions.Models.SurveyModel", b =>
				{
					b.Navigation("Questions");
				});
#pragma warning restore 612, 618
		}
	}
}
