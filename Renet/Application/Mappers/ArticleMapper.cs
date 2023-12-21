using Application.Dtos;
using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public static class ArticleMapper
    {
        public static ArticleDto ToDto(this Article article)
        {
            var dto  = new ArticleDto()
            {
                Id = article.Id,
                Text = article.Text,
                Title = article.Title,
            };
            return dto;
        }
    }
}
