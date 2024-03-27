namespace Workhorser.TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome, to Workhorse.Test.Console!");

            List<IWorkflowTask> tasks = new List<IWorkflowTask>
            {
                new WorkflowTask("(Async) ProcessPayment", Ecom.ProcessPaymentAsync),
                new WorkflowTask("ProcessPayment", Ecom.ProcessPayment),
                new WorkflowTask("UpdateInventory", Ecom.UpdateInventory),
                new WorkflowTask("GenerateShippingLabel", Ecom.GenerateShippingLabel),
                new WorkflowTask("SendConfirmationEmail", Ecom.SendConfirmationEmail)
            };

            // Execute the workflow
            Task.Run(async () =>
            {
                await WorkflowBuilder.ExecuteWorkflowAsync(tasks);
            }).GetAwaiter().GetResult();
        }
    }
}
