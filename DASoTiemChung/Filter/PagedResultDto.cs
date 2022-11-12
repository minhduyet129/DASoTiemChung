using System;
using System.Collections.Generic;

namespace DASoTiemChung.Filter
{
    public class PagedResultDto<T> where T : class
    {
        public PagedResultDto() 
        {
        }

        public PagedResultDto(long totalCount,int skipCount,int maxResultCount, List<T> items) 
        {
            TotalCount = totalCount;
            Items=items;
            SkipCount = skipCount;
            MaxResultCount = maxResultCount;
        }

       
        public List<T> Items { get; set; }
        public long TotalCount { get; set; }
        public int PageCount { get => TotalCount > 0 ? (int)Math.Ceiling(TotalCount / (double)MaxResultCount) : 0; }
        public int SkipCount { get; set; }
        public int MaxResultCount { get; set; }
        public bool HasPreviousPage { get => SkipCount > 1; }
        public bool HasNextPage { get => SkipCount < PageCount; }
    }
}
