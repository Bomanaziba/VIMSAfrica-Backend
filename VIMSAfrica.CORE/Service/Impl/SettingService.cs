


using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using VIMSAfrica.CORE.Dtos;
using VIMSAfrica.CORE.Model;
using VIMSAfrica.CORE.Model.Impl;
using VIMSAfrica.CORE.Repository;

namespace VIMSAfrica.CORE.Service.Impl
{

    public class SettingService : ISettingService
    {
        private readonly ILogger<SettingService> _logger;
        private readonly IBrandRepository _brandRepository;
        private readonly IModelRepository _modelRepository;

        public SettingService(ILogger<SettingService> logger, IBrandRepository brandRepository,
        IModelRepository modelRepository)
        {
            _logger = logger;
            _brandRepository = brandRepository;
            _modelRepository = modelRepository;
        }

        public async Task AddBrand(IBrand brand)
        {

            if(brand == null) throw new ArgumentNullException(nameof(brand));

            try
            {
                await _brandRepository.Save(brand);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }

        }

        public async Task RemoveBrand(int brandId)
        {

            if(brandId <= 0) throw new ArgumentNullException(nameof(brandId));

            try
            {
                await _brandRepository.Delete(brandId);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }

        }

        public async Task AddModel(Model.IModel model)
        {

            if(model == null) new ArgumentNullException(nameof(model));

            try
            {
                await _modelRepository.Save(model);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }

        }

        public async Task RemoveModel(int modelId)
        {

            if(modelId <= 0) throw new ArgumentNullException(nameof(modelId));

            try
            {
                await _modelRepository.Delete(modelId);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }

        }
        
    }
}