using System;
using System.Collections.Generic;
using System.Text;

namespace Invest.Domain.Entities
{
    public class RendaFixaEntity : InvestimentoEntity
    {
        public int Quantidade { get; set; }
        public decimal OutrasTaxas { get; set; }
        public string Indice { get; set; }
        public bool GuarantidoFGC { get; set; }
        public decimal PrecoUnitario { get; set; }
        public bool Primario { get; set; }
    }
}
