using MinhaListadeTarefas.Models;

namespace MinhaListadeTarefas.Repositories
{
    public class RepositoryPrioridade : RepositoryBase<Prioridade>
    {
        public RepositoryPrioridade(AppDbContext context, bool saveChanges = true) : base(context, saveChanges)
        {
        }
    }
}
