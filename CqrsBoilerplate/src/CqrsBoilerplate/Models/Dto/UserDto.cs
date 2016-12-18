using System;

namespace CqrsBoilerplate.Models.Dto
{
    public class UserDto
    {
        public Guid PublicId { get; set; }

        public string Email { get; set; }

        public UserInfoDto UserInfo { get; set; }
    }
}
