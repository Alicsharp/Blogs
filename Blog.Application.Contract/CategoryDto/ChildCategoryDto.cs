namespace Blog.Application.Contract.CategoryDto
{
    public class ChildCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
        public string ParentCategoryName { get; set; }
        public List<ChildCategoryDto> Childs { get; set; } = new List<ChildCategoryDto>();
    }
}
