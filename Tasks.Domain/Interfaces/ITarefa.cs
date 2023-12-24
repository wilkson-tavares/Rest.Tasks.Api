using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Tasks.Domain.Interfaces.Generics;
using Tasks.Entities.Entities;

namespace Tasks.Domain.Interfaces
{
    public interface ITarefa : IGeneric<Tarefa>
    {
        Task<IEnumerable<Tarefa>> ListarTarefasAtivas(Expression<Func<Tarefa, bool>> ex);
    }
}