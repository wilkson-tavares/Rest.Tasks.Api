using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasks.Entities.Enums;

namespace Tasks.Api.Models
{
    public class TarefaViewModel
    {
        public Guid Id { get; set; }
        public required string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public TarefaStatus Status { get; set; }
    }
}