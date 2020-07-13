using Invest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Invest.Domain.Interfaces
{
    public interface IConsolidadoService
    {
        Task<ExtratoConsolidadoEntity> ObterExtratoConsolidado();
    }
}
