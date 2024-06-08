using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GourmetGo.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatório informar seu nome!")]
        public string Nome { get; set; }

        public string Cpf { get; set; }


        public string Telefone { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o e-mail!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a senha! (mínimo de 6 caracteres)")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage ="Obrigatório informar o endereço!")]
        public string Endereco { get; set; }
        public Tipo Tipo { get; set; }

        public ICollection<Pedido> Pedidos { get; set; }
    }

    public enum Tipo
    {
        Admin,
        Cliente,
        Garcom,
        Cozinheiro
    }
}
