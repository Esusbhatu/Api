using Data_Access_Layer.Context.SurveyModels.EntityModel;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer.Context
{
	public class DBContext : DbContext
	{
		public DbSet<SurveyEntityModel> Survey { get; set; }
		public DbSet<QuestionEntityModel> Question { get; set; }
		public DbSet<ChoiceEntityModel> Choice { get; set; }
        public DbSet<AnswerEntityModel> Answer { get; set; }

        public DBContext()
		{

		}

		public DBContext(DbContextOptions options) : base(options)
		{

		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=InCompanyApiDb;Integrated Security=True");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder
				.Entity<SurveyEntityModel>()
				.HasMany(q => q.Questions)
				.WithOne(s => s.Survey)
				.HasForeignKey(q => q.SurveyId);

			modelBuilder
				.Entity<QuestionEntityModel>()
				.HasMany(c => c.Choices)
				.WithOne(q => q.Question)
				.HasForeignKey(qi => qi.QuestionId);

            modelBuilder
           .Entity<QuestionEntityModel>()
           .HasMany(c => c.Answers)
           .WithOne(q => q.Question)
           .HasForeignKey(qi => qi.QuestionId);

        }
	}
}
