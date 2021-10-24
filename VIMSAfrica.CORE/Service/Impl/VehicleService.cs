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

        private readonly IVehicleRepository _vehicleRepo;
        private readonly ILogger<AppSettingService> _logger;


        public Task<IVehicle> GetVehicleByRegNumber(string regNumber)
        {
            try
            {
                var record = _vehicleRepo.GetVehicleByRegNumber(regNumber);
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
                var record = _vehicleRepo.GetVehicleById(id);
                return record;
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

                await _vehicleRepo.AddVehicle(vehicle);

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
    }
}
