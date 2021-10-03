using Exam.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Data.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.OptionA).IsRequired();
            builder.Property(x => x.OptionB).IsRequired();
            builder.Property(x => x.OptionC).IsRequired();
            builder.Property(x => x.OptionD).IsRequired();
            builder.Property(x => x.CorrectAnswer).IsRequired();

            builder.HasOne(x => x.Quiz).WithMany(y => y.Questions).HasForeignKey(x => x.QuizId);
        }
    }
}
