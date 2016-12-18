using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CqrsBoilerplate.Entities.Users
{
    public class User : Entity
    {
        public User()
        {
            
        }

        [Column("id")]
        public long Id { get; set; }

        [Column("public_id")]
        public Guid PublicId { get; set; }

        [Column("email")]
        public string Email { get; set; }

        public UserInfo UserInfo { get; set; }

        public Membership Membership { get; set; }
    }
}
