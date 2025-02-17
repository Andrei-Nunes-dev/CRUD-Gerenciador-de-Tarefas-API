using System.ComponentModel.DataAnnotations;

namespace CRUD_Tarefas.Models
{
    public class AtualizarTarefaDto
    {
        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public DateTime Data_Vencimento { get; set; }
    }
}
