using Invest.Domain.Entities;
using Invest.Infra.Http.HttpResponses;

namespace Invest.Infra.Data.Mappers
{
    public class MapearResponseParaEntity
    {
        public static FundoEntity MapearFundo(FundoHttpResponse fundoHttpResponse)
        {
            return new FundoEntity()
            {
                Nome = fundoHttpResponse.Nome,
                Tipo = fundoHttpResponse.Tipo,
                ValorInvestido = fundoHttpResponse.ValorInvestido,
                ValorAtual = fundoHttpResponse.ValorAtual,
                DataAplicacao = fundoHttpResponse.DataAplicacao,
                DataVencimento = fundoHttpResponse.DataVencimento,
                IOF = fundoHttpResponse.IOF,
                Quantidade = fundoHttpResponse.Quantidade,
                TotalTaxas = fundoHttpResponse.TotalTaxas
            };
        }

        public static RendaFixaEntity MapearRendaFixa(RendaFixaHttpResponse rendaFixaHttpResponse)
        {
            return new RendaFixaEntity
            {
                Nome = rendaFixaHttpResponse.Nome,
                Tipo = rendaFixaHttpResponse.Tipo,
                ValorInvestido = rendaFixaHttpResponse.ValorInvestido,
                ValorAtual = rendaFixaHttpResponse.ValorAtual,
                DataAplicacao = rendaFixaHttpResponse.DataAplicacao,
                DataVencimento = rendaFixaHttpResponse.DataVencimento,
                IOF = rendaFixaHttpResponse.IOF,
                Quantidade = rendaFixaHttpResponse.Quantidade,
                OutrasTaxas = rendaFixaHttpResponse.OutrasTaxas,
                Indice = rendaFixaHttpResponse.Indice,
                GuarantidoFGC = rendaFixaHttpResponse.GuarantidoFGC,
                PrecoUnitario = rendaFixaHttpResponse.PrecoUnitario,
                Primario = rendaFixaHttpResponse.Primario
            };
        }

        public static TesouroDiretoEntity MapearTesouroDireto(TesouroDiretoHttpResponse tesouroDiretoHttpResponse)
        {
            return new TesouroDiretoEntity
            {
                Nome = tesouroDiretoHttpResponse.Nome,
                Tipo = tesouroDiretoHttpResponse.Tipo,
                ValorInvestido = tesouroDiretoHttpResponse.ValorInvestido,
                ValorAtual = tesouroDiretoHttpResponse.ValorAtual,
                DataAplicacao = tesouroDiretoHttpResponse.DataAplicacao,
                DataVencimento = tesouroDiretoHttpResponse.DataVencimento,
                IOF = tesouroDiretoHttpResponse.IOF,
                Indice = tesouroDiretoHttpResponse.Indice
            };
        }

    }
}
