using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIMSAfrica.CORE.Dtos;
using VIMSAfrica.CORE.Model;
using VIMSAfrica.CORE.Model.Impl;
using VIMSAfrica.CORE.Repository;

namespace VIMSAfrica.CORE.Service.Impl
{
    public class VehicleService:IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ILogger<AppSettingService> _logger;

        public VehicleService(IVehicleRepository vehicleRepository, ILogger<AppSettingService> logger)
        {
            _vehicleRepository = vehicleRepository;
            _logger = logger;
        }

        public async Task<PagedListDto<Vehicle>> GetPagedVehicle(int index = 1, int size = 10, string searchParams = "")
        {
            try
            {
                var items = await _vehicleRepository.GetPagedVehicle(index, size, searchParams);

                var total = await _vehicleRepository.GetVehicleCount(searchParams);

                return new PagedListDto<Vehicle>
                {
                    Items = items,
                    Index = index,
                    Size = size,
                    Total = total
                };
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public async Task<IVehicle> GetVehicleByRegNumber(string regNumber)
        {
            try
            {
                var record = await _vehicleRepository.GetVehicleByRegNumber(regNumber);

                return record;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }


        public Task<IVehicle> GetVehicleById(int id)
        {
            try
            {
                var record = _vehicleRepository.GetVehicleById(id);
                return record;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public Task<IList<Vehicle>> GetVehicles()
        {
            try
            {
                var record = _vehicleRepository.GetAllVehicle();

                return record;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
        public async Task RemoveVehicle(int id)
        {
            try
            {
                
                await _vehicleRepository.RemoveVehicle(id);

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
        public async Task AddVehicle(VehicleDto vehicleDto)
        {
            try
            {
                IVehicle vehicle = new Vehicle
                {
                    InsuranceExpiry = vehicleDto.InsuranceExpiry,
                    Vin = vehicleDto.Vin,
                    VehicleOwnerName = vehicleDto.VehicleOwnerName,
                    VehicleModelId = vehicleDto.VehicleModelId,
                    VehicleLicenseExpiry = vehicleDto.VehicleLicenseExpiry,
                    VehicleBrandId = vehicleDto.VehicleBrandId,
                    ModelYearId = vehicleDto.ModelYearId,
                    RegistrationNumber = vehicleDto.RegistrationNumber,
                    MotExpiry = vehicleDto.MotExpiry,
                    Mileage = vehicleDto.Mileage,
                    DateCreated = DateTime.UtcNow
                };

                await _vehicleRepository.AddVehicle(vehicle);

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
    }
}
