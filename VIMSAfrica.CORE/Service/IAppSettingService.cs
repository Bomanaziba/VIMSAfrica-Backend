


using System.Threading.Tasks;
using VIMSAfrica.CORE.Dtos;
using VIMSAfrica.CORE.Model;

namespace VIMSAfrica.CORE.Service
{
    
    public interface IAppSettingService
    {
        Task AddAppSetting(AddAppSettingDto appSetting);
        
        Task<IAppSetting> GetAppSetting(string key);

    }
}