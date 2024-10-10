using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Products
{
    public class Article
    {
        public Article(string title , string text)
        {
            Id = Guid.NewGuid();
            Title = title;
            Text = text;

        }
        public Guid Id { get;private set; }
        public string Title { get;private set; }
        public string Text { get;private set; }
        public Guid ProductId { get; set; }
    }
}
