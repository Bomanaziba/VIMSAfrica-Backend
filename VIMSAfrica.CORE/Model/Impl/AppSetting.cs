
using System;

namespace VIMSAfrica.CORE.Model.Impl
{

    public class AppSetting : IAppSetting
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
    
}