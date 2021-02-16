using AttributeInjection.Attributes;
using AttributeInjection.Models;
using MediatR;

namespace AttributeInjection.Queries
{
    [Restricted("admin")]
    public class GetRestrictedDataQuery : IRequest<RestrictedData>
    {

    }
}
