using Microsoft.EntityFrameworkCore;
using MinhaListadeTarefas.Interfaces;
using MinhaListadeTarefas.Models;

namespace MinhaListadeTarefas.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T>, IDisposable where T : class
    {
        public AppDbContext context;
        public bool saveChanges = true;

        public RepositoryBase(AppDbContext pContext, bool pSaveChanges)
        {
            context = pContext;
            saveChanges = pSaveChanges;
        }

        public T Alterar(T entity)
        {
            context.Entry<T>(entity).State = EntityState.Modified;
            if (saveChanges) {context.SaveChanges();}
            return entity;
        }
        

        public async Task<T> AlterarAsync(T entity)
        {
            context.Entry<T>(entity).State |= EntityState.Modified;
            if (saveChanges) 
            {
                await context.SaveChangesAsync();
            }
            return entity;
        }

        public void Dispose()
        {
           context.Dispose();
        }

        public void Excluir(T entity)
        {
            context.Entry<T>(entity).State = EntityState.Deleted;
            if (saveChanges) {context.SaveChanges(); }
        }

        public void Excluir(int id)
        {
            var obj =  SelecionarChave(id);
            if (obj != null)
            {
                context.Set<T>().Remove(obj);
                if (saveChanges)
                {
                   context.SaveChanges();
                }
            }
        }

        public async Task ExcluirAsync(T entity)
        {
            context.Entry<T>(entity).State = EntityState.Deleted;
            if (saveChanges) { await context.SaveChangesAsync(); }
        }

        public async Task ExcluirAsync(int id)
        {
            var obj = await SelecionarChaveAsync(id);
            if (obj != null)
            {
                context.Set<T>().Remove(obj);
                if (saveChanges)
                {
                    await context.SaveChangesAsync();
                }
            }
        }

        public T Incluir(T entity)
        {
            context.Set<T>().Add(entity);
            if (saveChanges)
            {
                context.SaveChanges();
            }
            return entity;
        }

        public async Task<T> IncluirAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            if (saveChanges)
            {
               await context.SaveChangesAsync();
            }
            return entity;
        }

        public List<T> ListarTodos()
        {
            return context.Set<T>().ToList();
        }

        public async Task<List<T>> ListarTodosAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public T SelecionarChave(params object[] variavel)
        {
            return context.Set<T>().Find(variavel)!;
        }

        public async Task<T> SelecionarChaveAsync(params object[] variavel)
        {
            return await context.Set<T>().FindAsync(variavel);
        }
    }
}