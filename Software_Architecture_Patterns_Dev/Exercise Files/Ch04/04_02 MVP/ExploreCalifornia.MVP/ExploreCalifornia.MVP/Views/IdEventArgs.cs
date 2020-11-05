using System;

namespace ExploreCalifornia.MVP.Views
{
    public class IdEventArgs : EventArgs
    {
        public int Id { get; }

        public IdEventArgs(int id)
        {
            Id = id;
        }
    }
}