using MinhaListadeTarefas.Models;

namespace MinhaListadeTarefas.Repositories
{
    public class RepositoryCategoria : RepositoryBase<Categoria>
    {
        public RepositoryCategoria(AppDbContext context, bool saveChanges = true) : base(context, saveChanges)
        {

        }

    }
}
