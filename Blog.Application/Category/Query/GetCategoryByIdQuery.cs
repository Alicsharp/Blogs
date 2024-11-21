using Blog.Application.Contract.CategoryDto;
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
    public record GetCategoryByIdQuery(int Id):IRequest<ErrorOr<CategoryDto>>;
}
