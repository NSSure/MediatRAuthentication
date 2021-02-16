using AttributeInjection.Attributes;
using AttributeInjection.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AttributeInjection.Utilities
{
    public static class RestrictedUtility
    {
        [Restricted]
        public class FirstRestrictedClass : IRequestHandler<RestrictedData, bool>
        {
            public Task<bool> Handle(RestrictedData request, CancellationToken cancellationToken)
            {
                return Task.FromResult(true);
            }
        }

        [Restricted]
        public class SecondRestrictedClass
        {

        }
    }
}
