using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tasks.Domain.Interfaces;
using Tasks.Entities.Entities;
using Tasks.Infra.Configuration;
using Tasks.Infra.Repository.Generics;

namespace Tasks.Infra.Repository.Repositories
{
    public class RepositoryTarefa : RepositoryGeneric<Tarefa>, ITarefa
    {
        private readonly DbContextOptions<ContextBase> _dbOptions;
        public RepositoryTarefa()
        {
            _dbOptions = new DbContextOptions<ContextBase>();
        }

        public async Task<IEnumerable<Tarefa>> ListarTarefasAtivas(Expression<Func<Tarefa, bool>> ex)
        {
            using (var bd = new ContextBase(_dbOptions))
                return await bd.Tarefa.Where(ex).AsNoTracking().ToListAsync();
        }
    }
}