using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreinoMais.AcessoDados;
using Microsoft.EntityFrameworkCore;


namespace FichaAcademia.ViewComponents
{
    public class ListagemExercicioTreinoViewComponent : ViewComponent
    {
        private readonly Contexto _contexto;

        public ListagemExercicioTreinoViewComponent(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<IViewComponentResult> InvokeAsync(int TreinoId)
        {
            return View(await _contexto.ListaExercicios.Include(l => l.Exercicio).Where(l => l.TreinoId == TreinoId).ToListAsync());
        }
    }
}

