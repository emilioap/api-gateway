using System;
using System.Collections.Generic;
using System.Text;

namespace Invest.Domain.Entities
{
    public class FundoEntity : InvestimentoEntity
    {
        public decimal TotalTaxas { get; set; }
        public int Quantidade { get; set; }
    }
}
