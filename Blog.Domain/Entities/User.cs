using System.Text.RegularExpressions;

namespace Blog.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public List<UserToken> Tokens { get; }
        public ICollection<Article> Articles { get; private set; } = new List<Article>();
        // Constructor
        public User(string username, string email, string passwordHash)
        {
            SetUsername(username);
            SetEmail(email);
            SetPasswordHash(passwordHash);
        }

        // Business Rules
        public void SetUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username cannot be empty.");
            Username = username;
        }
        public void Edit(string username)
        {
            if(username ==null ) throw new ArgumentNullException("userName or email is Null");
            Username = username;
            

        }
        public void SetEmail(string email)
        {
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("Invalid email format.");
            Email = email;
        }

        public void SetPasswordHash(string passwordHash)
        {
            if (passwordHash.Length < 8)
                throw new ArgumentException("Password must be at least 8 characters long.");
            PasswordHash = passwordHash;
        }
        public void ChangePassword(string newPassword)
        {
            PasswordHash = newPassword;
        }
        public void AddToken(string hashJwtToken, string hashRefreshToken, DateTime tokenExpireDate, DateTime refreshTokenExpireDate, string device)
        {
            var activeTokenCount = Tokens.Count(c => c.RefreshTokenExpireDate > DateTime.Now);
            if (activeTokenCount == 3)
                throw new Exception("امکان استفاده از 4 دستگاه همزمان وجود ندارد");

            var token = new UserToken(hashJwtToken, hashRefreshToken, tokenExpireDate, refreshTokenExpireDate, device);
            token.UserId = Id;
            Tokens.Add(token);
        }
        public void RemoveToken(long tokenId)
        {
            var token = Tokens.FirstOrDefault(f => f.Id == tokenId);
            if (token == null)
                throw new Exception("invalid TokenId");

            Tokens.Remove(token);
        }
    }
}
 