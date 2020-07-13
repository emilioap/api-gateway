using Invest.Infra.Http.HttpResponses;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Invest.Infra.Http
{
    public interface IInvestimentosHttpService
    {
        [Get("/5e3428203000006b00d9632a")]
        Task<IEnumerable<TesouroDiretoHttpResponse>> ObterTesouroDireto();

        [Get("/5e3429a33000008c00d96336")]
        Task<IEnumerable<RendaFixaHttpResponse>> ObterRendaFixa();

        [Get("/5e342ab33000008c00d96342")]
        Task<IEnumerable<FundoHttpResponse>> ObterFundos();
    }
}
