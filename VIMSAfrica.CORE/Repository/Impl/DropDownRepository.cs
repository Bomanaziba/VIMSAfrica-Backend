

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using VIMSAfrica.CORE.Model;
using VIMSAfrica.CORE.Model.Impl;

namespace VIMSAfrica.CORE.Repository.Impl
{
    public class DropDownRepository : IDropDownRepository
    {
        private readonly IConfiguration _config;
        private readonly ILogger<DropDownRepository> _logger;
        public DropDownRepository(IConfiguration config, ILogger<DropDownRepository> logger)
        {
            _config = config;
            _logger = logger;
        }
        public async Task<IList<Brand>> GetBrand()
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(_config.GetConnectionString("Default")))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    var record = await conn.QueryAsync<Brand>("[dbo].[usp_get_brands]", commandType: CommandType.StoredProcedure);

                    return record.ToList();
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw e;
            }


        }
        public async Task<IList<Model.Impl.Model>> GetModel(int brandId)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(_config.GetConnectionString("Default")))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    DynamicParameters parameters = new DynamicParameters();

                    parameters.Add("@brandId", brandId);

                    var record = await conn.QueryAsync<Model.Impl.Model>("[dbo].[usp_get_models]", param: parameters, commandType: CommandType.StoredProcedure);

                    return record.ToList();
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw e;
            }
        }
        public async Task<IList<Year>> GetYear()
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(_config.GetConnectionString("Default")))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    var record = await conn.QueryAsync<Year>("[dbo].[usp_get_years]", commandType: CommandType.StoredProcedure);

                    return record.ToList();
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