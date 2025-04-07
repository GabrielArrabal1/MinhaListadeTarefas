using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhaListadeTarefas.Models
{
    public class Tarefa
    {
        [Required(ErrorMessage ="O campo Id é obrigatorio")]
        [Display(Name = "ID da tarefa")]
        [Range(0, int.MaxValue, ErrorMessage = "Insira um valor valido")]
        [Key]
     
        public int? Id { get; set; }

        [Required(ErrorMessage = "O campo Descrição é obrigatorio")]
        [Display(Name = "Descrição da tarefa")]
        [MaxLength(255)]
        public string? Descricao { get; set; }
        [Required(ErrorMessage = "O campo Data de Ínicio é obrigatorio")]
        [Display(Name = "Data de Ínicio da tarefa")]
        [DataType(DataType.Date)]
        public DateTime? Datainicio { get; set; }
        [Required(ErrorMessage = "O campo Data de Fim é obrigatorio")]
        [Display(Name = "Data de Fim da tarefa")]
        [DataType(DataType.Date)]
        public DateTime? Datafim { get; set; }

        [ForeignKey("Prioridade")]
        [Display(Name = "Prioridade")]
        public int PrioridadeId { get; set; }
        public virtual Prioridade Prioridade { get; set; }

        [ForeignKey("Categoria")]
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }

        [ForeignKey("Status")]
        [Display(Name = "Status")]
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }

        public DateTime PrazoConclusao { get; set; }

        [MaxLength(5000)]
        public int Observacao { get; set; }

        [ForeignKey("Responsavel")]
        [Display(Name = "Responsavel")]
        public int ResponsavelId { get; set; }

        public virtual Responsavel Responsavel { get; set; }
    }
}
