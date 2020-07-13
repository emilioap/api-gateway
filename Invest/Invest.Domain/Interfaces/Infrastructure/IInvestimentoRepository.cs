using Invest.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Invest.Domain.Interfaces.Infrastructure
{
    public interface IInvestimentoRepository
    {
        Task<IEnumerable<FundoEntity>> ObterFundos();
        Task<IEnumerable<RendaFixaEntity>> ObterRendaFixa();
        Task<IEnumerable<TesouroDiretoEntity>> ObterTesouros();
    }
}
