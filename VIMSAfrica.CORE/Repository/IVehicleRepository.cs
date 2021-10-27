using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIMSAfrica.CORE.Dtos;
using VIMSAfrica.CORE.Model;
using VIMSAfrica.CORE.Model.Impl;

namespace VIMSAfrica.CORE.Repository
{
    public interface IVehicleRepository
    {
        Task<IList<Vehicle>> GetPagedVehicle(int index, int size, string searchParams = "");
        Task<int> GetVehicleCount(string  searchParams);
        Task<IVehicle> GetVehicleByRegNumber(string regNumber);
        Task<IVehicle> GetVehicleById(int id);
        Task<IList<Vehicle>> GetAllVehicle();
        Task AddVehicle(IVehicle vehicle);
        Task RemoveVehicle(int id);
    }
}
