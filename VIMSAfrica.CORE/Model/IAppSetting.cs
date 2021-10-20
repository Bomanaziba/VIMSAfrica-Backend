
using System;

namespace VIMSAfrica.CORE.Model
{

    public interface IAppSetting
    {
        int Id { get; set; }
        string Key { get; set; }
        string Value { get; set; }
        DateTime DateCreated { get; set; }
        DateTime DateModified { get; set; }
    }
    
}