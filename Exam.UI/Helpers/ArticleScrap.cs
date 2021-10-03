using Exam.Core.Entities;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Exam.UI.Helpers
{
    public class ArticleScrap
    {
        public async static Task<IEnumerable<Article>> GetArticlesAsync(string url)
        {
            var response = await CallUrl(url);

            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(response);

            var nodes = htmlDocument.DocumentNode.Descendants("ul").Where(x => x.GetAttributeValue("class", "") == "post-listing-component__list").ToList();
            var postNodes = nodes[1].Descendants("li").Where(x => x.GetAttributeValue("class", "") == "post-listing-list-item__post").ToList();

            List<Article> articleList = new List<Article>();
            Article article = null;
            foreach (var item in postNodes)
            {
                article = new Article();
                article.Id = Guid.NewGuid();
                var postUrl = url + item.Descendants("a").FirstOrDefault().GetAttributeValue("href", "");
                var description = await GetDescription(postUrl);
                article.Description = description;
                article.Title = item.Descendants("h5").Where(x => x.GetAttributeValue("class", "") == "post-listing-list-item__title").FirstOrDefault().InnerText;
                if (description != null)
                    articleList.Add(article);
            }
            return articleList;
        }

        private static async Task<string> CallUrl(string url)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(url);
            return response;
        }

        private static async Task<string> GetDescription(string postUrl)
        {
            HttpClient client = new HttpClient();
            string html = await client.GetStringAsync(postUrl);

            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(html);
            string description = string.Empty;
            try
            {
                var nodes = document.DocumentNode.Descendants("div").Where(x => x.GetAttributeValue("class", "") == "grid--item body body__container article__body grid-layout__content").ToList();
                var descriptionList = nodes[0].Descendants("p").ToList();
                foreach (var item in descriptionList)
                {
                    description += item.InnerText;
                }
                return description;
            }
            catch
            {
                return null;
            }
        }
    }
}
