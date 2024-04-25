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
    public class RunHistoriesController : Controller
    {
        private readonly AppDBContext _context;

        public RunHistoriesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: RunHistories
        public async Task<IActionResult> Index()
        {
            var appDBContext = _context.RunHistory.Include(r => r.Route).Include(r => r.User);
            return View(await appDBContext.ToListAsync());
        }

        // GET: RunHistories/Details/5
        public async Task<IActionResult> Details(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var runHistory = await _context.RunHistory
                .Include(r => r.Route)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.HistoryId == id);
            if (runHistory == null)
            {
                return NotFound();
            }

            return View(runHistory);
        }

        // GET: RunHistories/Create
        public IActionResult Create()
        {
            ViewData["RouteId"] = new SelectList(_context.Routes, "RouteId", "RouteId");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: RunHistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HistoryId,UserId,TotalRuns,TotalDistance,TotalCalories,BestTime,BestDistance,RouteId")] RunHistory runHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(runHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RouteId"] = new SelectList(_context.Routes, "RouteId", "RouteId", runHistory.RouteId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", runHistory.UserId);
            return View(runHistory);
        }

        // GET: RunHistories/Edit/5
        public async Task<IActionResult> Edit(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var runHistory = await _context.RunHistory.FindAsync(id);
            if (runHistory == null)
            {
                return NotFound();
            }
            ViewData["RouteId"] = new SelectList(_context.Routes, "RouteId", "RouteId", runHistory.RouteId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", runHistory.UserId);
            return View(runHistory);
        }

        // POST: RunHistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(uint id, [Bind("HistoryId,UserId,TotalRuns,TotalDistance,TotalCalories,BestTime,BestDistance,RouteId")] RunHistory runHistory)
        {
            if (id != runHistory.HistoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(runHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RunHistoryExists(runHistory.HistoryId))
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
            ViewData["RouteId"] = new SelectList(_context.Routes, "RouteId", "RouteId", runHistory.RouteId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", runHistory.UserId);
            return View(runHistory);
        }

        // GET: RunHistories/Delete/5
        public async Task<IActionResult> Delete(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var runHistory = await _context.RunHistory
                .Include(r => r.Route)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.HistoryId == id);
            if (runHistory == null)
            {
                return NotFound();
            }

            return View(runHistory);
        }

        // POST: RunHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(uint id)
        {
            var runHistory = await _context.RunHistory.FindAsync(id);
            if (runHistory != null)
            {
                _context.RunHistory.Remove(runHistory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RunHistoryExists(uint id)
        {
            return _context.RunHistory.Any(e => e.HistoryId == id);
        }
    }
}
