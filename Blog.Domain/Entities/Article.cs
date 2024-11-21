namespace Blog.Domain.Entities
{
    public class Article
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public int UserId { get; private set; }
        public User User { get; private set; }
        public int CategoryId { get; private set; }
        public Category Category { get; private set; }

        // Constructor
        public Article(string title, string content,int userId, int categoryId)
        {
            SetTitle(title);
            SetContent(content);
            UserId=userId;
            CategoryId = categoryId;

        }
        public void Edit(string title, string content, int categoryId)
        {
            SetTitle(title);
            SetContent(content);
            CategoryId = categoryId;
        }
        // Business Rules
        public void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be empty.");
            Title = title;
        }

        public void SetContent(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Content cannot be empty.");
            Content = content;
        }
    }
}
 