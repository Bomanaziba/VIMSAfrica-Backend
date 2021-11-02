

using System.Threading.Tasks;
using VIMSAfrica.CORE.Model;

namespace VIMSAfrica.CORE.Repository
{
    public interface IBrandRepository
    {
        Task Save(IBrand model);
        Task Delete(int id);
    }
    
}