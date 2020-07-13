using System;
using System.Collections.Generic;
using System.Text;

namespace Invest.Domain.Entities
{
    public class ExtratoConsolidadoEntity
    {
        public decimal TotalInvestido { get; set; }
        public List<InvestimentoConsolidadoEntity> Investimentos { get; set; }
    }
}
