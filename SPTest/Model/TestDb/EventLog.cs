using System;
using System.Collections.Generic;

#nullable disable

namespace SPTest.Model.TestDb
{
    public partial class EventLog
    {
        public Guid Id { get; set; }
        public DateTime EventDate { get; set; }
        public string Description { get; set; }
    }
}
