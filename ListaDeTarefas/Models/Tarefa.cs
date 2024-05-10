using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ListaDeTarefas.Models
{
    public class Tarefa
    {
        public int TarefaId { get; set; }

        public string NomeTarefa { get; set; } = string.Empty;

        public string? CategoriaId { get; set; }

        public string? Descricao { get; set; }

        public DateOnly DataDeInicio { get; set; } 

        public DateOnly DataDeVencimento { get; set; } 

        public string? Status {  get; set; }
    }
}
