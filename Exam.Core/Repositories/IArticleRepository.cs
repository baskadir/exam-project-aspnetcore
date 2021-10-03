using Exam.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Core.Repositories
{
    public interface IArticleRepository:IGenericRepository<Article>
    {
        void RemoveRange(IEnumerable<Article> articles);
        Task<Article> Get(Guid id);
    }
}
