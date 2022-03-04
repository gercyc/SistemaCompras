using MediatR;
using SolicitacaoAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;
using ProdutoAgg = SistemaCompra.Domain.ProdutoAggregate;
using SistemaCompra.Infra.Data.UoW;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistraCompraCommandHandler : CommandHandler, IRequestHandler<RegistraCompraCommand, bool>
    {
        private readonly SolicitacaoAgg.ISolicitacaoCompraRepository solicitaCompraRepository;
        private readonly ProdutoAgg.IProdutoRepository produtoRepository;

        public RegistraCompraCommandHandler(SolicitacaoAgg.ISolicitacaoCompraRepository _solicitaCompraRepository, ProdutoAgg.IProdutoRepository _produtoRepository, IUnitOfWork uow, IMediator mediator) : base(uow, mediator)
        {
            this.solicitaCompraRepository = _solicitaCompraRepository;
            this.produtoRepository = _produtoRepository;
        }

        public Task<bool> Handle(RegistraCompraCommand request, CancellationToken cancellationToken)
        {
            SolicitacaoAgg.SolicitacaoCompra solicitacao = new SolicitacaoAgg.SolicitacaoCompra(request.UsuarioSolicitante, request.NomeFornecedor, request.CondicaoPagamento);
            foreach (var item in request.Itens)
            {
                solicitacao.AdicionarItem(produtoRepository.Obter(item.ProdutoId), item.Quantidade);
            }
            solicitacao.RegistrarCompra(solicitacao.Itens);            
            solicitaCompraRepository.RegistrarCompra(solicitacao);
            Commit();
            PublishEvents(solicitacao.Events);
            return Task.FromResult(true);
        }
    }
}
