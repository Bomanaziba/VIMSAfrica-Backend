


using System;
using System.Data;
using System.Threading.Tasks;
using VIMSAfrica.CORE.Model;
using Microsoft.Extensions.Logging;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace VIMSAfrica.CORE.Repository.Impl
{

    public class BrandRepository : IBrandRepository
    {
        
        private readonly ILogger<BrandRepository> _logger;

        private readonly IConfiguration _config;

        public BrandRepository(IConfiguration config, ILogger<BrandRepository> logger)
        {
            _config = config;
            _logger = logger;
        }

        public async Task Save(IBrand brand)
        {
            if (brand == null) throw new ArgumentNullException(nameof(brand));

            try
            {

                using (IDbConnection conn = new SqlConnection(_config.GetConnectionString("Default")))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    DynamicParameters parameters = new DynamicParameters();

                    parameters.Add("@Id", brand.Id);
                    parameters.Add("@Name", brand.Name);
                    parameters.Add("@Icon", brand.Icon);
                    
                    var respone = await conn.ExecuteAsync("[dbo].[usp_Insert_Brand]", parameters, commandType: CommandType.StoredProcedure);
                    
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw e;
            }
        }

        public async Task Delete(int id)
        {
            if (id <= 0) throw new ArgumentNullException(nameof(id));

            try
            {

                using (IDbConnection conn = new SqlConnection(_config.GetConnectionString("Default")))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    DynamicParameters parameters = new DynamicParameters();

                    parameters.Add("@Id", id);
                    
                    var respone = await conn.ExecuteAsync("[dbo].[usp_Delete_Brand]", parameters, commandType: CommandType.StoredProcedure);
                    
                    conn.Close();
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