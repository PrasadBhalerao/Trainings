using System;

namespace ExploreCalifornia.Website.ESB
{
    public class Message : Message<string>
    {
        public Message() : base("")
        {
            MessageId = Guid.NewGuid();
        }
    }

    public class Message<T>
    {
        public Message()
        {
        }

        public Message(T data)
        {
            MessageId = Guid.NewGuid();
            Data = data;
        }

        public Guid MessageId { get; set; }
        public T Data { get; set; }
    }
}