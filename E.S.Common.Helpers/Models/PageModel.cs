using System;
using System.Collections.Generic;
using System.Linq;

namespace E.S.Common.Helpers.Models
{
    public class PageModel<T>
    {
        #region Constructor
        public PageModel(IEnumerable<T> items, int totalRecords = 0, int pageNumber = 0, int pageSize = 50)
        {
            Items = items;
            PageNumber = pageNumber;
            TotalRecords = totalRecords;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);
        }

        public PageModel()
        {
            Items = new System.Collections.Generic.List<T>();
        } 
        #endregion

        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public bool HasPrevious => (PageNumber > 1);
        public bool HasNext => (PageNumber < TotalPages);
        public IEnumerable<T> Items { get; set; }

        #region Static Methods
        public static PageModel<T> Create(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new PageModel<T>(items, count, pageNumber, pageSize);
        }

        public static PageModel<T> CreateManually(IEnumerable<T> source, int pageNumber, int pageSize, int? totalRecords = null)
        {
            var count = totalRecords ?? source.Count();
            var items = source.ToList();

            return new PageModel<T>(items, count, pageNumber, pageSize);
        } 
        #endregion
    }
}
