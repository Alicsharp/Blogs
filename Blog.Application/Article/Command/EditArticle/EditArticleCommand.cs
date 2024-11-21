using ErrorOr;
using MediatR;

namespace Blog.Application.Article.Command.EditArticle
{
    public record EditArticleCommand(int Id,string Title,string Content,int CategoryId):IRequest<ErrorOr<Success>>;
}
