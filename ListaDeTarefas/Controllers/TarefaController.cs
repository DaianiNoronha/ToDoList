using Microsoft.AspNetCore.Mvc;
using ListaDeTarefas.Models;

namespace ListaDeTarefas.Controllers
{
    public class TarefaController : Controller
    {
        private static List<Tarefa> _tarefa = new List<Tarefa>()
    {
       new Tarefa { TarefaId= 1, NomeTarefa="Projeto 4", CategoriaId="Trabalho", Descricao="Entregar o projeto 'Lista de Tarefas' da semana 4 do curso da Impacta.", DataDeInicio = DateOnly.FromDateTime(DateTime.Now), DataDeVencimento = new DateOnly(2024, 5, 15),  Status="to-do" },
       new Tarefa { TarefaId= 2, NomeTarefa="Desafio da Unidade II", CategoriaId="Faculdade", Descricao = "Apresentar uma dissertação de duas páginas.", DataDeInicio = DateOnly.FromDateTime(DateTime.Now), DataDeVencimento = new DateOnly(2024, 6, 29), Status= "to-do" },
       new Tarefa { TarefaId= 3, NomeTarefa="Lavar Roupa", CategoriaId="Casa", Descricao = "Lavar a roupa da semana", DataDeInicio = DateOnly.FromDateTime(DateTime.Now), DataDeVencimento = new DateOnly(2024, 5, 25), Status = "to-do" },
       new Tarefa { TarefaId= 4, NomeTarefa="Aula de Nós", CategoriaId="Voluntáriado", Descricao = "Preparar aula prática sobre amarra diagonal e quadrada.", DataDeInicio = DateOnly.FromDateTime(DateTime.Now), DataDeVencimento = new DateOnly(2024, 6, 25), Status = "to-do" }
    };
        public IActionResult Index()
        {
            return View(_tarefa);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                tarefa.TarefaId = _tarefa.Count > 0 ? _tarefa.Max(t => t.TarefaId) + 1 : 1;
                _tarefa.Add(tarefa);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var tarefa = _tarefa.FirstOrDefault(t => t.TarefaId == id);
            if (tarefa == null)
            {
                return NotFound();
            }

            _tarefa.Remove(tarefa);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var tarefa = _tarefa.FirstOrDefault(t => t.TarefaId == id);
            if (tarefa == null)
            {
                return NotFound();
            }

            return View(tarefa);
        }

        [HttpPost]
        public IActionResult Edit(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                var existingTarefa = _tarefa.FirstOrDefault(t => t.TarefaId == tarefa.TarefaId);
                if (existingTarefa != null)
                {
                    existingTarefa.NomeTarefa = tarefa.NomeTarefa;
                    existingTarefa.CategoriaId = tarefa.CategoriaId;
                    existingTarefa.Descricao = tarefa.Descricao;
                    existingTarefa.DataDeInicio = tarefa.DataDeInicio;
                    existingTarefa.DataDeVencimento = tarefa.DataDeVencimento;
                    existingTarefa.Status = tarefa.Status;

                }
                return RedirectToAction("Index");
            }
            return View(tarefa);
        }

        [HttpGet]
        public IActionResult Detalhes(int id)
        {
            var cliente = _tarefa.FirstOrDefault(t => t.TarefaId == id);
            if (cliente == null)
            {
                return NotFound(); 
            }

            return View(cliente);
        }

        public IActionResult Done()
        {
            var tarefasConcluidas = _tarefa.Where(t => t.Status == "done").ToList();
            return View(tarefasConcluidas);
        }

        public IActionResult ToDo()
        {
            var tarefasAFazer = _tarefa.Where(t => t.Status == "to-do").ToList();
            return View(tarefasAFazer);
        }



    }
}
