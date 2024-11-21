using Blog.Application.Common.Interfaces;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Article.Command.EditArticle
{
    public class EditArticleCommandHandler : IRequestHandler<EditArticleCommand, ErrorOr<Success>>
    {
        private readonly IArticleRepository _articleRepository;

        public EditArticleCommandHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<ErrorOr<Success>> Handle(EditArticleCommand request, CancellationToken cancellationToken)
        {
             var article=await _articleRepository.GetByIdAsync(request.Id);  
            if(article == null) { return Error.Failure(); }
            article.Edit(request.Title, request.Content,request.CategoryId);
            _articleRepository.Save();
            return new ErrorOr<Success>();
        }
    }
}
