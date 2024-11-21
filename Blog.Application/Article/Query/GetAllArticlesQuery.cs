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
    public record GetAllArticlesQuery(  ):IRequest<ErrorOr<ArticleDto>>;
    public class GetAllArticlesQueryHandler : IRequestHandler<GetAllArticlesQuery, ErrorOr<ArticleDto>>
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;

        public GetAllArticlesQueryHandler(IArticleRepository articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<ArticleDto>> Handle(GetAllArticlesQuery request, CancellationToken cancellationToken)
        {
            var article = await _articleRepository.GetAllAsync( );
            if ( article != null ) { return Error.Failure(); }
            _mapper.Map<ArticleDto>( article ); 
            return _mapper.Map<ArticleDto>(article);
        }
    }



}
