using Blog.Application.Common.Interfaces;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Article.Command.DeleteArticle
{
    public record DeleteAticleCommand(int Id):IRequest<ErrorOr<Success>>;
    public record DeleteAticleCommandHandler : IRequestHandler<DeleteAticleCommand, ErrorOr<Success>>
    {
        private readonly IArticleRepository _articleRepository;

        public DeleteAticleCommandHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<ErrorOr<Success>> Handle(DeleteAticleCommand request, CancellationToken cancellationToken)
        {
          var result= await _articleRepository.DeleteAsync(request.Id); if(result==false) { return Error.Failure(); }
            return new ErrorOr<Success>(); ;
        }
    }
}
