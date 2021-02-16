using AttributeInjection.Attributes;
using AttributeInjection.Models;
using AttributeInjection.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace AttributeInjection
{
    public class RestrictedBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public readonly IHttpContextAccessor _httpContextAccessor;

        public RestrictedBehavior(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            RestrictedAttribute _restrictedAttribute = request.GetType().GetCustomAttribute(typeof(RestrictedAttribute)) as RestrictedAttribute;

            if (_restrictedAttribute != null)
            {
                string _currentUserName = this._httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(a => a.Type == "name")?.Value;

                if (_currentUserName != "admin")
                {
                    throw new Exception("You are not allowed to view that resource.");
                }
            }

            var _response = await next();

            return _response;
        }
    }
}
