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
	[Migration("20221215100619_change-id-to-PublicIdentifier-v1")]
	partial class changeidtoPublicIdentifierv1
	{
		/// <inheritdoc />
		protected override void BuildTargetModel(ModelBuilder modelBuilder)
		{
#pragma warning disable 612, 618
			modelBuilder
				.HasAnnotation("ProductVersion", "7.0.0")
				.HasAnnotation("Relational:MaxIdentifierLength", 128);

			SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

			modelBuilder.Entity("Api.Context.SurveyModels.EntityModel.ChoiceEntityModel", b =>
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

					b.Property<int>("QuestionId")
						.HasColumnType("int");

					b.HasKey("Id");

					b.HasIndex("Index");

					b.HasIndex("QuestionId");

					b.ToTable("Choice");
				});

			modelBuilder.Entity("Api.Context.SurveyModels.EntityModel.QuestionEntityModel", b =>
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

					b.Property<int>("QuestionType")
						.HasColumnType("int");

					b.Property<bool>("Required")
						.HasColumnType("bit");

					b.Property<int>("SurveyId")
						.HasColumnType("int");

					b.HasKey("Id");

					b.HasIndex("Index");

					b.HasIndex("SurveyId");

					b.ToTable("Question");
				});

			modelBuilder.Entity("Api.Context.SurveyModels.EntityModel.SurveyEntityModel", b =>
				{
					b.Property<int>("Id")
						.ValueGeneratedOnAdd()
						.HasColumnType("int");

					SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

					b.Property<Guid>("PublicIdentifier")
						.HasColumnType("uniqueidentifier");

					b.Property<string>("Title")
						.IsRequired()
						.HasMaxLength(128)
						.HasColumnType("nvarchar(128)");

					b.HasKey("Id");

					b.HasIndex("CreateDate");

					b.ToTable("Survey");
				});

			modelBuilder.Entity("Api.Context.SurveyModels.EntityModel.ChoiceEntityModel", b =>
				{
					b.HasOne("Api.Context.SurveyModels.EntityModel.QuestionEntityModel", "Question")
						.WithMany("Choices")
						.HasForeignKey("QuestionId")
						.OnDelete(DeleteBehavior.Cascade)
						.IsRequired();

					b.Navigation("Question");
				});

			modelBuilder.Entity("Api.Context.SurveyModels.EntityModel.QuestionEntityModel", b =>
				{
					b.HasOne("Api.Context.SurveyModels.EntityModel.SurveyEntityModel", "Survey")
						.WithMany("Questions")
						.HasForeignKey("SurveyId")
						.OnDelete(DeleteBehavior.Cascade)
						.IsRequired();

					b.Navigation("Survey");
				});

			modelBuilder.Entity("Api.Context.SurveyModels.EntityModel.QuestionEntityModel", b =>
				{
					b.Navigation("Choices");
				});

			modelBuilder.Entity("Api.Context.SurveyModels.EntityModel.SurveyEntityModel", b =>
				{
					b.Navigation("Questions");
				});
#pragma warning restore 612, 618
		}
	}
}
