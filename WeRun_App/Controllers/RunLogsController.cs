using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WeRun_App.Database;
using WeRun_App.Entities;

namespace WeRun_App.Controllers
{
    public class RunLogsController : Controller
    {
        private readonly AppDBContext _context;

        public RunLogsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: RunLogs
        public async Task<IActionResult> Index()
        {
            var appDBContext = _context.RunLog.Include(r => r.Route).Include(r => r.User);
            return View(await appDBContext.ToListAsync());
        }

        // GET: RunLogs/Details/5
        public async Task<IActionResult> Details(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var runLog = await _context.RunLog
                .Include(r => r.Route)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.RunId == id);
            if (runLog == null)
            {
                return NotFound();
            }

            return View(runLog);
        }

        // GET: RunLogs/Create
        public IActionResult Create()
        {
            ViewData["RouteId"] = new SelectList(_context.Routes, "RouteId", "RouteId");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: RunLogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RunId,UserId,StartTime,EndTime,Duration,Distance,CaloriesBurned,RouteId")] RunLog runLog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(runLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RouteId"] = new SelectList(_context.Routes, "RouteId", "RouteId", runLog.RouteId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", runLog.UserId);
            return View(runLog);
        }

        // GET: RunLogs/Edit/5
        public async Task<IActionResult> Edit(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var runLog = await _context.RunLog.FindAsync(id);
            if (runLog == null)
            {
                return NotFound();
            }
            ViewData["RouteId"] = new SelectList(_context.Routes, "RouteId", "RouteId", runLog.RouteId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", runLog.UserId);
            return View(runLog);
        }

        // POST: RunLogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(uint id, [Bind("RunId,UserId,StartTime,EndTime,Duration,Distance,CaloriesBurned,RouteId")] RunLog runLog)
        {
            if (id != runLog.RunId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(runLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RunLogExists(runLog.RunId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["RouteId"] = new SelectList(_context.Routes, "RouteId", "RouteId", runLog.RouteId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", runLog.UserId);
            return View(runLog);
        }

        // GET: RunLogs/Delete/5
        public async Task<IActionResult> Delete(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var runLog = await _context.RunLog
                .Include(r => r.Route)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.RunId == id);
            if (runLog == null)
            {
                return NotFound();
            }

            return View(runLog);
        }

        // POST: RunLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(uint id)
        {
            var runLog = await _context.RunLog.FindAsync(id);
            if (runLog != null)
            {
                _context.RunLog.Remove(runLog);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RunLogExists(uint id)
        {
            return _context.RunLog.Any(e => e.RunId == id);
        }
    }
}
