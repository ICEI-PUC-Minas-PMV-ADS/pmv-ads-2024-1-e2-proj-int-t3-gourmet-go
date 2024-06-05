using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GourmetGo.Models
{
    [Table("Pedidos")]
    public class Pedido
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Usuário")]
        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        public string Observações { get; set; }

        [Display(Name = "Recebimento")]
        [Required(ErrorMessage = "Obrigatório informar como deseja receber seu pedido!")]
        public TipoDeEntrega Tipo { get; set; }

        [Display(Name = "Endereço")]
        public string Endereço { get; set; }

        [Display(Name = "Forma de Pagamento")]
        public FormaDePagamento Pagamento { get; set; }

        [Display(Name = "Status")]
        public StatusDoPedido Status { get; set; }

        public ICollection<PedidoProduto> PedidoProdutos { get; set; }
    }

    public enum TipoDeEntrega
    {
        Delivery,
        Estabelecimento
    }

    public enum StatusDoPedido
    {
        [Display(Name = "Aguardando confirmação do estabelecimento")] EmAndamento,
        [Display(Name = "Em preparo...")] EmPreparo,
        [Display(Name = "Pronto para entrega")] ProntoParaEntrega,
        [Display(Name = "Pronto para entrega")] Finalizado
    }

    public enum FormaDePagamento
    {
        [Display(Name = "Pagar pelo Site")] PagarPeloSite,
        [Display(Name = "Pagar no Estabelecimento")] PagarNoEstabelecimento,
        [Display(Name = "Pagar na Entrega")] PagarNaEntrega
    }
}
