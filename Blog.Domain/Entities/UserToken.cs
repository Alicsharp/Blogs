namespace Blog.Domain.Entities
{
    public class UserToken 
    {
        private UserToken()
        {

        }


        public UserToken(string hashJwtToken, string hashRefreshToken, DateTime tokenExpireDate, DateTime refreshTokenExpireDate, string device)
        {
            
            HashJwtToken = hashJwtToken;
            HashRefreshToken = hashRefreshToken;
            TokenExpireDate = tokenExpireDate;
            RefreshTokenExpireDate = refreshTokenExpireDate;
            Device = device;
        }
        public int Id {  get; private set; }
        public int UserId { get; internal set; }
        public string HashJwtToken { get; private set; }
        public string HashRefreshToken { get; private set; }
        public DateTime TokenExpireDate { get; private set; }
        public DateTime RefreshTokenExpireDate { get; private set; }
        public string Device { get; private set; }


       
    }
}
 