using MinhaListadeTarefas.Models;

namespace MinhaListadeTarefas.Repositories
{
    public class RepositoryStatus : RepositoryBase<Status>
    {
        public RepositoryStatus(AppDbContext context, bool saveChanges = true) : base(context, saveChanges)
        {
        }
    }

}
