using System.Threading;
using CqrsBoilerplate.Models.Commands;
using CqrsBoilerplate.Models.Dto;
using Xunit;
using FluentAssertions;

namespace CqrsBoilerplate.Tests.Tests
{
    public class UserTest : BaseTest
    {
        [Fact]
        public async void Create_user()
        {
            var userCreateCommand = new UserCreateCommand(new UserCreateDto
            {
                Email = "test@boilerplate.com",
                UserInfo = new UserInfoCreateDto
                {
                    Address = "test address",
                    FirstName = "test first name",
                    LastName = "test last name"
                }
            });

            var user = await Mediator.SendAsync(userCreateCommand, CancellationToken.None);
            user.Should().NotBeNull();
            user.Email.Should().BeEquivalentTo("test@boilerplate.com");
            user.UserInfo.Should().NotBeNull();
            user.UserInfo.Address.ShouldAllBeEquivalentTo("test address");
            user.UserInfo.FirstName.ShouldAllBeEquivalentTo("test first name");
            user.UserInfo.LastName.ShouldAllBeEquivalentTo("test last name");
        }
    }
}
