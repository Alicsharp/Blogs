using AutoMapper;
using Blog.Application.Common.Interfaces;
using Blog.Application.Contract.CategoryDto;
using ErrorOr;
using MediatR;

namespace Blog.Application.Category.Query
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, ErrorOr<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<CategoryDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {

            var category = await _categoryRepository.GetTracking(request.Id);
             

            return _mapper.Map<CategoryDto>(category);
        }
    }
}
