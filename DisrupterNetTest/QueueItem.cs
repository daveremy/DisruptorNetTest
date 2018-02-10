namespace DisrupterNetTest
{
    public class QueueItem
    {
        public int IntValue { get; set; }
        public void Update(QueueItem other)
        {
            IntValue = other.IntValue;
        }
    }
}
