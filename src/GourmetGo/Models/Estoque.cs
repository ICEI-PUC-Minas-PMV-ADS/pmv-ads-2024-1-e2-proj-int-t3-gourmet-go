using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GourmetGo.Models
{
    public class Estoque
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o nome do alimento")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a quantidade")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o preço por unidade")]
        [Range(0, 99999.99)]
        [Column(TypeName = "decimal(7,2)")]
        public decimal Preco { get; set; }

        [Display(Name = "Data de entrada")]
        [Required(ErrorMessage = "Obrigatório informar a data de entrada")]
        [DataType(DataType.Date)]
        public DateTime DataEntrada { get; set; }

        [Required(ErrorMessage = "Obrigatório escolher a categoria")]
        public Categoria Categoria { get; set; }

    }


}
