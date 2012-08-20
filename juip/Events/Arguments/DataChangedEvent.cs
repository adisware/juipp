using System;

namespace adisware.juipp.Events.Arguments
{
    public class DataChangedEvent<TD> 
    {
        public TD Data { get; set; }
    }
}