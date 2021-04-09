using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Weathered.Data.Models;
using Weathered.Data.Models.Core;
using Weathered.MediatR.Queries;

namespace Weathered.MediatR.Handlers
{
    public class TestHandler : IRequestHandler<Test, Device>
    {
        public Task<Device> Handle(Test request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}