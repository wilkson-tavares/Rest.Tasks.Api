using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tasks.Api.Models;
using Tasks.Domain.Interfaces;
using Tasks.Domain.Interfaces.Services;
using Tasks.Entities.Entities;

namespace Tasks.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITarefa _tarefa;
        private readonly IServiceTarefa _serviceTarefa;

        public TarefaController(IMapper mapper
            , ITarefa tarefa
            , IServiceTarefa serviceTarefa)
        {
            _mapper = mapper;
            _tarefa = tarefa;
            _serviceTarefa = serviceTarefa;
        }

        [HttpPost("/Add")]
        public async Task<IActionResult> Add(TarefaViewModel tarefa)
        {
            tarefa.Id = Guid.NewGuid();
            var tarefaMap = _mapper.Map<Tarefa>(tarefa);
            await _tarefa.Add(tarefaMap);

            return Ok();
        }

        [HttpPost("/Update")]
        public async Task<IActionResult> Update(TarefaViewModel tarefa)
        {
            var tarefaMap = _mapper.Map<Tarefa>(tarefa);
            await _tarefa.Update(tarefaMap);

            return Ok();
        }

        [HttpPost("/Delete")]
        public async Task<IActionResult> Delete(TarefaViewModel tarefa)
        {
            var tarefaMap = _mapper.Map<Tarefa>(tarefa);
            await _tarefa.Delete(tarefaMap);

            return Ok();
        }

        [HttpGet("/GetById/{id}")]
        public async Task<IActionResult> GetEntityById(Guid id)
        {
           var tarefa = await _tarefa.GetById(id);
            var messageMap = _mapper.Map<TarefaViewModel>(tarefa);
            return Ok(messageMap);
        }

        [HttpGet("/ListarTarefasAtivas")]
        public async Task<IActionResult> ListarTarefasAtivas()
        {
           var tarefa = await _serviceTarefa.ListarTarefasAtivas();
            var messageMap = _mapper.Map<List<TarefaViewModel>>(tarefa);
            return Ok(messageMap);
        }
    }
}