using Microsoft.AspNetCore.Http;

namespace AttributeInjection
{
    public class HttpContextFactory
    {
        public HttpContextFactory(IHttpContextAccessor httpContextAccessor)
        {

        }

        public void Create()
        {

        }
    }
}
