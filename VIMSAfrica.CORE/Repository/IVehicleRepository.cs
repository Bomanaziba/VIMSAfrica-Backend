using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIMSAfrica.CORE.Dtos;
using VIMSAfrica.CORE.Model;

namespace VIMSAfrica.CORE.Repository
{
    public interface IVehicleRepository
    {
        Task<IVehicle> GetVehicleByRegNumber(string regNumber);
        Task<IVehicle> GetVehicleById(int id);
        Task<IEnumerable<IVehicle>> GetAllVehicle();
        Task AddVehicle(IVehicle vehicle);
        Task RemoveVehicle(int id);
    }
}
