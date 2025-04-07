using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MinhaListadeTarefas.Models;
using MinhaListadeTarefas.Services;

namespace MinhaListadeTarefas.Controllers
{
    public class tarefaController : Controller
    {

        private AppDbContext _context;

        private ServiceTarefa _serviceTarefa;

        public tarefaController(AppDbContext context, ServiceTarefa serviceTarefa)
        {
            _context = context;
            _serviceTarefa = new ServiceTarefa(_context);
        }

        public tarefaController(AppDbContext context)
        {
            _context = context;
        }

        public async Task CarregaComboBox()
        {
            ViewData["Categorias"] = new SelectList(await _serviceTarefa.RptCategoria.ListarTodosAsync(), "Id", "Name");
            ViewData["Prioridades"] = new SelectList(_context.Prioridades.ToList(), "Id", "Name");
            ViewData["Responsavels"] = new SelectList(_context.Responsaveis.ToList(), "Id", "Name");
            ViewData["Status"] = new SelectList(_context.Status.ToList(), "Id", "Name");
        }

        public IActionResult Index()
        {

            


            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            CarregaComboBox();

            return View();
        }


        [HttpPost]
        public IActionResult Create(Tarefa tarefa)
        {
            CarregaComboBox();
            if (tarefa.Datafim < tarefa.Datainicio)
            {
                ModelState.AddModelError("DataInicio", "A data de Fim nao pode ser menor que a Data de Inicio");

            }
            if (ModelState.IsValid)
            {
                ViewData["Mensagem"] = "Dados salvos com sucesso!";
                return View(tarefa);
            }
            
            return View();
        }

        public IActionResult Edit(int id)
        {

            return View();
        }
    }
}
