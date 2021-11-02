

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

    public class ModelRepository : IModelRepository
    {
        
        private readonly ILogger<ModelRepository> _logger;

        private readonly IConfiguration _config;

        public ModelRepository(IConfiguration config, ILogger<ModelRepository> logger)
        {
            _config = config;
            _logger = logger;
        }

        public async Task Save(Model.IModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            try
            {

                using (IDbConnection conn = new SqlConnection(_config.GetConnectionString("Default")))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    DynamicParameters parameters = new DynamicParameters();

                    parameters.Add("@Id", model.Id);
                    parameters.Add("@Name", model.Name);
                    parameters.Add("@BrandId", model.BrandId);
                    
                    //TODO: add SP
                    var respone = await conn.ExecuteAsync("[dbo].[usp_Insert_Model]", parameters, commandType: CommandType.StoredProcedure);
                    
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
                    
                    var respone = await conn.ExecuteAsync("[dbo].[usp_Delete_Model]", parameters, commandType: CommandType.StoredProcedure);
                    
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