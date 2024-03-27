
namespace Workhorser
{
    public class WorkflowBuilder
    {
        public static async Task ExecuteWorkflowAsync(List<IWorkflowTask> tasks)
        {
            foreach (IWorkflowTask task in tasks)
            {
                await task.Execute();
            }
        }
    }
}
