using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasks.Entities.Entities;

namespace Tasks.Domain.Interfaces.Services
{
    public interface IServiceTarefa
    {
        Task<IEnumerable<Tarefa>> ListarTarefasAtivas();
    }
}