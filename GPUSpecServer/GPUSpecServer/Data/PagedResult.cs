using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace GPUSpecServer.Data
{
    public class PagedResult<T>
    {
        private PagedResult(
          List<T> data,
          int count,
          int pageIndex,
          int pageSize)
        {
            Data = data;
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = count;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }
        public static async Task<PagedResult<T>> CreateAsync(
          IQueryable<T> source,
          int pageIndex,
          int pageSize,
          string sortColumn,
          string sortOrder= "desc"
            )
        {
            var count = await source.CountAsync();
            source = source.OrderBy($"{sortColumn} {sortOrder}")
              .Skip((pageIndex - 1) * pageSize)
              .Take(pageSize);
            var data = await source.ToListAsync();
            return new PagedResult<T>(
              data,
              count,
              pageIndex,
              pageSize);
        }

        public List<T> Data
        {
            get;
            private set;
        }

        public int PageIndex
        {
            get;
            private set;
        }

        public int PageSize
        {
            get;
            private set;
        }

        public int TotalCount
        {
            get;
            private set;
        }

        public int TotalPages
        {
            get;
            private set;
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }
    }
}