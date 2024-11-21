using Blog.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Category.Command.AddCategory
{
    public record AddCategoryCommand(string Name, int? ParentCategoryId = 0) : IRequest<ErrorOr<Success>>;

}
