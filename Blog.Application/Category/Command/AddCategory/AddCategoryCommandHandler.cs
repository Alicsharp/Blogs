using Blog.Application.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace Blog.Application.Category.Command.AddCategory
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, ErrorOr<Success>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public AddCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ErrorOr<Success>> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            // بررسی صحت داده‌ها
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return Error.Failure("Name", "Name cannot be null or empty.");
            }

            // ایجاد دسته‌بندی جدید
            var newCategory = new Domain.Entities.Category(request.Name, request.ParentCategoryId);

            // افزودن دسته‌بندی
            await _categoryRepository.AddAsync(newCategory);
            _categoryRepository.Save(); // اطمینان از ذخیره تغییرات

            // بازگرداندن موفقیت
            return new ErrorOr<Success>();
        }
    }
}

