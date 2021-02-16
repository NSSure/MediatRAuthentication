using AttributeInjection.Attributes;
using AttributeInjection.Models;
using AttributeInjection.Queries;
using AttributeInjection.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AttributeInjection.Handlers
{
    public class GetRestrictedDataHandler : IRequestHandler<GetRestrictedDataQuery, RestrictedData>
    {
        private readonly RestrictedDataRepository _restrictedDataRepo;

        public GetRestrictedDataHandler(RestrictedDataRepository restrictedDataRepo)
        {
            this._restrictedDataRepo = restrictedDataRepo;
        }

        public async Task<RestrictedData> Handle(GetRestrictedDataQuery request, CancellationToken cancellationToken)
        {
            return await this._restrictedDataRepo.Get();
        }
    }
}
