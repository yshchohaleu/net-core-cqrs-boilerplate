using System;

namespace CqrsBoilerplate.Models.Filters
{
    public class UsersFilter : BaseFilter<UserDataScope>
    {
        public Guid? PublicId { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public class UserSorting
        {
            public const string Id = "Id";
            public const string FirstName = "FirstName";
            public const string LastName = "LastName";
            public const string Email = "Email";
        }
    }

    [Flags]
    public enum UserDataScope
    {
        BaseInfo = 0,
        Membership = 1 << 0,
        UserInfo = 1 << 1,
        All = BaseInfo | Membership | UserInfo
    }
}
