using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIMSAfrica.CORE.Model
{
    public interface IVehicle
    {
         int Id { get; set; }
         string RegistrationNumber { get; set; }
         int VehicleBrandId { get; set; }
         int VehicleModelId { get; set; }
         int ModelYearId { get; set; }
         string Vin { get; set; }
         DateTime VehicleLicenseExpiry { get; set; }
         DateTime MotExpiry { get; set; }
         DateTime DateCreated { get; set; }
         DateTime InsuranceExpiry { get; set; }
         string VehicleOwnerName { get; set; }
         string Mileage { get; set; }
    }
}
