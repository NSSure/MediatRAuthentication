using MediatR;

namespace AttributeInjection.Models
{
    public class RestrictedData : IRequest<bool>
    {
        public string Message { get; set; }
    }
}
