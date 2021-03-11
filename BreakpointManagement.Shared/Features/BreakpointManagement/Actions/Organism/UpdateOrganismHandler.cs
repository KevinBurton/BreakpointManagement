using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using MediatR;

namespace BreakpointManagement.Shared.Features.BreakpointManagement
{
    public partial class BreakpointManagementState
    {
        public class UpdateOrganismHandler : ActionHandler<UpdateOrganismAction>
        {
            public UpdateOrganismHandler(IStore aStore) : base(aStore) { }

            BreakpointManagementState BreakpointManagementState => Store.GetState<BreakpointManagementState>();

            public override Task<Unit> Handle(UpdateOrganismAction aIncrementCountAction, CancellationToken aCancellationToken)
            {
                BreakpointManagementState.Organism = aIncrementCountAction.Organism;
                return Unit.Task;
            }
        }
    }
}
