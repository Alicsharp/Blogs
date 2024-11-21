using AutoMapper;
using Blog.Application.Contract.Article;
using Blog.Application.Contract.CategoryDto;
using Blog.Application.Users.Queries.UserTokens;
using Blog.Domain.Entities;

namespace Blog.Application.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Domain.Entities. Category, CategoryDto>().ReverseMap();
            CreateMap<Domain.Entities. Category, ChildCategoryDto>().ReverseMap();
            CreateMap<Domain.Entities.Article, ArticleDto>().ReverseMap(); 
            CreateMap<Domain.Entities.User, UserLoginDto>().ForMember(d=>d.Password ,opt=>opt.MapFrom(src=>src.PasswordHash)).ReverseMap();
        }
    }
}
