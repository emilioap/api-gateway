using Invest.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Text;

namespace Invest.Domain.Entities
{
    public class InvestimentoConsolidadoEntity
    {
        private decimal _ir;
        private decimal _valorResgate;
        private DateTime _dataAplicacao;
        private InvestimentoEnum _tipo;

        public InvestimentoConsolidadoEntity(InvestimentoEnum tipo, DateTime dataAplicacao)
        {
            this._dataAplicacao = dataAplicacao;
            this._tipo = tipo;
        }

        public string Nome { get; set; }
        public decimal ValorInvestido { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime Vencimento { get; set; }
        public decimal IR {
            get { return this._ir; }
            private set { _ir = CalcularIR(this._tipo); }
        }
        public decimal ValorResgate {
            get { return this._valorResgate; }
            private set { this._valorResgate = CalcularValorResgate(this._dataAplicacao); }
        }

        private decimal CalcularIR(InvestimentoEnum tipo)
        {
            var rentabilidade = ValorTotal - ValorInvestido;
            if (rentabilidade > 0)
            {
                switch (tipo)
                {
                    case InvestimentoEnum.TD:
                        return rentabilidade * (decimal)0.1;
                    case InvestimentoEnum.LCI:
                        return rentabilidade * (decimal)0.05;
                    case InvestimentoEnum.Fundos:
                        return rentabilidade * (decimal)0.15;
                    default:
                        return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        private decimal CalcularValorResgate(DateTime dataAplicacao)
        {
            var dataHoje = new DateTime();
            var tempoTotalAplicacao = (Vencimento - dataAplicacao).TotalDays;
            var tempoCustodia = (dataHoje - dataAplicacao).TotalDays;
            var diferencaTempoTotalETempoCustodia = tempoTotalAplicacao - tempoCustodia;

            switch (diferencaTempoTotalETempoCustodia)
            {
                case double n when (n <= 90):
                    return ValorInvestido * (decimal)0.06;
                case double n when (n > tempoTotalAplicacao / 2):
                    return ValorInvestido * (decimal)0.15;
                default:
                    return ValorInvestido * (decimal)0.3;
            }
        }
    }
}
