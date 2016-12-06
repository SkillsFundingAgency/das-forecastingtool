﻿using System;
using System.Linq;
using System.Threading.Tasks;
using SFA.DAS.ForecastingTool.Web.Infrastructure.Caching;

namespace SFA.DAS.ForecastingTool.Web.Standards
{
    public class CachedStandardsRepository : IStandardsRepository
    {
        private readonly IStandardsRepository _innerRepository;
        private readonly ICacheProvider _cacheProvider;

        public CachedStandardsRepository(IStandardsRepository innerRepository, ICacheProvider cacheProvider)
        {
            _innerRepository = innerRepository;
            _cacheProvider = cacheProvider;
        }

        public async Task<Standard[]> GetAllAsync()
        {
            var standards = _cacheProvider.Get<Standard[]>(CacheKeys.Standards);
            if (standards == null)
            {
                standards = await _innerRepository.GetAllAsync();
                if (standards.Length > 0)
                {
                    _cacheProvider.Set(CacheKeys.Standards, standards, new TimeSpan(6, 0, 0));
                }
            }
            return standards;
        }

        public async Task<Standard> GetByCodeAsync(int code)
        {
            var standards = await GetAllAsync();
            return standards.SingleOrDefault(s => s.Code == code);
        }
    }
}