using System.ComponentModel.DataAnnotations;

namespace GourmetGo.Models
{
    public class Estoque
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a quantidade")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o preço por unidade")]
        public decimal Preço { get; set; }

        [Display(Name = "Data de entrada")]
        [Required(ErrorMessage = "Obrigatório informar a data de entrada")]
        public DateTime DataEntrada { get; set; }

        [Required(ErrorMessage = "Obrigatório escolher a categoria")]
        public string Categoria { get; set; }

    }


}
