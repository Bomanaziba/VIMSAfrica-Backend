


using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using VIMSAfrica.CORE.Dtos;
using VIMSAfrica.CORE.Model;
using VIMSAfrica.CORE.Model.Impl;
using VIMSAfrica.CORE.Repository;

namespace VIMSAfrica.CORE.Service.Impl
{

    public class AppSettingService : IAppSettingService
    {
        private readonly IAppSettingRepository _appSettingRepository;
        private readonly ILogger<AppSettingService> _logger;

        public AppSettingService(IAppSettingRepository appSettingRepository, ILogger<AppSettingService> logger)
        {
            _appSettingRepository = appSettingRepository;
            _logger = logger;
        }

        public async Task AddAppSetting(AddAppSettingDto appSetting)
        {
            if(appSetting == null) throw new ArgumentNullException();

            try
            {
                IAppSetting app = new AppSetting
                {
                    Key = appSetting.Key,
                    Value = appSetting.Value,
                    DateCreated = DateTime.UtcNow
                };

                await _appSettingRepository.Save(app);
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw e;
            }
        }

        //TODO: 
        public async Task<IAppSetting> GetAppSetting(string key)
        {
            throw new System.NotImplementedException();
        }
    }
}