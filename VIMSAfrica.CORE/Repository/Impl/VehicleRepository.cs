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
using VIMSAfrica.CORE.Dtos;
using VIMSAfrica.CORE.Model;
using VIMSAfrica.CORE.Model.Impl;

namespace VIMSAfrica.CORE.Repository.Impl
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ILogger<VehicleRepository> _logger;

        private readonly IConfiguration _config;

        public VehicleRepository(IConfiguration config, ILogger<VehicleRepository> logger)
        {
            _config = config;
            _logger = logger;
        }

    
        public async Task<IList<Vehicle>> GetPagedVehicle(int index, int size, string searchParams = "")
        {

            try
            {
                using (IDbConnection conn = new SqlConnection(_config.GetConnectionString("Default")))
                {
                    var dynamicParameters = new DynamicParameters();

                    dynamicParameters.Add("@offset", index);
                    dynamicParameters.Add("@pageSize", size);
                    dynamicParameters.Add("@searchParams", searchParams);

                    if (conn.State == ConnectionState.Closed) conn.Open();

                    var record = await conn.QueryAsync<Vehicle>("[dbo].[usp_get_paged_vehicle]",  param: dynamicParameters, commandType: CommandType.StoredProcedure);

                   return record.ToList();
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);

                throw e;
            }
        }

        public async Task<int> GetVehicleCount(string  searchParams = "")
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(_config.GetConnectionString("Default")))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    var dynamicParameters = new DynamicParameters();

                    dynamicParameters.Add("@searchParams", searchParams);

                    return await conn.QueryFirstAsync<int>("[dbo].[usp_get_vehicle_count]", param: dynamicParameters, commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);

                throw e;
            }

        }
        

        public async Task<IList<Vehicle>> GetAllVehicle()
        {

            try
            {
                using (IDbConnection conn = new SqlConnection(_config.GetConnectionString("Default")))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    var record = await conn.QueryAsync<Vehicle>("[dbo].[usp_get_vehicles]", commandType: CommandType.StoredProcedure);

                    return record.ToList();
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
            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));

            try
            {
                using (IDbConnection conn = new SqlConnection(_config.GetConnectionString("Default")))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    DynamicParameters parameters = new DynamicParameters();

                    parameters.Add("@Id", id);

                    var record = await conn.QueryFirstOrDefaultAsync<Vehicle>("[dbo].[usp_get_vehicle_by_id]", parameters, commandType: CommandType.StoredProcedure);

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

                    var record = await conn.QueryFirstOrDefaultAsync<Vehicle>("[dbo].[usp_get_vehicle_by_regnumber]", parameters, commandType: CommandType.StoredProcedure);

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

            try
            {
                using (IDbConnection con = new SqlConnection(_config.GetConnectionString("Default")))
                {
                    if (con.State == ConnectionState.Closed) con.Open();

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

                    await con.ExecuteAsync("[dbo].[usp_Insert_Vehicle]", param: parameters, commandType: CommandType.StoredProcedure);
                    
                    con.Close();
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw e;
            }
        }

        public async Task RemoveVehicle(int id)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(_config.GetConnectionString("Default")))
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    DynamicParameters parameters = new DynamicParameters();

                    parameters.Add("@Id", id);

                    await con.ExecuteAsync("[dbo].[usp_Delete_Vehicle]", parameters, commandType: CommandType.StoredProcedure);
                    
                    con.Close();
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw e;
            }
        }
    }
}
