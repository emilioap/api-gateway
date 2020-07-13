using Invest.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Text;

namespace Invest.Infra.Http.HttpResponses
{
    public class FundoHttpResponse
    {
        public string Nome { get; set; }
        public InvestimentoEnum Tipo { get; set; }
        public decimal ValorInvestido { get; set; }
        public decimal ValorAtual { get; set; }
        public DateTime DataAplicacao { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal IOF { get; set; }

        public decimal TotalTaxas { get; set; }
        public int Quantidade { get; set; }
    }
}
