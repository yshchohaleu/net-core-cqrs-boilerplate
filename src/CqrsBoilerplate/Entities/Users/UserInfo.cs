using System.ComponentModel.DataAnnotations.Schema;

namespace CqrsBoilerplate.Entities.Users
{
    public class UserInfo : Entity
    {
        [Column("user_id")]
        public long UserId { get; set; }

        public User User { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("address")]
        public string Address { get; set; }
    }
}
