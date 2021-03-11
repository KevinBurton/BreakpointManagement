using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using MediatR;

namespace BreakpointManagement.Shared.Features.BreakpointManagement
{
    public partial class BreakpointManagementState
    {
        public class UpdateBreakpointSummaryHandler : ActionHandler<UpdateBreakpointSummaryAction>
        {
            public UpdateBreakpointSummaryHandler(IStore aStore) : base(aStore) { }

            BreakpointManagementState BreakpointManagementState => Store.GetState<BreakpointManagementState>();

            public override Task<Unit> Handle(UpdateBreakpointSummaryAction aIncrementCountAction, CancellationToken aCancellationToken)
            {
                BreakpointManagementState.Summary = aIncrementCountAction.Summary;
                return Unit.Task;
            }
        }
    }
}
