using System;

namespace ExploreCalifornia.ESB.Contracts
{
    public class Message
    {
        public Guid MessageId { get; set; }
        public dynamic Data { get; set; }
    }
}