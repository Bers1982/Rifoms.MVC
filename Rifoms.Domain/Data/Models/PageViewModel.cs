using Rifoms.Domain.Data.Models.Base;

using System;

namespace Rifoms.Domain.Data.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class PageViewModel: BaseModel
    {
        public int PageNumber { get; private set; }
        public int TotalPages { get; private set; }
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;
        public PageViewModel(int count,int pageNumber,int pageSize)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }
    }
}
