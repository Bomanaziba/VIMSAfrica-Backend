

using System.Threading.Tasks;

namespace VIMSAfrica.CORE.Repository
{
    public interface IModelRepository
    {
        Task Save(Model.IModel model);
        Task Delete(int id);
    }
    
}