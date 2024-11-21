namespace Blog.Application.Users.Queries.UserTokens
{
    public class UserTokenDto  
    {
        public int Id { get; set; }     
        public int UserId { get; set; }
        public string HashJwtToken { get; set; }
        public string HashRefreshToken { get; set; }
        public DateTime TokenExpireDate { get; set; }
        public DateTime RefreshTokenExpireDate { get; set; }
         
    }
}
