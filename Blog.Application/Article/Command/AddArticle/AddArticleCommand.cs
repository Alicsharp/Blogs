using Blog.Application.Contract.Article;
using Blog.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Article.Command.AddArticle
{
    public record AddArticleCommand(string Title, string Content, int CategoryId) : IRequest<ErrorOr<Success>>;

}
