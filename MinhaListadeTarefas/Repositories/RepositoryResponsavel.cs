using MinhaListadeTarefas.Models;

namespace MinhaListadeTarefas.Repositories
{
    public class RepositoryResponsavel : RepositoryBase<Responsavel>
    {
        public RepositoryResponsavel(AppDbContext context, bool saveChanges = true) : base(context, saveChanges)
        {
        }
    }
}
