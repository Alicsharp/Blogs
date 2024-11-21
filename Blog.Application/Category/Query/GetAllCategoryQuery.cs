using AutoMapper;
using Blog.Application.Common.Interfaces;
using Blog.Application.Contract.CategoryDto;
using Blog.Application.Mapper;
using Blog.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Category.Query
{
    public class GetAllCategoryQuery : IRequest<ErrorOr<List<CategoryDto>>>;

    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, ErrorOr<List<CategoryDto>>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;   
        public GetAllCategoryQueryHandler(ICategoryRepository categoryRepository,IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<List<CategoryDto>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllAsync();
            var result =   _mapper.Map<List<CategoryDto>>(categories);
            return result;
            
        }
    }
}
