using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TreinoMais.AcessoDados;
using TreinoMais.Dominio.Models;

namespace TreinoMais.Controllers
{
    public class ProfessorConta : Controller
    {
        private readonly Contexto _context;

        public ProfessorConta(Contexto context)
        {
            _context = context;
        }

        // GET: ProfessorConta
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Professores.Include(p => p.Administrador);
            return View(await contexto.ToListAsync());
        }

        // GET: ProfessorConta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professores
                .Include(p => p.Administrador)
                .FirstOrDefaultAsync(m => m.ProfessorId == id);
            if (professor == null)
            {
                return NotFound();
            }

            return View(professor);
        }

        // GET: ProfessorConta/Create
        public IActionResult Create()
        {
            ViewData["Administrador"] = new Administrador();

            //new SelectList(_context.Administradores, "AdministradorId", "Email");
            return View();
        }

        // POST: ProfessorConta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfessorId,Nome,Foto,Telefone,Turno,AdministradorId")] Professor professor)
        {

            var a = ViewData["Administrador"];

            
            Administrador adm = new Administrador
            {
                Email = ViewData["AdministradorEmail"].ToString(),
                Senha = ViewData["AdministradorSenha"].ToString()
            };

            if (ModelState.IsValid)
            {

                _context.Add(professor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdministradorId"] = new SelectList(_context.Administradores, "AdministradorId", "Email", professor.AdministradorId);
            return View(professor);
        }

        // GET: ProfessorConta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professores.FindAsync(id);
            if (professor == null)
            {
                return NotFound();
            }
            ViewData["AdministradorId"] = new SelectList(_context.Administradores, "AdministradorId", "Email", professor.AdministradorId);
            return View(professor);
        }

        // POST: ProfessorConta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProfessorId,Nome,Foto,Telefone,Turno,AdministradorId")] Professor professor)
        {
            if (id != professor.ProfessorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessorExists(professor.ProfessorId))
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
            ViewData["AdministradorId"] = new SelectList(_context.Administradores, "AdministradorId", "Email", professor.AdministradorId);
            return View(professor);
        }

        // GET: ProfessorConta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professores
                .Include(p => p.Administrador)
                .FirstOrDefaultAsync(m => m.ProfessorId == id);
            if (professor == null)
            {
                return NotFound();
            }

            return View(professor);
        }

        // POST: ProfessorConta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var professor = await _context.Professores.FindAsync(id);
            _context.Professores.Remove(professor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessorExists(int id)
        {
            return _context.Professores.Any(e => e.ProfessorId == id);
        }
    }
}
