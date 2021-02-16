using AttributeInjection.Models;
using System.Threading.Tasks;

namespace AttributeInjection.Repositories
{
    public class RestrictedDataRepository
    {
        public async Task<RestrictedData> Get()
        {
            await Task.Delay(50);

            return new RestrictedData()
            {
                Message = "If you see this you see this."
            };
        }
    }
}
