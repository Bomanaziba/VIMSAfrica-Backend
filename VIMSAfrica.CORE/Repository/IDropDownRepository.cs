
using System.Collections.Generic;
using System.Threading.Tasks;
using VIMSAfrica.CORE.Model;
using VIMSAfrica.CORE.Model.Impl;

namespace VIMSAfrica.CORE.Repository
{
    public interface IDropDownRepository
    {
        Task<IList<Brand>> GetBrand();
        Task<IList<Model.Impl.Model>> GetModel(int brandId);
        Task<IList<Year>> GetYear();
    }
}