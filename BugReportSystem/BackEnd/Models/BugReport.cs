using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public enum Status { Open, Closed }
    public class BugReport
    {
        public int ID { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public DateTime Created { get; set; }
    }
}
