using Invest.Domain.Entities;
using Invest.Domain.Interfaces;
using Invest.Domain.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invest.Service.Services
{
    public class ConsolidadoService : IConsolidadoService
    {
        private readonly IInvestimentoRepository investimentoRepository;
        public ConsolidadoService(IInvestimentoRepository investimentoRepository)
        {
            this.investimentoRepository = investimentoRepository;
        }

        public async Task<ExtratoConsolidadoEntity> ObterExtratoConsolidado()
        {
            var investimentos = new List<InvestimentoConsolidadoEntity>();

            var tesouros = await this.investimentoRepository.ObterTesouros();
            tesouros.ToList().ForEach(x => investimentos.Add(MapearInvestimentoParaConsolidado(x)));

            var fundos = await this.investimentoRepository.ObterFundos();
            fundos.ToList().ForEach(x => investimentos.Add(MapearInvestimentoParaConsolidado(x)));

            var rendaFixa = await this.investimentoRepository.ObterRendaFixa();
            rendaFixa.ToList().ForEach(x => investimentos.Add(MapearInvestimentoParaConsolidado(x)));

            return new ExtratoConsolidadoEntity()
            {
                TotalInvestido = investimentos.Select(x => x.ValorInvestido).Sum(),
                Investimentos = investimentos
            };
        }

        private InvestimentoConsolidadoEntity MapearInvestimentoParaConsolidado(InvestimentoEntity investimento) 
        {
            return new InvestimentoConsolidadoEntity(investimento.Tipo, investimento.DataAplicacao)
            {
                Nome = investimento.Nome,
                ValorInvestido = investimento.ValorInvestido,
                ValorTotal = investimento.ValorAtual,
                Vencimento = investimento.DataVencimento
            };
        }
    }
}
