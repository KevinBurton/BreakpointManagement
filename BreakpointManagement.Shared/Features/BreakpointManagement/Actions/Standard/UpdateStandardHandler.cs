using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using MediatR;

namespace BreakpointManagement.Shared.Features.BreakpointManagement
{
    public partial class BreakpointManagementState
    {
        public class UpdateStandardHandler : ActionHandler<UpdateStandardAction>
        {
            public UpdateStandardHandler(IStore aStore) : base(aStore) { }

            BreakpointManagementState BreakpointManagementState => Store.GetState<BreakpointManagementState>();

            public override Task<Unit> Handle(UpdateStandardAction aIncrementCountAction, CancellationToken aCancellationToken)
            {
                BreakpointManagementState.Standard = aIncrementCountAction.Standard;
                return Unit.Task;
            }
        }
    }
}
