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

        /// <summary>
        /// Obter todas as tarefas
        /// </summary>
        /// <returns>Coleção de tarefas</returns>
        /// <response code="200">Sucesso</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllTarefas()
        {
            var todasTarefas = dBContext.Tarefas.ToList();
            return Ok(todasTarefas);
        }

        /// <summary>
        /// Obter uma tarefa
        /// </summary>
        /// <param name="id">Identificador da tarefa</param>
        /// <returns>Dados da tarefa</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetTarefaPorId(int id)
        {
            var tarefa = dBContext.Tarefas.Find(id);

            if (tarefa is null)
            {
                return NotFound();
            }

            return Ok(tarefa);

        }

        /// <summary>
        /// Adicionar uma tarefa
        /// </summary>
        /// <param name="adicionarTarefaDto">Dados da tarefa</param>
        /// <returns>Tarefa recém-criada</returns>
        /// <response code = "200">Sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
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

        /// <summary>
        /// Atualizar uma tarefa
        /// </summary>
        /// <param name="id">Identificador da tarefa</param>
        /// <param name="atualizarTarefaDto">Dados da tarefa</param>
        /// <returns>Nada.</returns>
        /// <response code = "404">Não encontrado</response>
        /// <response code = "200">Sucesso</response>
        [HttpPut]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        /// <summary>
        /// Deletar uma tarefa
        /// </summary>
        /// <param name="id">Identificador da tarefa</param>
        /// <returns>Nada.</returns>
        /// <response code = "404">Não encontrado</response>
        /// <response code = "200">Sucesso</response>
        [HttpDelete]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
