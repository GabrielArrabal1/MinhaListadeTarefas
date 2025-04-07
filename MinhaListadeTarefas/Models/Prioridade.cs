using System.ComponentModel.DataAnnotations;

namespace MinhaListadeTarefas.Models
{
    public class Prioridade
    {
        [Key]
        [Required(ErrorMessage ="O campo ID é obrigatorio!")]
        public int Id { get; set; }
        [Required(ErrorMessage ="O campo nome é obrigatorio!")]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
