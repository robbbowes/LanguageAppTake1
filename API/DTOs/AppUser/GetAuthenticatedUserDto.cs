namespace API.DTOs.AppUser
{
    public class GetAuthenticatedUserDto
    {
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}