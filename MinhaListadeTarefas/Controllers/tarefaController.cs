using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MinhaListadeTarefas.Models;
using MinhaListadeTarefas.Services;
using System.Threading.Tasks;

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

        //public tarefaController(AppDbContext context)
        //{
        //    _context = context;
        //}

        public async Task CarregaComboBox()
        {
            ViewData["Categorias"] = new SelectList(await _serviceTarefa.RptCategoria.ListarTodosAsync(), "Id", "Name");
            ViewData["Prioridades"] = new SelectList(await _serviceTarefa.RptPrioridade.ListarTodosAsync(), "Id", "Name");
            ViewData["Responsavels"] = new SelectList(await _serviceTarefa.RptResponsavel.ListarTodosAsync(), "Id", "Name");
            ViewData["Status"] = new SelectList(await _serviceTarefa.RptStatus.ListarTodosAsync(), "Id", "Name");
        }

        public async Task<IActionResult> Index()
        {

            var listatarefa = await _serviceTarefa.RptTarefa.ListarTodosAsync();


            return View(listatarefa);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await CarregaComboBox();

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Tarefa tarefa)
        {
            await CarregaComboBox();
            if (tarefa.Datafim < tarefa.Datainicio)
            {
                ModelState.AddModelError("DataInicio", "A data de Fim nao pode ser menor que a Data de Inicio");

            }
            if (ModelState.IsValid)
            {
                ViewData["Mensagem"] = "Dados salvos com sucesso!";
                await _serviceTarefa.RptTarefa.IncluirAsync(tarefa);
                return View(tarefa);
            }

            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            await CarregaComboBox();
            var tarefa = await _serviceTarefa.RptTarefa.SelecionarChaveAsync(id);
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Tarefa tarefa)
        {
            await CarregaComboBox();
            if (tarefa.Datafim < tarefa.Datainicio)
            {
                ModelState.AddModelError("DataInicio", "A data de Fim nao pode ser menor que a Data de Inicio");
            }
            if (ModelState.IsValid)
            {
                ViewData["Mensagem"] = "Dados salvos com sucesso!";
                await _serviceTarefa.RptTarefa.AlterarAsync(tarefa);
                return View(tarefa);
            }
            return View();
        }
    }
}
