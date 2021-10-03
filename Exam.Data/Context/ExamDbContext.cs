using Exam.Core.Entities;
using Exam.Data.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Data.Context
{
    public class ExamDbContext:IdentityDbContext
    {
        public ExamDbContext(DbContextOptions<ExamDbContext> options):base(options)
        {

        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ArticleConfiguration());
            builder.ApplyConfiguration(new QuizConfiguration());
            builder.ApplyConfiguration(new QuestionConfiguration());

            AppUser appUser = new AppUser();
            var hasher = new PasswordHasher<AppUser>();
            appUser.PasswordHash = hasher.HashPassword(appUser, "1");
            appUser.UserName = "baskadir";
            builder.Entity<AppUser>().HasData(appUser);

            base.OnModelCreating(builder);
        }
    }
}
