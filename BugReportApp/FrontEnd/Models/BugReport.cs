using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Models
{
    public enum Status { Open, Closed }

    public class BugReport
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }

        public BugReport()
        {
            Status = Status.Open;
        }
    }
}
