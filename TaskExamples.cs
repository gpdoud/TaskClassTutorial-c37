using System.Threading.Tasks;

public static class TaskExamples {

    public static void Run() {

        // create and start am async task immediately
        Task t1 = Task.Run(() => { Thread.Sleep(5000); Console.WriteLine("Task1"); });

        // create an async task but wait to start it
        Task t2 = new Task(() => { Thread.Sleep(3000); Console.WriteLine("Task2"); });
        t2.Start();

        // create a task and run it synchronously
        Task t3 = new Task(() => { Thread.Sleep(1000); Console.WriteLine("Task3 synchronously!"); });
        t3.RunSynchronously();

        // wait for all the task to finish before continuing the program
        Task.WaitAll(t1, t2, t3);

        // create tasks that runs for 3 and 5 seconds but waits only 4 seconds
        // one task will complete but the other will not in the time allowed
        Task t4 = Task.Run(() => { Thread.Sleep(5000); Console.WriteLine("Task4"); });
        Task t5 = Task.Run(() => { Thread.Sleep(3000); Console.WriteLine("Task5"); });
        t4.Wait(4000);
        t5.Wait(4000);
        bool t4done = t4.IsCompleted;
        bool t5done = t5.IsCompleted;
        System.Console.WriteLine($"Task4 {(t4done ? "did" : "did not")} complete.");
        System.Console.WriteLine($"Task5 {(t5done ? "did" : "did not")} complete.");

    }
}