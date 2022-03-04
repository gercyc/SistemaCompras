using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SolicitacaoCompraAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;
using ProdutoAgg = SistemaCompra.Domain.ProdutoAggregate;

namespace SistemaCompra.Infra.Data.SolicitacaoCompra
{
    public class ItemSolicitacaoCompraConfiguration: IEntityTypeConfiguration<SolicitacaoCompraAgg.Item>
    {
        public void Configure(EntityTypeBuilder<SolicitacaoCompraAgg.Item> builder)
        {
            builder.ToTable("ItemSolicitacaoCompra");
            builder.HasKey(t => t.Id);
            builder.OwnsOne(c => c.Subtotal, b => b.Property("Value").HasColumnName("Subtotal").HasColumnType("decimal(18,2)"));            
        }
    }
}
