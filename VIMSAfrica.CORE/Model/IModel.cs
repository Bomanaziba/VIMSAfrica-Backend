

namespace VIMSAfrica.CORE.Model
{
    public interface IModel
    {
        int Id { get; set; }
        string Name { get; set; }
        int BrandId { get; set; }
    }
    
}