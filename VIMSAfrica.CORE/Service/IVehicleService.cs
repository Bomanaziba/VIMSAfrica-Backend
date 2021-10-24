using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIMSAfrica.CORE.Dtos;
using VIMSAfrica.CORE.Model;

namespace VIMSAfrica.CORE.Service
{
    public interface IVehicleService
    {
        Task<IVehicle> GetVehicleByRegNumber(string regNumber);
        Task AddVehicle(VehicleDto vehicleDto);
        Task UpdateVehicle(VehicleDto vehicleDto);
        Task<IVehicle> GetVehicleById(int id);
    }
}
