using System;

namespace ExploreCalifornia.EmailService.ESB
{
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