using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;

namespace GourmetGo.Models
{
    [Table("Enderecos")]
    public class Endereco
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a rua")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o número")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o CEP")]
        public int CEP { get; set; }

        [Display(Name = " Ponto de referência")]
        public string Referencia { get; set; }
    }
}
