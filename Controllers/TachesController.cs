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
    public class TachesController : Controller
    {
        private readonly Project_managementDbContext _context;

        public TachesController(Project_managementDbContext context)
        {
            _context = context;
        }

        // GET: Taches
        public async Task<IActionResult> Index()
        {
            var project_managementDbContext = _context.Taches.Include(t => t.projet);
            return View(await project_managementDbContext.ToListAsync());
        }

        // GET: Taches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tache = await _context.Taches
                .Include(t => t.projet)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tache == null)
            {
                return NotFound();
            }

            return View(tache);
        }

        // GET: Taches/Create
        public IActionResult Create()
        {
            ViewData["idProjet"] = new SelectList(_context.Projets, "Id", "description");
            return View();
        }

        // POST: Taches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("titre,etat,description,dateDebut,dateFin,idProjet")] Tache tache)
        {
            if (ModelState.IsValid)
            {

                var p = await _context.Projets
             
               .FirstOrDefaultAsync(m => m.Id == tache.idProjet);
                tache.projet = p ?? new Projet();

                _context.Taches.Add(tache);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idProjet"] = new SelectList(_context.Projets, "Id", "description", tache.idProjet);
            return View(tache);
        }

        // GET: Taches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tache = await _context.Taches.FindAsync(id);
            if (tache == null)
            {
                return NotFound();
            }
            ViewData["idProjet"] = new SelectList(_context.Projets, "Id", "description", tache.idProjet);
            return View(tache);
        }

        // POST: Taches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,titre,etat,description,dateDebut,dateFin,idProjet")] Tache tache)
        {
            if (id != tache.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tache);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TacheExists(tache.Id))
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
            ViewData["idProjet"] = new SelectList(_context.Projets, "Id", "description", tache.idProjet);
            return View(tache);
        }

        // GET: Taches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tache = await _context.Taches
                .Include(t => t.projet)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tache == null)
            {
                return NotFound();
            }

            return View(tache);
        }

        // POST: Taches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tache = await _context.Taches.FindAsync(id);
            if (tache != null)
            {
                _context.Taches.Remove(tache);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TacheExists(int id)
        {
            return _context.Taches.Any(e => e.Id == id);
        }
    }
}
