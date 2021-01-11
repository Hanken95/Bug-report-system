using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackEnd.Models;

    public class BugReportContext : DbContext
    {
        public BugReportContext (DbContextOptions<BugReportContext> options)
            : base(options)
        {
        }

        public DbSet<BackEnd.Models.BugReport> BugReport { get; set; }
    }
