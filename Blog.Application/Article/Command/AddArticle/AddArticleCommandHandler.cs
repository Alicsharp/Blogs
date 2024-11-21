using AutoMapper;
using Blog.Application.Common.Interfaces;
using Blog.Application.Contract.Article;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Blog.Application.Article.Command.AddArticle
{
    public class AddArticleCommandHandler : IRequestHandler<AddArticleCommand, ErrorOr<Success>>
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AddArticleCommandHandler(IArticleRepository articleRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ErrorOr<Success>> Handle(AddArticleCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                return Error.Failure("Name", "Request is null");

            // گرفتن UserId از توکن JWT
            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst("UserId");
            if (userIdClaim == null)
                return Error.Failure("Authorization", "User not authenticated");

            if (!int.TryParse(userIdClaim.Value, out var userId))
                return Error.Failure("Authorization", "Invalid UserId");

            // ایجاد مقاله جدید
            var newArticle = new Domain.Entities.Article(request.Title, request.Content, userId, request.CategoryId);

            await _articleRepository.AddAsync(newArticle);
              _articleRepository.Save();

            _mapper.Map<ArticleDto>(newArticle);

            return new ErrorOr<Success>();
        }
    }

}
