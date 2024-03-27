namespace Workhorser
{
    public class WorkflowTask : IWorkflowTask
    {
        private readonly string _name;
        private readonly Func<Task>? _asyncAction;
        private readonly Action? _syncAction;

        public WorkflowTask(string name, Func<Task> action)
        {
            _name = name;
            _asyncAction = action;
        }

        public WorkflowTask(string name, Action action)
        {
            _name = name;
            _syncAction = action;
        }

        public async Task Execute()
        {
            Console.WriteLine($"Executing task: {_name}");

            if (_asyncAction != null)
            {
                await _asyncAction.Invoke(); // Execute asynchronous action if provided
            }
            else if (_syncAction != null)
            {
                _syncAction.Invoke(); // Execute synchronous action if provided
            }
        }
    }
}
