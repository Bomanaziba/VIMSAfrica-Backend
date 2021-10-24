using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIMSAfrica.CORE.Model.Impl
{
    public class Vehicle:IVehicle
    {
        public int Id { get; set; }
        public string RegistrationNumber { get; set; }
        public int VehicleBrandId { get; set; }
        public int VehicleModelId { get; set; }
        public int ModelYearId { get; set; }
        public string Vin { get; set; }
        public DateTime VehicleLicenseExpiry { get; set; }
        public DateTime MotExpiry { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime InsuranceExpiry { get; set; }
        public string VehicleOwnerName { get; set; }
        public string Mileage { get; set; }
    }
}
