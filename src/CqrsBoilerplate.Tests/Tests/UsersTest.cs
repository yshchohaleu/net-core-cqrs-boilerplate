using System;
using System.Linq;
using CqrsBoilerplate.Models.Filters;
using Xunit;
using CqrsBoilerplate.Models.Queries;
using FluentAssertions;

namespace CqrsBoilerplate.Tests.Tests
{
    public class UsersTest : BaseTest
    {
        public UsersTest()
        {
            
        }

        [Fact]
        public async void Get_users_all()
        {
            var query =  new UsersQuery(new UsersFilter
            {
                CurrentPage = 1,
                PageSize = int.MaxValue
            });

            var users = await Mediator.SendAsync(query);
            users.Should().NotBeNull();
            users.Items.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async void Get_users_paged()
        {
            var query = new UsersQuery(new UsersFilter
            {
                CurrentPage = 1,
                PageSize = 1
            });

            var users = await Mediator.SendAsync(query);
            users.Should().NotBeNull();
            users.Items.Should().NotBeNullOrEmpty()
                .And.HaveCount(1);
        }

        [Fact]
        public async void Get_users_filtered_by_email()
        {
            var query = new UsersQuery(new UsersFilter
            {
                CurrentPage = 1,
                PageSize = int.MaxValue,
                Email = "admin@boilerplate.com"
            });

            var users = await Mediator.SendAsync(query);
            users.Should().NotBeNull();
            users.Items.Should().NotBeNullOrEmpty()
                .And.HaveCount(1);

            var user = users.Items.SingleOrDefault();
            user.Should().NotBeNull();
            user.Email.Should().BeEquivalentTo("admin@boilerplate.com");
        }

        [Fact]
        public async void Get_users_filtered_by_id()
        {
            var query = new UsersQuery(new UsersFilter
            {
                CurrentPage = 1,
                PageSize = int.MaxValue,
                PublicId = Guid.Parse("CDD301D8-F821-48E1-9A13-DAA5B506D322")
            });

            var users = await Mediator.SendAsync(query);
            users.Should().NotBeNull();
            users.Items.Should().NotBeNullOrEmpty()
                .And.HaveCount(1);

            var user = users.Items.SingleOrDefault();
            user.Should().NotBeNull();
            user.Email.Should().BeEquivalentTo("admin@boilerplate.com");
        }
    }
}
