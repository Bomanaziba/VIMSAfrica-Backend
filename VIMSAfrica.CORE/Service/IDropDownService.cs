using System.Collections.Generic;
using System.Threading.Tasks;
using VIMSAfrica.CORE.Model;
using VIMSAfrica.CORE.Model.Impl;

namespace VIMSAfrica.CORE.Service
{
    public interface IDropDownService
    {
        Task<IList<Brand>> BrandDropDown();
        Task<IList<VIMSAfrica.CORE.Model.Impl.Model>> ModelDropDown(int brandId);
        Task<IList<Year>> YearDropDown();

    }
    
}