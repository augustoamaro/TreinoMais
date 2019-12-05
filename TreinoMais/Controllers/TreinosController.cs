using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;
using TreinoMais.AcessoDados;
using TreinoMais.AcessoDados.Interfaces;
using TreinoMais.Dominio.Models;

namespace TreinoMais.Controllers
{
    public class TreinosController : Controller
    {
        private readonly IAlunoRepositorio _alunoRepositorio;
        private readonly ITreinoRepositorio _treinoRepositorio;

        public TreinosController(IAlunoRepositorio alunoRepositorio, ITreinoRepositorio treinoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
            _treinoRepositorio = treinoRepositorio;
        }

        // GET: Treinos
        public async Task<IActionResult> Index(int AlunoId)
        {
            ViewBag.AlunoId = AlunoId;
            return View(await _treinoRepositorio.PegarTodosTreinosPeloAlunoId(AlunoId));
        }

        // GET: Treinos/Details/5
        public async Task<IActionResult> Details(int TreinoId)
        {

            var treino = await _treinoRepositorio.PegarTreinoPeloAlunoId(TreinoId);
            if (treino == null)
            {
                return NotFound();
            }

            return View(treino);
        }

        public async Task<IActionResult> VisualizarPDF(int TreinoId)
        {
            var treino = await _treinoRepositorio.PegarTreinoPeloAlunoId(TreinoId);
            if (treino == null)
            {
                return NotFound();
            }

            return new ViewAsPdf("PDF", treino) { FileName = "Treino.PDF" };
        }

        // GET: Treinos/Create
        public IActionResult Create(int AlunoId)
        {
            Treino treino = new Treino();
            treino.AlunoId = AlunoId;
            return View(treino);
        }

        // POST: Treinos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TreinoId,Nome,Cadastro,Validade,AlunoId")] Treino treino)
        {
            treino.Cadastro = DateTime.Parse(DateTime.Now.ToShortDateString());
            treino.Validade = DateTime.Parse(DateTime.Now.AddYears(1).ToShortDateString());

            if (ModelState.IsValid)
            {
                await _treinoRepositorio.Inserir(treino);
                return RedirectToAction(nameof(Index), new { AlunoId = treino.AlunoId });
            }
            
            return View(treino);
        }

        // GET: Treinos/Edit/5
        public async Task<IActionResult> Edit(int TreinoId)
        {


            var treino = await _treinoRepositorio.PegarPeloId(TreinoId);
            if (treino == null)
            {
                return NotFound();
            }
            
            return View(treino);
        }

        // POST: Treinos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int TreinoId, [Bind("TreinoId,Nome,Cadastro,Validade,AlunoId")] Treino treino)
        {
            if (TreinoId != treino.TreinoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _treinoRepositorio.Atualizar(treino);
                return RedirectToAction(nameof(Index), new { AlunoId = treino.AlunoId });
            }
            
            return View(treino);
        }

       
        // POST: Treinos/Delete/5
        [HttpPost]
        public async Task<JsonResult> Delete(int TreinoId)
        {
            await _treinoRepositorio.Excluir(TreinoId);
            return Json("Treino excluído com sucesso");
        }

        public async Task<JsonResult> TreinoExiste(string Nome, int TreinoId)
        {
            if (TreinoId == 0)
            {
                if (await _treinoRepositorio.TreinoExiste(Nome))
                    return Json("Treino já cadastrado");

                return Json(true);
            }
            else
            {
                if (await _treinoRepositorio.TreinoExiste(Nome, TreinoId))
                    return Json("Treino já cadastrado");

                return Json(true);
            }
        }
    }
}
