using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistraCompraCommand : IRequest<bool>
    {
        public string UsuarioSolicitante { get; set; }
        public string NomeFornecedor { get; set; }
        public int CondicaoPagamento { get; set; }
        public IList<ItemSolicitacaoCompra> Itens { get; set; }
    }
    public class ItemSolicitacaoCompra
    {
        public Guid ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }
}
