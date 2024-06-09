using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GourmetGo.Models
{
    [Table("PedidoProduto")]
    public class PedidoProduto
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Pedido")]
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }

        [ForeignKey("Produto")]
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        [Required]
        public int Quantidade { get; set; }
    }
}
