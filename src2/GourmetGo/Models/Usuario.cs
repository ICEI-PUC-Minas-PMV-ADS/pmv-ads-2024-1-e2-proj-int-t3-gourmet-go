using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GourmetGo.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o nome completo!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o CPF!")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o telefone!")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o e-mail!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a senha! (mínimo de 6 caracteres)")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public Tipo Tipo { get; set; }
    }

    public enum Tipo
    {
        Admin,
        User
    }
}
