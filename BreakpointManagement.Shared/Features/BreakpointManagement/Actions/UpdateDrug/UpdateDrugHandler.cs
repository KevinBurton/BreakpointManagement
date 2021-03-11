using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using MediatR;

namespace BreakpointManagement.Shared.Features.BreakpointManagement
{
    public partial class BreakpointManagementState
    {
        public class UpdateDrugHandler : ActionHandler<UpdateDrugAction>
        {
            public UpdateDrugHandler(IStore aStore) : base(aStore) { }

            BreakpointManagementState BreakpointManagementState => Store.GetState<BreakpointManagementState>();

            public override Task<Unit> Handle(UpdateDrugAction aIncrementCountAction, CancellationToken aCancellationToken)
            {
                BreakpointManagementState.Drug = aIncrementCountAction.Drug;
                return Unit.Task;
            }
        }
    }
}
