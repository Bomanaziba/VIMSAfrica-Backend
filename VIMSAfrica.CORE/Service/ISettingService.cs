


using System.Threading.Tasks;
using VIMSAfrica.CORE.Model;

namespace VIMSAfrica.CORE.Service
{
    public interface ISettingService
    {
        Task AddBrand(IBrand brand);
        Task RemoveBrand(int brandId);

        Task AddModel(Model.IModel model);
        Task RemoveModel(int modelId);
    }
    
}