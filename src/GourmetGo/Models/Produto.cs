using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GourmetGo.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o nome!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a descrição!")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o preço!")]
        [Display(Name = "Preço")]
        public double Preco { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a categoria!")]
        public Categoria Categoria { get; set; }

        // Adicionando a propriedade Imagem
        public byte[] Imagem { get; set; }

        public ICollection<Pedido> Pedidos { get; set; }
    }

    public enum Categoria
    {
        Comida,
        Bebida
    }
}
