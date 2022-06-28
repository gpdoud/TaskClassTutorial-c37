public static class AsyncQueue {

    public static System.Collections.Concurrent.ConcurrentQueue<int> queue = new();
    private static Random rnd = new();

    public static void AddToQueue() {
        while (true) {
            var count = rnd.Next(1, 11); // 1 - 10
            for (var i = 0; i < count; i++) {
                var item = rnd.Next(1, 11); // 1 - 10
                queue.Enqueue(item);
            }
            Thread.Sleep(1000);
        }
    }

    public static void RemoveFromQueue() {
        int item;
        var sleep = 2000;
        while (true) {
            var count = rnd.Next(1, 6); // 1 - 5
            System.Console.Write($"Queue({queue.Count}),Sum({count}): ");
            var sum = 0;
            for (var i = 0; i < count; i++) {
                if(queue.TryDequeue(out item)) {
                    System.Console.Write($"{item} ");
                    sum += item;
                }
            }
            Console.Write($" = {sum} ");
            Thread.Sleep(sleep);
            if(queue.Count > 70 && sleep != 250) {
                sleep = 250;
                Console.Write($"\nSleep({sleep}) ");
            }
            if(queue.Count < 20 && sleep != 2000) {
                sleep = 2000;
                Console.Write($"\nSleep({sleep}) ");
            }
            System.Console.WriteLine();
        }
    }

    public static void Run() {
        var waittime = 30000;
        Task tadd = Task.Run(AddToQueue);
        Thread.Sleep(3000);
        Task tremove = Task.Run(RemoveFromQueue);
        tadd.Wait(waittime);
        tremove.Wait(waittime);
        System.Console.WriteLine("\nDone...");
    }

}