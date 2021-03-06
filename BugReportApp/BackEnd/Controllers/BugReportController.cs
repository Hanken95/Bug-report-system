﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEnd.Models;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BugReportController : ControllerBase
    {
        private readonly BugReportContext _context;

        public BugReportController(BugReportContext context)
        {
            _context = context;
        }

        // GET: api/BugReport
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BugReport>>> GetBugReport()
        {
            var bugReports = await _context.BugReport.ToListAsync();
           
            return bugReports;
        }

        // GET: api/BugReport/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BugReport>> GetBugReport(int id)
        {
            var bugReport = await _context.BugReport.FindAsync(id);

            if (bugReport == null)
            {
                return NotFound();
            }

            return bugReport;
        }

        // PUT: api/BugReport/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBugReport(int id, BugReport bugReport)
        {
            if (id != bugReport.Id)
            {
                return BadRequest();
            }

            _context.Entry(bugReport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BugReportExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BugReport
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BugReport>> PostBugReport(BugReport bugReport)
        {
            _context.BugReport.Add(bugReport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBugReport", new { id = bugReport.Id }, bugReport);
        }

        // DELETE: api/BugReport/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBugReport(int id)
        {
            var bugReport = await _context.BugReport.FindAsync(id);
            if (bugReport == null)
            {
                return NotFound();
            }

            _context.BugReport.Remove(bugReport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BugReportExists(int id)
        {
            return _context.BugReport.Any(e => e.Id == id);
        }
    }
}
