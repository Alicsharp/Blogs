using AutoMapper;
using Blog.Application.Article.Command.AddArticle;
using Blog.Application.Article.Command.DeleteArticle;
using Blog.Application.Article.Command.EditArticle;
using Blog.Application.Article.Query;
using Blog.Application.Category.Command.AddCategory;
using Blog.Application.Category.Query;
using Blog.Application.Common.Interfaces;
using Blog.Application.Contract.Article;
using Blog.Application.Contract.CategoryDto;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticleController : Controller
    {

        private readonly IMediator _mediator;

        public ArticleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllAtricles()
        {
            var Artcile = await _mediator.Send(new GetAllArticlesQuery());
            return Artcile.Match(
               Artcile => Ok(Artcile),                 
               error => Problem(title: "Error", detail: error.ToString())  
           );
        }
        [HttpGet("Id")]
        public async Task<IActionResult> GetById(int Id)
        {
            var result = await _mediator.Send(new GetArticleByIdQuery(Id));
            return result.Match(
                 articleDto => Ok(articleDto),                 
         error => Problem(title: "Error", detail: error.ToString())  
          );
        }

        [Authorize]
        [HttpPost("Create")]
        public async Task<IActionResult> Create(string Title,string Content,int CategoryId)  
        {
            var result = await _mediator.Send(new AddArticleCommand(Title,Content,CategoryId));  

            return result.Match(
                success => Ok("Category created successfully."),
                error => Problem(title: "Error", detail: error.ToString())
            );
        }
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(int Id,string Title, string Content, int CategoryId)  
        {
            var result = await _mediator.Send(new EditArticleCommand(Id,Title, Content, CategoryId));  

            return result.Match(
                success => Ok("Edit Article Is successfully"),
                error => Problem(title: "Error", detail: error.ToString())
            );
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _mediator.Send(new DeleteAticleCommand(Id));

            return result.Match(
                success => Ok("Delete Article Is successfully"),
                error => Problem(title: "Error", detail: error.ToString())
            );
        }
    }


}
