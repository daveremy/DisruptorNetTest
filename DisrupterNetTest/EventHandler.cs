using Disruptor;
using System.Threading;

namespace DisrupterNetTest
{
    public class EventHandler : IEventHandler<QueueItem>
    {
        public void OnNext(QueueItem data, long sequence, bool endOfBatch)
        {
            System.Console.WriteLine("Received seqno: {0} on thread id {1}.  Int: {2}"
                , sequence
                , Thread.CurrentThread.ManagedThreadId
                , data.IntValue);
        }
    }
}
