using CqrsBoilerplate.Models.Filters;
using Xunit;
using CqrsBoilerplate.Models.Queries;

namespace CqrsBoilerplate.Tests.Tests
{
    public class UsersTest : BaseTest
    {
        public UsersTest()
        {
            
        }

        [Fact]
        public async void Get_users()
        {
            var query =  new UsersQuery(new UsersFilter
            {
                CurrentPage = 1,
                PageSize = 100
            });

            var users = await Mediator.SendAsync(query);
        }
    }
}
