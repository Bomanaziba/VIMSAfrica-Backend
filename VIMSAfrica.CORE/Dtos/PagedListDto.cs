using System.Collections.Generic;

namespace VIMSAfrica.CORE.Dtos
{

    public class PagedListDto<T> where T : class
    {
        public IList<T> Items { get; set; }
        public int Index { get; set; }
        public int Size { get; set; }
        public int Total { get; set; }
    }
    
}