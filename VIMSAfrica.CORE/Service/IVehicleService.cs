using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIMSAfrica.CORE.Dtos;
using VIMSAfrica.CORE.Model;
using VIMSAfrica.CORE.Model.Impl;

namespace VIMSAfrica.CORE.Service
{
    public interface IVehicleService
    {
        Task<PagedListDto<Vehicle>> GetPagedVehicle(int index = 1, int size = 10, string searchParams = "");
        Task<IVehicle> GetVehicleByRegNumber(string regNumber);
        Task AddVehicle(VehicleDto vehicleDto);
        Task RemoveVehicle(int id);
        Task<IVehicle> GetVehicleById(int id);
        Task<IList<Vehicle>> GetVehicles();
    }
}
