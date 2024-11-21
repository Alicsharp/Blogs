using Blog.Application.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace Blog.Application.Category.Command.EditCategory
{
    public class EditCategoryCommandHandler : IRequestHandler<EditCategoryCommand, ErrorOr<Success>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public EditCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ErrorOr<Success>> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == null || request.CategoryName == null) { return Error.Failure("Name", " Is Null"); }
            var Category = await _categoryRepository.GetByIdAsync(request.Id);
            Category.Edit(request.CategoryName, request.parentCategoryId.Value);
            _categoryRepository.Save();
            return new ErrorOr<Success>();

        }
    }
}
