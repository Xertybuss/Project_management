using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_management;
using Project_management.Models;

namespace Project_management.Controllers
{
    public class MembresController : Controller
    {
        private readonly Project_managementDbContext _context;

        public MembresController(Project_managementDbContext context)
        {
            _context = context;
        }

        // GET: Membres
        public async Task<IActionResult> Index()
        {
            var project_managementDbContext = _context.Membre.Include(m => m.equipe);
            return View(await project_managementDbContext.ToListAsync());
        }

        // GET: Membres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membre = await _context.Membre
                .Include(m => m.equipe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (membre == null)
            {
                return NotFound();
            }

            return View(membre);
        }

        // GET: Membres/Create
        public IActionResult Create()
        {
            ViewData["idEquipe"] = new SelectList(_context.Equipes, "Id", "nomEquipe");
            return View();
        }

        // POST: Membres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,nom,prenom,username,password,age,role,idEquipe")] Membre membre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(membre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idEquipe"] = new SelectList(_context.Equipes, "Id", "nomEquipe", membre.idEquipe);
            return View(membre);
        }

        // GET: Membres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membre = await _context.Membre.FindAsync(id);
            if (membre == null)
            {
                return NotFound();
            }
            ViewData["idEquipe"] = new SelectList(_context.Equipes, "Id", "nomEquipe", membre.idEquipe);
            return View(membre);
        }

        // POST: Membres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,nom,prenom,username,password,age,role,idEquipe")] Membre membre)
        {
            if (id != membre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(membre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembreExists(membre.Id))
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
            ViewData["idEquipe"] = new SelectList(_context.Equipes, "Id", "nomEquipe", membre.idEquipe);
            return View(membre);
        }

        // GET: Membres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membre = await _context.Membre
                .Include(m => m.equipe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (membre == null)
            {
                return NotFound();
            }

            return View(membre);
        }

        // POST: Membres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var membre = await _context.Membre.FindAsync(id);
            if (membre != null)
            {
                _context.Membre.Remove(membre);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembreExists(int id)
        {
            return _context.Membre.Any(e => e.Id == id);
        }
    }
}
