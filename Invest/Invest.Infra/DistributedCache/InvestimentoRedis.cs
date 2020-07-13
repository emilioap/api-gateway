using Invest.Domain.Entities;
using Invest.Domain.Interfaces.Infrastructure;
using Invest.Infra.Data.Mappers;
using Invest.Infra.Http;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invest.Infra.Data.Repository
{
    public class InvestimentoRedis : IInvestimentoRepository
    {

        private readonly IDistributedCache distributedCache;
        private readonly IInvestimentosHttpService investimentosHttpService;
        private const string KEY_FUNDOS = "FUNDOS";
        private const string KEY_RENDAFIXA = "RENDAFIXA";
        private const string KEY_TESOURODIRETO = "TESOURODIRETO";
        private readonly DistributedCacheEntryOptions cacheSettings;

        public InvestimentoRedis(IDistributedCache distributedCache)
        {
            this.distributedCache = distributedCache;
            this.cacheSettings = new DistributedCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromDays(1));
        }

        public async Task<IEnumerable<FundoEntity>> ObterFundos()
        {
            var dataCache = await this.distributedCache.GetStringAsync(KEY_FUNDOS);

            if (string.IsNullOrWhiteSpace(dataCache))
            {
                var fundoHttpResponse = await investimentosHttpService.ObterFundos();

                var fundoEntity = new List<FundoEntity>();

                fundoHttpResponse.ToList().ForEach(x => fundoEntity.Add(MapearResponseParaEntity.MapearFundo(x)));

                await this.distributedCache.SetStringAsync(KEY_FUNDOS, JsonConvert.SerializeObject(fundoEntity), this.cacheSettings);

                return await Task.FromResult(fundoEntity);
            }

            var fundosCache = JsonConvert.DeserializeObject<IEnumerable<FundoEntity>>(dataCache);

            return await Task.FromResult(fundosCache);
        }

        public async Task<IEnumerable<RendaFixaEntity>> ObterRendaFixa()
        {
            var dataCache = await this.distributedCache.GetStringAsync(KEY_RENDAFIXA);

            if (string.IsNullOrWhiteSpace(dataCache))
            {
                var rendaFixaHttpResponse = await investimentosHttpService.ObterRendaFixa();

                var rendaFixaEntity = new List<RendaFixaEntity>();

                rendaFixaHttpResponse.ToList().ForEach(x => rendaFixaEntity.Add(MapearResponseParaEntity.MapearRendaFixa(x)));

                await this.distributedCache.SetStringAsync(KEY_FUNDOS, JsonConvert.SerializeObject(rendaFixaEntity), this.cacheSettings);

                return await Task.FromResult(rendaFixaEntity);
            }

            var rendaFixaCache = JsonConvert.DeserializeObject<IEnumerable<RendaFixaEntity>>(dataCache);

            return await Task.FromResult(rendaFixaCache);
        }

        public async Task<IEnumerable<TesouroDiretoEntity>> ObterTesouros()
        {
            var dataCache = await this.distributedCache.GetStringAsync(KEY_TESOURODIRETO);

            if (string.IsNullOrWhiteSpace(dataCache))
            {
                var tesouroHttpResponse = await investimentosHttpService.ObterTesouroDireto();

                var tesouroEntity = new List<TesouroDiretoEntity>();

                tesouroHttpResponse.ToList().ForEach(x => tesouroEntity.Add(MapearResponseParaEntity.MapearTesouroDireto(x)));

                await this.distributedCache.SetStringAsync(KEY_FUNDOS, JsonConvert.SerializeObject(tesouroEntity), this.cacheSettings);

                return await Task.FromResult(tesouroEntity);
            }

            var rendaFixaCache = JsonConvert.DeserializeObject<IEnumerable<TesouroDiretoEntity>>(dataCache);

            return await Task.FromResult(rendaFixaCache);
        }
    }
}
