using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIMSAfrica.CORE.Model;
using VIMSAfrica.CORE.Model.Impl;

namespace VIMSAfrica.CORE.Repository.Impl
{
    public class VehicleRepository:IVehicleRepository
    {
        private readonly ILogger<VehicleRepository> _logger;

        private readonly IConfiguration _config;

        public VehicleRepository(IConfiguration config, ILogger<VehicleRepository> logger)
        {
            _config = config;
            _logger = logger;
        }
        public async Task<IEnumerable<IVehicle>> GetAllVehicle()
        {

            try
            {

                using (IDbConnection conn = new SqlConnection(_config.GetConnectionString("Default")))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    var record = await conn.QueryMultipleAsync("[dbo].[usp_get_vehicles]", commandType: CommandType.StoredProcedure);
                    var result = await record.ReadAsync<Vehicle>();
                    return result.AsList();
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw e;
            }

        }
        public async Task<IVehicle> GetVehicleById(int id)
        {
            if (id < 1) throw new ArgumentOutOfRangeException(nameof(id));

            try
            {

                using (IDbConnection conn = new SqlConnection(_config.GetConnectionString("Default")))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    DynamicParameters parameters = new DynamicParameters();

                    parameters.Add("@Id", id);
                    //TODO: add SP

                    var record = conn.QueryFirstOrDefault<Vehicle>("[dbo].[usp_get_vehicle_by_id]", parameters, commandType: CommandType.StoredProcedure);

                    return record;
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw e;
            }

        }
        public async Task<IVehicle> GetVehicleByRegNumber(string regNumber)
        {
            if (regNumber == null) throw new ArgumentNullException(nameof(regNumber));

            try
            {

                using (IDbConnection conn = new SqlConnection(_config.GetConnectionString("Default")))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    DynamicParameters parameters = new DynamicParameters();

                    parameters.Add("@regNumber", regNumber);
                    //TODO: add SP

                    var record = conn.QueryFirstOrDefault<Vehicle>("[dbo].[usp_get_vehicle_by_regnumber]", parameters, commandType: CommandType.StoredProcedure);

                    return record;
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw e;
            }

        }

        public async Task AddVehicle(IVehicle addVehicle)
        {

            using (IDbConnection con = new SqlConnection(_config.GetConnectionString("Default")))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@RegistrationNumber", addVehicle.RegistrationNumber);
                parameters.Add("@Vin", addVehicle.Vin);
                parameters.Add("@VehicleOwnerName", addVehicle.VehicleOwnerName);
                parameters.Add("@VehicleModelId", addVehicle.VehicleModelId);
                parameters.Add("@VehicleBrandId", addVehicle.VehicleBrandId);
                parameters.Add("@VehicleLicenseExpiry", addVehicle.VehicleLicenseExpiry);
                parameters.Add("@ModelYearId", addVehicle.ModelYearId);
                parameters.Add("@Mileage", addVehicle.Mileage);
                parameters.Add("@InsuranceExpiry", addVehicle.InsuranceExpiry);
                parameters.Add("@MotExpiry", addVehicle.MotExpiry);
                parameters.Add("@InsuranceExpiry", addVehicle.InsuranceExpiry);
                parameters.Add("@DateCreated", DateTime.Now);
                con.Execute("[dbo].[usp_Insert_Vehicle]", parameters, commandType: CommandType.StoredProcedure);
                con.Close();

            }
        }
            
        public async Task RemoveVehicle(int id)
        {

            using (IDbConnection con = new SqlConnection(_config.GetConnectionString("Default")))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                
                con.Execute("[dbo].[usp_Delete_Vehicle]", parameters, commandType: CommandType.StoredProcedure);
                con.Close();

            }



        }


    }
}
