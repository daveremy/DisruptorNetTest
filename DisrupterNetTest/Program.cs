using System;

// From: http://www.thomasvestergaard.com/thomas-vestergaard-blog/frameworks-and-libraries/high-performance-message-processing-with-disruptornet/
namespace DisrupterNetTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue();
            queue.Start();

            var qItem = new QueueItem { IntValue = 10 };
            int counter = 1;
            while (true)
            {
                qItem.IntValue = counter;
                queue.Enqueue(qItem);
                Console.ReadKey();
                counter++;
            }

            queue.Stop();
        }
    }
}
