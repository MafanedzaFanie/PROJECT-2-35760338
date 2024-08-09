using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectTwo_35760338.Models;

namespace ProjectTwo_35760338.Controllers
{
   

    [Route("api/[controller]")]
    [ApiController]
    public class JobTelemetriesController : ControllerBase
    {
        private readonly Project2DbContext _context;

        public JobTelemetriesController(Project2DbContext context)
        {
            _context = context;
        }

        // GET: api/JobTelemetries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobTelemetry>>> GetJobTelemetries()
        {
            return await _context.JobTelemetries.ToListAsync();
        }

        // GET: api/JobTelemetries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobTelemetry>> GetJobTelemetry(int id)
        {
            var jobTelemetry = await _context.JobTelemetries.FindAsync(id);

            if (jobTelemetry == null)
            {
                return NotFound();
            }

            return jobTelemetry;
        }

        // PUT: api/JobTelemetries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobTelemetry(int id, JobTelemetry jobTelemetry)
        {
            if (id != jobTelemetry.Id)
            {
                return BadRequest();
            }

            _context.Entry(jobTelemetry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobTelemetryExists(id))
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

        // POST: api/JobTelemetries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JobTelemetry>> PostJobTelemetry(JobTelemetry jobTelemetry)
        {
            _context.JobTelemetries.Add(jobTelemetry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobTelemetry", new { id = jobTelemetry.Id }, jobTelemetry);
        }
        //PATCH: api/JobTelemetries/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchJobTelemetry(int id, [FromBody] JsonPatchDocument<JobTelemetry> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var jobTelemetry = await _context.JobTelemetries.FindAsync(id);

            if (jobTelemetry == null)
            {
                return NotFound();
            }

            patchDoc.ApplyTo(jobTelemetry, ModelState);

            if (!TryValidateModel(jobTelemetry))
            {
                return ValidationProblem(ModelState);
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }
    public class Project2DbContext : DbContext
    {
        public DbSet<JobTelemetry> JobTelemetries { get; set; }

        public Project2DbContext(DbContextOptions<Project2DbContext> options) : base(options)
        { }
    }

        // DELETE: api/JobTelemetries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobTelemetry(int id)
        {
            var jobTelemetry = await _context.JobTelemetries.FindAsync(id);
            if (jobTelemetry == null)
            {
                return NotFound();
            }

            _context.JobTelemetries.Remove(jobTelemetry);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobTelemetryExists(int id)
        {
            return _context.JobTelemetries.Any(e => e.Id == id);
        }

        [HttpGet("GetSavings")]
        public async Task<IActionResult> GetSavings(string projectId, DateTime startDate, DateTime endDate)
        {
            // Query the database for telemetry data related to the specified project ID and date range
            var jobTelemetry = await _context.JobTelemetries
                .Where(j => j.ProccesId == projectId && j.EntryDate >= startDate && j.EntryDate <= endDate)
                .ToListAsync();

            if (jobTelemetry == null || !jobTelemetry.Any())
            {
                return NotFound();
            }

            // Calculate cumulative time and cost saved
            var totalTimeSaved = jobTelemetry.Sum(j => j.TimeSaved);
            var totalCostSaved = jobTelemetry.Sum(j => j.CostSaved);

            var result = new
            {
                ProjectId = projectId,
                StartDate = startDate,
                EndDate = endDate,
                TotalTimeSaved = totalTimeSaved,
                TotalCostSaved = totalCostSaved
            };

            return Ok(result);
        }
    }
}
