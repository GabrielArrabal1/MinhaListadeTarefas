using System.ComponentModel.DataAnnotations;

namespace MinhaListadeTarefas.Models
{
    public class Categoria
    {
        [Key]
        [Required(ErrorMessage = "O campo ID é obrigatorio")]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatorio")]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
