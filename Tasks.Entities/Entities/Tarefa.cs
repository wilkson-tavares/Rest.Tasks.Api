using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Tasks.Entities.Enums;

namespace Tasks.Entities.Entities
{
    [Table("Tarefa")]
    public class Tarefa
    {
        [Column("Id")]
        public Guid Id { get; set; }
        [Column("Descricao")]
        public required string Descricao { get; set; }
        [Column("DataCriacao")]
        public DateTime DataCriacao { get; set; }
        [Column("Status")]
        public TarefaStatus Status { get; set; }
    }
}