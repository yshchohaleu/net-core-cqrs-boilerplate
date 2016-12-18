using System.ComponentModel.DataAnnotations.Schema;

namespace CqrsBoilerplate.Entities.Users
{
    public class Membership : Entity
    {
        [Column("user_id")]
        public long UserId { get; set; }

        public User User { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("password_salt")]
        public string PasswordSalt { get; set; }
    }
}
