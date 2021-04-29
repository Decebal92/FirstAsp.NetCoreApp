using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcFootballTeams.Data;
using MvcFootballTeams.Models;

namespace MvcFootballTeams.Controllers
{
    public class FootballTeamsController : Controller
    {
        private readonly MvcFootballTeamsContext _context;

        public FootballTeamsController(MvcFootballTeamsContext context)
        {
            _context = context;
        }

        // GET: FootballTeams
        public async Task<IActionResult> Index(string searchString)
        {

            //IQueryable<string> leagueQuery = from f in _context.FootballTeam
            //                                 orderby f.League
            //                                 select f.League;


            var footballTeams = from f in _context.FootballTeam select f;
            if(!String.IsNullOrEmpty(searchString))
            {
                footballTeams = footballTeams.Where(s => s.Name.Contains(searchString));
            }

            //if(!String.IsNullOrEmpty(footballTeamLeague))
            //{
            //    footballTeams = footballTeams.Where(s => s.League.Contains(footballTeamLeague));
            //}

            //var footballTeamLeagueVM = new FootballTeamLeagueViewModel
            //{
            //    Leagues = new SelectList(await leagueQuery.Distinct().ToListAsync()),
            //    FootballTeams = await footballTeams.ToListAsync()
            //};

            return View(await footballTeams.ToListAsync());
            
        }

        // GET: FootballTeams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var footballTeam = await _context.FootballTeam
                .FirstOrDefaultAsync(m => m.Id == id);
            if (footballTeam == null)
            {
                return NotFound();
            }

            return View(footballTeam);
        }

        // GET: FootballTeams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FootballTeams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Founded,League,DomesticRank,UefaRank, Value")] FootballTeam footballTeam)
        {
            if (ModelState.IsValid)
            {
                _context.Add(footballTeam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(footballTeam);
        }

        // GET: FootballTeams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var footballTeam = await _context.FootballTeam.FindAsync(id);
            if (footballTeam == null)
            {
                return NotFound();
            }
            return View(footballTeam);
        }

        // POST: FootballTeams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Founded,League,DomesticRank,UefaRank, Value")] FootballTeam footballTeam)
        {
            if (id != footballTeam.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(footballTeam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FootballTeamExists(footballTeam.Id))
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
            return View(footballTeam);
        }

        // GET: FootballTeams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var footballTeam = await _context.FootballTeam
                .FirstOrDefaultAsync(m => m.Id == id);
            if (footballTeam == null)
            {
                return NotFound();
            }

            return View(footballTeam);
        }

        // POST: FootballTeams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var footballTeam = await _context.FootballTeam.FindAsync(id);
            _context.FootballTeam.Remove(footballTeam);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FootballTeamExists(int id)
        {
            return _context.FootballTeam.Any(e => e.Id == id);
        }
    }
}
