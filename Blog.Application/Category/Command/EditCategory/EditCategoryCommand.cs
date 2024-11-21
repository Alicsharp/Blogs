using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Category.Command.EditCategory
{
    public record EditCategoryCommand(int Id, string CategoryName, int? parentCategoryId = 0) : IRequest<ErrorOr<Success>>;
}
