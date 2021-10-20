

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

    public class AppSettingRepository : IAppSettingRepository
    {

        private readonly ILogger<AppSettingRepository> _logger;

        private readonly IConfiguration _config;

        public AppSettingRepository(IConfiguration config, ILogger<AppSettingRepository> logger)
        {
            _config = config;
            _logger = logger;
        }

        public async Task Save(IAppSetting appSetting)
        {
            if (appSetting == null) throw new ArgumentNullException(nameof(appSetting));

            try
            {

                using (IDbConnection conn = new SqlConnection(_config.GetConnectionString("Default")))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    DynamicParameters parameters = new DynamicParameters();

                    parameters.Add("@Id", appSetting.Id);
                    parameters.Add("@key", appSetting.Key);
                    parameters.Add("@value", appSetting.Value);
                    parameters.Add("@datecreated", appSetting.DateCreated);
                    
                    //TODO: add SP
                    var respone = await conn.ExecuteAsync("[dbo].[usp_Insert_AppSetting]", parameters, commandType: CommandType.StoredProcedure);
                    
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