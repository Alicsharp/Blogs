using Blog.Application.Common.Interfaces;
using Blog.Application.Contract.CategoryDto;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Category.Command.AddChildCategory
{
    public  record AddChildCategoryCommand(string categoryName ,int ParentCategoryId):IRequest<ErrorOr<Success>>;
     public record AddChildCategoryCommandHandler : IRequestHandler<AddChildCategoryCommand, ErrorOr<Success>>
      {
        private readonly ICategoryRepository _categoryRepository;

        public AddChildCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ErrorOr<Success>> Handle(AddChildCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetTracking(request.ParentCategoryId);
            if (category == null) { return Error.Failure(); }
            category.AddChildCategory(request.categoryName, request.ParentCategoryId);
            _categoryRepository.Save();
            return new ErrorOr<Success>();
         }
      }
}
