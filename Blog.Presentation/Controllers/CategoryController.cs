using Blog.Application.Category.Command.AddCategory;
using Blog.Application.Category.Command.AddChildCategory;
using Blog.Application.Category.Command.EditCategory;
using Blog.Application.Category.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
  
         private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            // ارسال درخواست به مدیتار
            var result = await _mediator.Send(new GetAllCategoryQuery());

            // بررسی نتیجه
            return result.Match(
                categories => Ok(categories),                // در صورت موفقیت
                error => Problem(title: "Error", detail: error.ToString()) // در صورت خطا
            );
        }
        [HttpGet("Id")]
        public async Task<IActionResult> GetById(int Id)
        {
            var result= await _mediator.Send(new GetCategoryByIdQuery(Id));
               return result.Match(
                    category => Ok(category),                 // در صورت موفقیت
            error => Problem(title: "Error", detail: error.ToString()) // در صورت خطا
             );
        }
        [Authorize]
        [HttpPost("Create")]
        public async Task<IActionResult> Create(   string name, int? ParentCategoryId) // CategoryDto cate
        {
            var result = await _mediator.Send(new AddCategoryCommand(name,ParentCategoryId )); // cate.name , cate.ParentCategory

            return result.Match(
                success => Ok("Category created successfully."),
                error => Problem(title: "Error", detail: error.ToString())
            );
        }
        [HttpPost("AddChildCategory")]
        public async Task<IActionResult> AddChild(string name, int ParentCategoryId) // CategoryDto cate
        {
            var result = await _mediator.Send(new AddChildCategoryCommand(name, ParentCategoryId)); // cate.name , cate.ParentCategory

            return result.Match(
                success => Ok("Category created successfully."),
                error => Problem(title: "Error", detail: error.ToString())
            );
        }
        [HttpPost("EditCategory")]
        public async Task<IActionResult> EditCategory(int Id, string name, int ParentCategoryId) // CategoryDto cate
        {
            var result = await _mediator.Send(new EditCategoryCommand(Id,name,ParentCategoryId)); // cate.name , cate.ParentCategory

            return result.Match(
                success => Ok("Category created successfully."),
                error => Problem(title: "Error", detail: error.ToString())
            );
        }
    }

    
}
