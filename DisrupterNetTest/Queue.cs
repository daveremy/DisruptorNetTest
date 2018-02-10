using Disruptor;
using Disruptor.Dsl;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DisrupterNetTest
{
    public class Queue
    {
        private RingBuffer<QueueItem> ringBuffer;
        private Disruptor<QueueItem> disruptor;

        public void Start()
        {
            var eventHandler = new EventHandler();
            disruptor = new Disruptor<QueueItem>(() => new QueueItem(), (int)Math.Pow(64, 2), TaskScheduler.Default);
            disruptor.HandleEventsWith(eventHandler);
            ringBuffer = disruptor.Start();
        }

        public void Stop()
        {
            disruptor.Halt();
        }

        public void Enqueue(QueueItem item)
        {
            var next = ringBuffer.Next();
            ringBuffer[next].Update(item);
            ringBuffer.Publish(next);
            Console.WriteLine("Enqueing on thread id {0}", Thread.CurrentThread.ManagedThreadId);
        }
    }
}
