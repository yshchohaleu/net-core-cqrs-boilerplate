using System.Net.Http;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace CqrsBoilerplate.Tests.Tests
{
    public abstract class BaseTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        private readonly IMediator _mediator;

        protected BaseTest()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
            _mediator = TestContext.Current.ServiceProvider.GetService<IMediator>();
        }

        protected TestServer Server => _server;
        protected HttpClient Client => _client;
        protected IMediator Mediator => _mediator;
    }
}
