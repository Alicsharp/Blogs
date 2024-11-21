using AutoMapper;
using Blog.Application.Common.Interfaces;
using Blog.Application.Contract.Article;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Article.Query
{
    public record GetArticleByIdQuery(int Id):IRequest<ErrorOr<ArticleDto>>;
    public class GetArticleByIdQueryHandler : IRequestHandler<GetArticleByIdQuery, ErrorOr<ArticleDto>>
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;
        public GetArticleByIdQueryHandler(IArticleRepository articleRepository, IMapper mapper)  
        {
            _articleRepository = articleRepository;
            _mapper = mapper;

        }

        public async Task<ErrorOr<ArticleDto>> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
        {
            var article = await _articleRepository.GetByIdAsync(request.Id);
            if (article == null) { return Error.Failure(); }
           return _mapper.Map<ArticleDto>(article);

        }
    }

}
