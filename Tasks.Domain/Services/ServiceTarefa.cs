using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasks.Domain.Interfaces;
using Tasks.Domain.Interfaces.Services;
using Tasks.Entities.Entities;
using Tasks.Entities.Enums;

namespace Tasks.Domain.Services
{
    public class ServiceTarefa : IServiceTarefa
    {
        private readonly ITarefa _tarefa;

        public ServiceTarefa(ITarefa tarefa)
        {
            _tarefa = tarefa;
        }

        public async Task<IEnumerable<Tarefa>> ListarTarefasAtivas()
            => await _tarefa.ListarTarefasAtivas(a => a.Status == TarefaStatus.ATIVO);
    }
}