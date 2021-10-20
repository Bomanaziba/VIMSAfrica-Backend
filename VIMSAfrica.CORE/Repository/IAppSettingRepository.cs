

using System.Threading.Tasks;
using VIMSAfrica.CORE.Model;

namespace VIMSAfrica.CORE.Repository
{

    public interface IAppSettingRepository
    {
        Task Save(IAppSetting appSetting);
    }
    
}