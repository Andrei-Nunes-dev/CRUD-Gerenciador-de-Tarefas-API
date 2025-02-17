using CRUD_Tarefas.Data;
using CRUD_Tarefas.Models;
using CRUD_Tarefas.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Tarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly ApplicationDBContext dBContext;
        public TarefasController(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext;
            
        }
        [HttpGet]
        public IActionResult GetAllTarefas()
        {
            var todasTarefas = dBContext.Tarefas.ToList();
            return Ok(todasTarefas);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetTarefaPorId(int id)
        {
            var tarefa = dBContext.Tarefas.Find(id);

            if (tarefa is null)
            {
                return NotFound();
            }

            return Ok(tarefa);

        }

        [HttpPost]
        public IActionResult AdicionarTarefa(AdicionarTarefaDto adicionarTarefaDto)
        {
            var tarefaEntidade = new Tarefas()
            {
                Titulo = adicionarTarefaDto.Titulo,
                Descricao = adicionarTarefaDto.Descricao,
                Data_Vencimento = adicionarTarefaDto.Data_Vencimento
            };

            dBContext.Tarefas.Add(tarefaEntidade);
            dBContext.SaveChanges();

            return Ok(tarefaEntidade);

        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult AtualizarTarefa(int id, AtualizarTarefaDto atualizarTarefaDto)
        {
            var tarefa = dBContext.Tarefas.Find(id);
            if(tarefa is null)
            {
                return NotFound();
            }

            tarefa.Titulo = atualizarTarefaDto.Titulo;
            tarefa.Descricao = atualizarTarefaDto.Descricao;
            tarefa.Data_Vencimento = atualizarTarefaDto.Data_Vencimento;

            dBContext.SaveChanges();
            return Ok(tarefa);

        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeletarTarefa(int id)
        {
            var tarefa = dBContext.Tarefas.Find(id);
            if (tarefa is null)
            {
                return NotFound();
            }
            dBContext.Tarefas.Remove(tarefa);
            dBContext.SaveChanges();

            return Ok();
        }

    }
}
