using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using MediatR;

namespace BreakpointManagement.Shared.Features.BreakpointManagement
{
    public partial class BreakpointManagementState
    {
        public class UpdateProjectHandler : ActionHandler<UpdateProjectAction>
        {
            public UpdateProjectHandler(IStore aStore) : base(aStore) { }

            BreakpointManagementState BreakpointManagementState => Store.GetState<BreakpointManagementState>();

            public override Task<Unit> Handle(UpdateProjectAction aIncrementCountAction, CancellationToken aCancellationToken)
            {
                BreakpointManagementState.Project = aIncrementCountAction.Project;
                return Unit.Task;
            }
        }
    }
}
