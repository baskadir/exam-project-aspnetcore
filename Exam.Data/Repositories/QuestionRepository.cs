using Exam.Core.Entities;
using Exam.Core.Repositories;
using Exam.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Data.Repositories
{
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(ExamDbContext context):base(context)
        {

        }
    }
}
