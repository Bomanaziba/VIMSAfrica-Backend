

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using VIMSAfrica.CORE.Model;
using VIMSAfrica.CORE.Model.Impl;
using VIMSAfrica.CORE.Repository;

namespace VIMSAfrica.CORE.Service.Impl
{
    public class DropDownService : IDropDownService
    {
        private readonly IDropDownRepository _dropDownRepository;
        private readonly ILogger<DropDownService> _logger;

        public DropDownService(IDropDownRepository dropDownRepository, ILogger<DropDownService> logger)
        {
            _dropDownRepository = dropDownRepository;
            _logger = logger;
        }

        public Task<IList<Brand>> BrandDropDown()
        {
            try
            {
                return _dropDownRepository.GetBrand();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        public Task<IList<VIMSAfrica.CORE.Model.Impl.Model>> ModelDropDown(int brandId)
        {
            try
            {
                return _dropDownRepository.GetModel(brandId);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        public Task<IList<Year>> YearDropDown()
        {
            try
            {
                return _dropDownRepository.GetYear();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }
    }
}