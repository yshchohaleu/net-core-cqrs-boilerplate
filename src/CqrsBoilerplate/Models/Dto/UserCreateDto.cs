namespace CqrsBoilerplate.Models.Dto
{
    public class UserCreateDto
    {
        public string Email { get; set; }

        public UserInfoCreateDto UserInfo { get; set; }
    }
}
