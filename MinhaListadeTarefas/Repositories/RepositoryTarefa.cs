using Microsoft.EntityFrameworkCore;
using MinhaListadeTarefas.Models;

namespace MinhaListadeTarefas.Repositories
{
    public class RepositoryTarefa:RepositoryBase<Tarefa>
    {
        public RepositoryTarefa(AppDbContext context, bool saveChanges = true) : base(context, saveChanges)
        {
             
        }

    }
}
