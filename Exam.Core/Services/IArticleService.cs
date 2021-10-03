using Exam.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Core.Services
{
    public interface IArticleService
    {
        Task<IEnumerable<Article>> GetAll();
        Task<Article> GetById(Guid id);
        Task<Article> Create(Article newArticle);
        Task Truncate();
    }
}
